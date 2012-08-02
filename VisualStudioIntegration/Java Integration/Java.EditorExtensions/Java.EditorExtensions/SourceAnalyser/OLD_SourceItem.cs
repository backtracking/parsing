using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smartmobili.VisualStudio.Core;
using Antlr.Runtime;
using Microsoft.VisualStudio.Text;

namespace Java.EditorExtensions
{
    public class TokenLine
    {
        public int StartPosition { get; set; }
        
        public int EndPosition { get; set; }
        
        private Token2Array _tokenArray;
        public Token2Array Tokens 
        {
            get { return _tokenArray;  }
        }

        public TokenLine()
        {
            _tokenArray = new Token2Array();
        }
    }

    public class SourceItem
    {
        public LazyArray<TokenLine> TokenLines { get; private set; }

        private StringBuilder _buffer;
        public string EntireBuffer 
        {
            get
            {
                return _buffer.ToString();
            }
            set
            {
                _buffer = new StringBuilder(value);
            }
        }

        public int Length { get; private set; }

        public int LineCount { get; private set; }

        private int _tokLineStartpos;
        private int _tokLineEndpos;

        public SourceItem()
        {
            EntireBuffer = string.Empty;
            _tokLineStartpos = 0;
            _tokLineEndpos = 0;
        }

        public SourceItem(string entireBuffer, int length, int linecount) : this()
        {
            if (string.IsNullOrEmpty(entireBuffer))
                return;

            EntireBuffer = entireBuffer;
            Length = length;
            LineCount = linecount;


            Func<int, TokenLine> itemCreator = itemCreator = index => new TokenLine(); ;
            TokenLines = new LazyArray<TokenLine>(linecount, itemCreator);

            //BuildLineMapping(entireBuffer);

            StartLexicalAnalysis();
        }

        //private void BuildLineMapping(string buffer)
        //{
        //   EntireBuffer.
        //}



        public void Changed(TextContentChangedEventArgs e)
        {
            int startLine = GetContainingLineFromPosition(e.Changes[0].OldSpan.Start);
            //e.Changes[0].
            //int lineBefore = 
        }

        private int GetContainingLineFromPosition(int index)
        {
            int line = 0;

            int i = 0;
            foreach (TokenLine tokenLine in TokenLines)
            {
                if ((index >= tokenLine.StartPosition) && (index <= tokenLine.EndPosition))
                {
                    line = i;
                    break;
                }
                i++;
            }


            return line;
        }

        private void StartLexicalAnalysis()
        {
            //Argument.ThrowIfNull(srcItem, "StartLexicalAnalysis : srcItem");

            var tokenizer = new JavaLexer(new ANTLRStringStream(EntireBuffer));
            var antlrToken = tokenizer.NextToken();
            while (antlrToken.Type != JavaLexer.EOF)
            {
                //System.Diagnostics.Debug.WriteLine(string.Format("token : {0}", tokenizer.TokenNames[antlrToken.Type]));
                //System.Diagnostics.Debug.WriteLine("token : {0}", TokenNames[antlrToken.Type]);

                // Antlr line starts from 1
                int curLine = antlrToken.Line - 1;
                //int startPosition = 0;
                //int endPosition = 0;

                // For each line we only store interesting tokens ( ie not a newline or space)
                //if (antlrToken.Type != JavaLexer.WS &&
                //    antlrToken.Type != JavaLexer.NL)
                //{
                    // We need to handle tokens on several lines (ex comments)
                    if (antlrToken.Type != JavaLexer.BLOCK_COMMENT &&
                        antlrToken.Type != JavaLexer.JAVADOC_COMMENT)
                    {
                        TokenLines[curLine].Tokens.Add(TokenFactory.CreateToken(antlrToken));
                    }
                    else
                    {
                        HandleMultiLineToken(antlrToken);
                    }
                //}
                //else
                //{
                    //// Since we don't store noisy tokens we need to store start/end index
                    //if (antlrToken.Type == JavaLexer.NL)
                    //{
                    //    // Foreach TokenLine we store start/Stop index
                    //    int tokLen = antlrToken.Text.Length;
                    //    endPosition = antlrToken.StopIndex + tokLen;
                    //    TokenLines[curLine].StartPosition = startPosition;
                    //    TokenLines[curLine].EndPosition = endPosition;
                    //    startPosition = endPosition + 1;
                    //}
                //}
                // Get next token from antlr lexer
                antlrToken = tokenizer.NextToken();
            }

        }

        private void HandleMultiLineToken(IToken antlrToken)
        {
            //int startLine = antlrToken.Line;
            //int startIndex = antlrToken.StartIndex;
            string[] lines = antlrToken.Text.SplitAndKeepSeparators(new string[] { "\r\n", "\n" }).ToArray();
            if (lines != null && lines.Length > 0)
            {
                //int lineIndex = 0;
                DummyToken2 splittedToken = new DummyToken2(antlrToken);
                foreach (var line in lines)
                {
                    splittedToken.StopIndex = splittedToken.StartIndex + line.Length - 1;

                    TokenLines[splittedToken.Line - 1].Tokens.Add(TokenFactory.CreateToken(splittedToken));
                    
                    //TokenLines[splittedToken.Line - 1].StartPosition = splittedToken.StartIndex;
                    //TokenLines[splittedToken.Line - 1].EndPosition = splittedToken.StopIndex;

                    splittedToken.StartIndex = splittedToken.StopIndex + 1;
                    splittedToken.Line++;
                }
            }
        }
    }
}
