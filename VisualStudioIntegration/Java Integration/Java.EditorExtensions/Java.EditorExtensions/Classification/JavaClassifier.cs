using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using Antlr.Runtime;
using System.Text.RegularExpressions;

namespace Java.EditorExtensions
{

    internal class TextRange
    {
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public TextRange() 
        {}

        public TextRange(int startIndex, int endIndex) 
        {
            this.StartIndex = startIndex;
            this.EndIndex = endIndex;
        }
    }

    internal class TextRangeList : List<TextRange>
    {
        public bool Belongs(int startIndex)
        {
            TextRange textRange = this.Find(delegate(TextRange t) 
            {
                return startIndex >= t.StartIndex && startIndex < t.EndIndex; 
            }) ;

            return textRange != null;
        }
    }

    internal class DummyToken : IToken
    {
        public DummyToken()
        {
         
        }
        int IToken.Channel { get; set; }
        int IToken.CharPositionInLine { get; set; }
        ICharStream IToken.InputStream { get; set; }
        int IToken.Line { get; set; }
        int IToken.StartIndex { get; set; }
        int IToken.StopIndex { get; set; }
        string IToken.Text { get; set; }
        int IToken.TokenIndex { get; set; }
        int IToken.Type { get; set; }
    }


    /// <summary>
    /// Implements <see cref="IClassifier"/> in order to provide coloring
    /// </summary>
    internal class JavaClassifier : IClassifier
    {
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        private IClassificationTypeRegistryService classificationRegistryService;
        private ITextBuffer textBuffer;

        private TextRangeList _commentRanges = new TextRangeList();


        internal JavaClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService)
        {
            this.textBuffer = textBuffer;
            this.classificationRegistryService = classificationRegistryService;

            this.textBuffer.Changed += new EventHandler<TextContentChangedEventArgs>(textBuffer_TextContentChanged);
            this.textBuffer.ReadOnlyRegionsChanged += new EventHandler<SnapshotSpanEventArgs>(textBuffer_ReadOnlyRegionsChanged);
        }

        void textBuffer_TextContentChanged(object sender, TextContentChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("textBuffer_TextContentChanged");
        }

        void textBuffer_ReadOnlyRegionsChanged(object sender, SnapshotSpanEventArgs e)
        {
            // We need to call this event when read-only regions are added, so they will be grayed out.
            OnClassificationChanged(new SnapshotSpan(textBuffer.CurrentSnapshot, e.Span));
        }

        private void OnClassificationChanged(SnapshotSpan changeSpan)
        {
            if (ClassificationChanged != null)
            {
                ClassificationChanged(this, new ClassificationChangedEventArgs(changeSpan));
            }
        }


        private IToken GetNextToken(JavaLexer javaLexer, SnapshotSpan span, ref bool shouldGetNext)
        {
            IToken token = null;

            if (shouldGetNext)
            {
                token = javaLexer.NextToken();
                if (token.Type == JavaLexer.EOF && token.InputStream.ToString().StartsWith("/*"))
                {
                    string curLine = span.GetText();
                    int startIndex = curLine.IndexOf("/*");
                    if (startIndex != -1)
                    {
                        token.Text = "/*";
                        token.Line = 1;
                        token.StartIndex = startIndex;
                        token.StopIndex = curLine.GetCommentStopIndex(startIndex);
                        token.Type = JavaLexer.COMMENT;
                    }
                    shouldGetNext = false;
                }
                else
                {
                    // Check next token is not inside a commented region
                    //_commentRanges.
                    if (token.Type != JavaLexer.EOF && _commentRanges.Belongs(span.Start.Position))
                    {
                        token.Type = JavaLexer.COMMENT;
                    }


                    shouldGetNext = true;
                }
            }
            else
            {
                token = new DummyToken();
                token.Type = JavaLexer.EOF;
            }
            
            return token;
        }

