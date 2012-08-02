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

            int curLine = 0;
            int startPosition = 0;

            var tokenizer = new JavaTokenizer(new ANTLRStringStream(EntireBuffer));
            var antlrToken = tokenizer.NextToken();
            while (antlrToken.Type != JavaLexer.EOF)
            {
                //System.Diagnostics.Debug.WriteLine(string.Format("token : {0}", tokenizer.TokenNames[antlrToken.Type]));

                // Antlr line starts from 1
                curLine = antlrToken.Line - 1;
                
                if (antlrToken.Type != JavaLexer.WS &&
                    antlrToken.Type != JavaLexer.NL)
                {
                    TokenLines[curLine].Tokens.Add(TokenFactory.CreateToken(antlrToken));
                }
                else
                {
                    // Since we don't store noisy token(spaces and nl) we need to store start/end index
                    // To be able to map a position with a line
                    if (antlrToken.Type == JavaLexer.NL)
                    {
                        // Foreach TokenLine we store start/Stop index
                        int tokLen = antlrToken.Text.Length;
                        TokenLines[curLine].StartPosition = startPosition;
                        TokenLines[curLine].EndPosition = antlrToken.StopIndex;
                        startPosition = antlrToken.StopIndex + tokLen;
                    }
                }
                // Get next token from antlr lexer
                antlrToken = tokenizer.NextToken();
            }

            // if our buffer doesn't end with a new line...
            if (TokenLines != null && TokenLines.Count > 0)
            {
                TokenLines[curLine].StartPosition = startPosition;
                TokenLines[curLine].EndPosition = antlrToken.StopIndex - 1;
            }
        }
        
    }
}
