using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using System.Text.RegularExpressions;
using Smartmobili.JavaTools.Editor.Core;
using Smartmobili.VisualStudio.Core;

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


    /// <summary>
    /// Implements <see cref="IClassifier"/> in order to provide coloring
    /// </summary>
    internal class JavaClassifier : IClassifier
    {
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        private IClassificationTypeRegistryService classificationRegistryService;
        private ITextBuffer textBuffer;

        private TextRangeList _commentRanges = new TextRangeList();

        private SourceItem _srcItem;
        //private JavaParser _parser;
        //private List<> _toto;
        

        internal JavaClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService)
        {
            this.textBuffer = textBuffer;
            this.classificationRegistryService = classificationRegistryService;

            SnapshotSpan entireSnapSpan = Smartmobili.JavaTools.Editor.Core.EditorExtensions.CreateEntireBufferSnapshotSpan(textBuffer);
            ITextSnapshot curSnapshot = textBuffer.CurrentSnapshot;
            var entireBuffer = entireSnapSpan.GetText();
            _srcItem = SourceAnalyzer.Instance.AddItem(textBuffer.GetFileName(), entireBuffer, curSnapshot.Length, curSnapshot.LineCount);

            
            


            //// create an instance of the lexer
            //ANTLRStringStream stream = new ANTLRStringStream(entireBuffer);

            //JavaLexer lexer = new JavaLexer(stream);

            //// wrap a token-stream around the lexer
            //CommonTokenStream tokens = new CommonTokenStream(lexer);

            //// create the parser
            //_parser = new JavaParser(tokens);
            //CommonTree tree = (CommonTree)_parser.javaSource().Tree;
            //PrintTree(tree, 1);

            
            
            


            this.textBuffer.Changed += new EventHandler<TextContentChangedEventArgs>(textBuffer_TextContentChanged);
            this.textBuffer.ReadOnlyRegionsChanged += new EventHandler<SnapshotSpanEventArgs>(textBuffer_ReadOnlyRegionsChanged);
        }

        public void PrintTree(CommonTree t, int indent)
        {
            if (t != null)
            {

                StringBuilder sb = new StringBuilder(indent);

                for (int i = 0; i < indent; i++)
                    sb = sb.Append("   ");

                for (int i = 0; i < t.ChildCount; i++)
                {
                    ITree curNode = t.GetChild(i);
                    int curLine = curNode.Line;
                    string nodeText = string.Format("{0}({1},{2})", curNode.ToString(), curLine, curNode.CharPositionInLine);
                    System.Diagnostics.Debug.WriteLine(sb.ToString() + nodeText);
                    
                    PrintTree((CommonTree)t.GetChild(i), indent + 1);
                }
            }
        }



        void textBuffer_TextContentChanged(object sender, TextContentChangedEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine("textBuffer_TextContentChanged");
            //Microsoft.VisualStudio.Text.Implementation.TextBuffer textBuffer = sender as TextBuffer;
            _srcItem.Changed(e);
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
                        token.Type = JavaLexer.BLOCK_COMMENT;
                    }
                    shouldGetNext = false;
                }
                else
                {
                    // Check next token is not inside a commented region
                    //_commentRanges.
                    if (token.Type != JavaLexer.EOF && _commentRanges.Belongs(span.Start.Position))
                    {
                        token.Type = JavaLexer.BLOCK_COMMENT;
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
                    if (token.Type == JavaLexer.BLOCK_COMMENT)
                    {
                        _commentRanges.Add(new TextRange(token.StartIndex, token.StopIndex));
                    }

                    // Get next token
                    token = tokenizer.NextToken();
                }
                _updateCommentRanges = false;
            }
            
        }

        //IList<ClassificationSpan> IClassifier.GetClassificationSpans(SnapshotSpan span)
        //{
        //    var classifications = new List<ClassificationSpan>();
        //    System.Diagnostics.Debug.Write(span.GetText());

        //    int startIndex, endIndex, length;
        //    int startLine = span.Snapshot.GetLineNumberFromPosition(span.Start);
        //    int endLine = span.Snapshot.GetLineNumberFromPosition(span.End - 1);

        //    //startIndex = span.Snapshot.GetLineFromLineNumber(span.Start.GetContainingLine().LineNumber).Start.Position + token.StartIndex;
        //    //endIndex = span.Snapshot.GetLineFromLineNumber(span.Start.GetContainingLine().LineNumber).Start.Position + token.StopIndex;
        //    length = endIndex - startIndex + 1;

        //    if (endIndex > span.Snapshot.GetText().Length)
        //        endIndex = span.Snapshot.GetText().Length;

        //    if (endIndex >= startIndex && !span.Snapshot.TextBuffer.IsReadOnly(new Span(startIndex, length)))
        //    {
        //        // Add the classfication span
        //        classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, startIndex, length), GetClassificationType(token)));
        //    }

        //    return classifications;
        //}

        //IList<ClassificationSpan> IClassifier.GetClassificationSpans(SnapshotSpan span)
        //{
        //    var classifications = new List<ClassificationSpan>();
        //    System.Diagnostics.Debug.Write(span.GetText());

        //    try
        //    {
        //        // We are only getting source code line by line so we have to know if the current line is part of 
        //        // a slash-star (/*) comment
        //        // So we parse entire source and we build a list of comment positions.
        //        GetCommentRanges(span);

        //        // So now we build a Antlr lexer to get tokens from input stream, however
        //        // grammar normally needs more than one line to be able to recognize comments
        //        // and in this case we get an exception and token.Type is JavaLexer.EOF.
        //        int startIndex, endIndex, length;
        //        var tokenizer = new JavaLexer(new ANTLRStringStream(span.GetText()));
        //        bool shouldGetNext = true;

        //        var token = GetNextToken(tokenizer, span, ref shouldGetNext);
        //        //var token = tokenizer.NextToken();
        //        while (token.Type != JavaLexer.EOF)
        //        {
        //            //if (token.Text == "final")
        //            //{
        //            //    System.Diagnostics.Debug.WriteLine("final");
        //            //}
        //            startIndex = span.Snapshot.GetLineFromLineNumber(span.Start.GetContainingLine().LineNumber).Start.Position + token.StartIndex;
        //            endIndex = span.Snapshot.GetLineFromLineNumber(span.Start.GetContainingLine().LineNumber).Start.Position + token.StopIndex;
        //            length = endIndex - startIndex + 1;

        //            if (endIndex > span.Snapshot.GetText().Length)
        //                endIndex = span.Snapshot.GetText().Length;

        //            if (endIndex >= startIndex && !span.Snapshot.TextBuffer.IsReadOnly(new Span(startIndex, length)))
        //            {
        //                // Add the classfication span
        //                classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, startIndex, length), GetClassificationType(token)));
        //            }

        //            // Get next token
        //            //token = tokenizer.NextToken();
        //            token = GetNextToken(tokenizer, span, ref shouldGetNext);
        //        }

        //        foreach (var region in span.Snapshot.TextBuffer.GetReadOnlyExtents(span))
        //        {
        //            // Add classfication for read only regions
        //            classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, region), classificationRegistryService.GetClassificationType("PythonReadOnlyRegion")));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine("Exception");
        //    }

        //    return classifications;
        //}

        IList<ClassificationSpan> IClassifier.GetClassificationSpans(SnapshotSpan span)
        {
            var classifications = new List<ClassificationSpan>();
            System.Diagnostics.Debug.Write(span.GetText());

            try
            {
                SourceItem srcItem = SourceAnalyzer.Instance.GetItem(textBuffer.GetFileName());
                if (srcItem != null)
                {
                    IClassificationType classType = null;
                    int line = span.Snapshot.GetLineFromLineNumber(span.Start.GetContainingLine().LineNumber).LineNumber;
                    var tokenLines = srcItem.TokenLines[line];
                    foreach (var token in tokenLines.Tokens)
                    {
                        int startIndex = token.StartPosition;
                        int length = token.EndPosition - token.StartPosition + 1;
                        classType = GetClassificationType(token);
                        classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, startIndex, length), classType));
                    }

                    // Add classfication for read only regions
                    foreach (var region in span.Snapshot.TextBuffer.GetReadOnlyExtents(span))
                    {
                        classType = classificationRegistryService.GetClassificationType(JavaClassificationTypes.ReadOnlyRegion);
                        classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, region), classType));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception");
            }

            return classifications;
        }

        private IClassificationType GetClassificationType(Token2 token)
        {
            return classificationRegistryService.GetClassificationType(token.ClassificationTypeKey);
            //if (token.ClassificationTypeKey != null)
            //{
            //    return classificationRegistryService.GetClassificationType(token.ClassificationTypeKey);
            //}
            //else
            //{
            //    return classificationRegistryService.GetClassificationType(JavaClassificationTypes.Unknown);
            //}

            //if (token is KeywordToken)
            //{
            //    return classificationRegistryService.GetClassificationType(JavaClassificationTypes.Keyword);
            //}
            //else if (token is NumericLiteralToken)
            //{
            //    return classificationRegistryService.GetClassificationType(JavaClassificationTypes.Number);
            //}
            //else if (token is StringLiteralToken)
            //{
            //    return classificationRegistryService.GetClassificationType(JavaClassificationTypes.String);
            //}
            //else if (token is CommentLiteralToken)
            //{
            //    return classificationRegistryService.GetClassificationType(JavaClassificationTypes.Comment);
            //}
            //else
            //{
            //    return classificationRegistryService.GetClassificationType(JavaClassificationTypes.Unknown);
            //}
        }


        
    }
}