        private bool _updateCommentRanges = true;
        void GetCommentRanges(SnapshotSpan span)
        {
            if (_updateCommentRanges)
            {
                _commentRanges.Clear();

                // First try with a regex
                //string source = span.Snapshot.GetText();
                //var rx = new Regex(@"(?<!"")\/\*.+?\*\/(?!"")", RegexOptions.None);
                //var matches = rx.Matches(source);

                string source = span.Snapshot.GetText();
                var tokenizer = new JavaLexer(new ANTLRStringStream(source));
                var token = tokenizer.NextToken();
                while (token.Type != JavaLexer.EOF)
                {
                    if (token.Type == JavaLexer.COMMENT)
                    {
                        _commentRanges.Add(new TextRange(token.StartIndex, token.StopIndex));
                    }

                    // Get next token
                    token = tokenizer.NextToken();
                }
                _updateCommentRanges = false;
            }
            

            //int startIndex, endIndex, curIndex;
            //string source = span.Snapshot.GetText();
            //if (!string.IsNullOrEmpty(source))
            //{
            //    curIndex = startIndex = endIndex = 0;
            //    while (true)
            //    {
            //        startIndex = source.IndexOf("/*", curIndex);
            //        if (startIndex != -1)
            //        {
            //            endIndex = source.IndexOf("*/", curIndex);
            //            if (endIndex != -1)
            //            {
            //                endIndex++;
            //                _commentRanges.Add(new TextRange(startIndex, endIndex));
            //            }
            //            else
            //            {
            //                endIndex = source.Length - 1;
            //                _commentRanges.Add(new TextRange(startIndex, endIndex));
            //                break;
            //            }
                        
            //            curIndex = endIndex;
            //        }
            //        else
            //        {
            //            break;
            //        }
                    
                    
            //    }
            //}
        }

        IList<ClassificationSpan> IClassifier.GetClassificationSpans(SnapshotSpan span)
        {
            var classifications = new List<ClassificationSpan>();
            System.Diagnostics.Debug.Write(span.GetText());

            try
            {
                // We are only getting source code line by line so we have to know if the current line is part of 
                // a slash-star (/*) comment
                // So we parse entire source and we build a list of comment positions.
                GetCommentRanges(span);

                // So now we build a Antlr lexer to get tokens from input stream, however
                // grammar normally needs more than one line to be able to recognize comments
                // and in this case we get an exception and token.Type is JavaLexer.EOF.
                int startIndex, endIndex, length;
                var tokenizer = new JavaLexer(new ANTLRStringStream(span.GetText()));
                bool shouldGetNext = true;
                
                var token = GetNextToken(tokenizer, span, ref shouldGetNext);
                //var token = tokenizer.NextToken();
                while (token.Type != JavaLexer.EOF)
                {
                    //if (token.Text == "final")
                    //{
                    //    System.Diagnostics.Debug.WriteLine("final");
                    //}
                    startIndex = span.Snapshot.GetLineFromLineNumber(span.Start.GetContainingLine().LineNumber).Start.Position + token.StartIndex;
                    endIndex = span.Snapshot.GetLineFromLineNumber(span.Start.GetContainingLine().LineNumber).Start.Position + token.StopIndex;
                    length = endIndex - startIndex + 1;

                    if (endIndex > span.Snapshot.GetText().Length)
                        endIndex = span.Snapshot.GetText().Length;

                    if (endIndex >= startIndex && !span.Snapshot.TextBuffer.IsReadOnly(new Span(startIndex, length)))
                    {
                        // Add the classfication span
                        classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, startIndex, length), GetClassificationType(token)));
                    }

                    // Get next token
                    //token = tokenizer.NextToken();
                    token = GetNextToken(tokenizer, span, ref shouldGetNext);
                }


                //using (var systemState = new SystemState())
                //{
                //    int startIndex, endIndex;

                //    // Execute the IPy tokenizer
                //    var tokenizer = new Tokenizer(span.GetText().ToCharArray(), true, systemState, new CompilerContext(string.Empty, new QuietCompilerSink()));
                //    var token = tokenizer.Next();

                //    // Iterate the tokens
                //    while (token.Kind != TokenKind.EndOfFile)
                //    {
                //        // Determine the bounds of the classfication span
                //        startIndex = span.Snapshot.GetLineFromLineNumber(tokenizer.StartLocation.Line - 1 + span.Start.GetContainingLine().LineNumber).Start.Position + tokenizer.StartLocation.Column;
                //        endIndex = span.Snapshot.GetLineFromLineNumber(tokenizer.EndLocation.Line - 1 + span.Start.GetContainingLine().LineNumber).Start.Position + tokenizer.EndLocation.Column;

                //        if (endIndex > span.Snapshot.GetText().Length)
                //            endIndex = span.Snapshot.GetText().Length;

                //        if (endIndex > startIndex && !span.Snapshot.TextBuffer.IsReadOnly(new Span(startIndex, endIndex - startIndex)))
                //        {
                //            // Add the classfication span
                //            classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, startIndex, endIndex - startIndex), GetClassificationType(token)));
                //        }

                //        // Get next token
                //        token = tokenizer.Next();
                //    }
                //}

                foreach (var region in span.Snapshot.TextBuffer.GetReadOnlyExtents(span))
                {
                    // Add classfication for read only regions
                    classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, region), classificationRegistryService.GetClassificationType("PythonReadOnlyRegion")));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception");
            }

            return classifications;
        }

        private IClassificationType GetClassificationType(IToken token)
        {
            switch (token.Type)
            {
                case JavaLexer.PACKAGE:
                case JavaLexer.IMPORT:
                case JavaLexer.ABSTRACT:
                case JavaLexer.CLASS:
                case JavaLexer.IMPLEMENTS:
                case JavaLexer.INSTANCEOF:
                case JavaLexer.SUPER:
                case JavaLexer.PUBLIC:
                case JavaLexer.PRIVATE:
                case JavaLexer.PROTECTED:
                case JavaLexer.STATIC:
                case JavaLexer.FINAL:
                case JavaLexer.EXTENDS:
                case JavaLexer.NEW:
                case JavaLexer.THIS:
                case JavaLexer.ASSERT:
                case JavaLexer.GOTO:
                case JavaLexer.IF:
                case JavaLexer.ELSE:
                case JavaLexer.SYNCHRONIZED:
                case JavaLexer.TRY:
                case JavaLexer.CATCH:
                case JavaLexer.FINALLY:
                case JavaLexer.THROW:
                case JavaLexer.THROWS:
                case JavaLexer.FOR:
                case JavaLexer.DO:
                case JavaLexer.WHILE:
                case JavaLexer.SWITCH:
                case JavaLexer.BREAK:
                case JavaLexer.CONTINUE:
                case JavaLexer.DEFAULT:
                case JavaLexer.ENUM:
                case JavaLexer.CONST:
                case JavaLexer.NATIVE:
                case JavaLexer.VOID:
                case JavaLexer.BOOLEAN:
                case JavaLexer.BYTE:
                case JavaLexer.INT:
                case JavaLexer.LONG:
                case JavaLexer.FLOAT:
                case JavaLexer.DOUBLE:
                case JavaLexer.CHAR:
                case JavaLexer.CHARLITERAL:
                case JavaLexer.TRUE:
                case JavaLexer.FALSE:
                case JavaLexer.NULL:
                    return classificationRegistryService.GetClassificationType(JavaClassificationTypes.Keyword);

               
                case JavaLexer.INTLITERAL:
                case JavaLexer.LONGLITERAL:
                case JavaLexer.FLOATLITERAL:
                case JavaLexer.DOUBLELITERAL:
                    return classificationRegistryService.GetClassificationType(JavaClassificationTypes.Number);

                case JavaLexer.STRINGLITERAL:
                    return classificationRegistryService.GetClassificationType(JavaClassificationTypes.String);

                case JavaLexer.COMMENT:
                case JavaLexer.LINE_COMMENT:
                    return classificationRegistryService.GetClassificationType(JavaClassificationTypes.Comment);

                default:
                    return classificationRegistryService.GetClassificationType(JavaClassificationTypes.Unknown);
            }
        }


        //private IClassificationType GetClassificationType(Token token)
        //{
        //    // Translate the token kind into a classfication type
        //    switch (token.Kind)
        //    {
        //        case TokenKind.Comment:
        //            return classificationRegistryService.GetClassificationType(PyClassificationTypes.Comment);

        //        case TokenKind.Dot:
        //        case TokenKind.LeftParenthesis:
        //        case TokenKind.RightParenthesis:
        //        case TokenKind.LeftBracket:
        //        case TokenKind.RightBracket:
        //        case TokenKind.LeftBrace:
        //        case TokenKind.RightBrace:
        //        case TokenKind.Comma:
        //        case TokenKind.Colon:
        //        case TokenKind.BackQuote:
        //        case TokenKind.Semicolon:
        //        case TokenKind.Assign:
        //        case TokenKind.Twiddle:
        //        case TokenKind.LessThanGreaterThan:
        //            return classificationRegistryService.GetClassificationType(PyClassificationTypes.Delimiter);

        //        case TokenKind.Add:
        //        case TokenKind.AddEqual:
        //        case TokenKind.Subtract:
        //        case TokenKind.SubtractEqual:
        //        case TokenKind.Power:
        //        case TokenKind.PowerEqual:
        //        case TokenKind.Multiply:
        //        case TokenKind.MultiplyEqual:
        //        case TokenKind.FloorDivide:
        //        case TokenKind.FloorDivideEqual:
        //        case TokenKind.Divide:
        //        case TokenKind.DivEqual:
        //        case TokenKind.Mod:
        //        case TokenKind.ModEqual:
        //        case TokenKind.LeftShift:
        //        case TokenKind.LeftShiftEqual:
        //        case TokenKind.RightShift:
        //        case TokenKind.RightShiftEqual:
        //        case TokenKind.BitwiseAnd:
        //        case TokenKind.BitwiseAndEqual:
        //        case TokenKind.BitwiseOr:
        //        case TokenKind.BitwiseOrEqual:
        //        case TokenKind.Xor:
        //        case TokenKind.XorEqual:
        //        case TokenKind.LessThan:
        //        case TokenKind.GreaterThan:
        //        case TokenKind.LessThanOrEqual:
        //        case TokenKind.GreaterThanOrEqual:
        //        case TokenKind.Equal:
        //        case TokenKind.NotEqual:
        //            return classificationRegistryService.GetClassificationType(PyClassificationTypes.Operator);

        //        case TokenKind.KeywordAnd:
        //        case TokenKind.KeywordAssert:
        //        case TokenKind.KeywordBreak:
        //        case TokenKind.KeywordClass:
        //        case TokenKind.KeywordContinue:
        //        case TokenKind.KeywordDef:
        //        case TokenKind.KeywordDel:
        //        case TokenKind.KeywordElseIf:
        //        case TokenKind.KeywordElse:
        //        case TokenKind.KeywordExcept:
        //        case TokenKind.KeywordExec:
        //        case TokenKind.KeywordFinally:
        //        case TokenKind.KeywordFor:
        //        case TokenKind.KeywordFrom:
        //        case TokenKind.KeywordGlobal:
        //        case TokenKind.KeywordIf:
        //        case TokenKind.KeywordImport:
        //        case TokenKind.KeywordIn:
        //        case TokenKind.KeywordIs:
        //        case TokenKind.KeywordLambda:
        //        case TokenKind.KeywordNot:
        //        case TokenKind.KeywordOr:
        //        case TokenKind.KeywordPass:
        //        case TokenKind.KeywordPrint:
        //        case TokenKind.KeywordRaise:
        //        case TokenKind.KeywordReturn:
        //        case TokenKind.KeywordTry:
        //        case TokenKind.KeywordWhile:
        //        case TokenKind.KeywordYield:
        //            return classificationRegistryService.GetClassificationType(PyClassificationTypes.Keyword);

        //        case TokenKind.Name:
        //            return classificationRegistryService.GetClassificationType(PyClassificationTypes.Identifier);

        //        case TokenKind.Constant:
        //            ConstantValueToken ctoken = (ConstantValueToken)token;
        //            if (ctoken.Constant is string)
        //            {
        //                return classificationRegistryService.GetClassificationType(PyClassificationTypes.String);
        //            }
        //            else
        //            {
        //                return classificationRegistryService.GetClassificationType(PyClassificationTypes.Number);
        //            }

        //        default:
        //            return classificationRegistryService.GetClassificationType(PyClassificationTypes.Unknown);
        //    }
        //}
    }
}
