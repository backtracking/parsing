using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using Java.EditorExtensions;

public class JavaTokenizer : JavaLexer
{
    private IToken _token;
    private int _lineIndex = 0;
    private string[] _lines = null;
    private int[] _newLineLengths = null;
    private bool[] _returnNewLineToken;

    private int _startIndex = 0;

    
    public JavaTokenizer() :base()
	{
		
	}

    public JavaTokenizer(ICharStream input)
        : base(input)
	{
	}


    /// <summary>
    /// IsMultiLine return true if a token can potentially be on several lines
    /// </summary>
    /// <param name="antlrToken"></param>
    /// <returns></returns>
    private bool IsMultiLine(IToken antlrToken)
    {
        return (antlrToken.Type == JavaLexer.BLOCK_COMMENT || 
                antlrToken.Type == JavaLexer.JAVADOC_COMMENT);
    }
    
    /// <summary>
    /// NextToken() call the NextToken() from Antlr if we are eating a token that cannot be on multiple lines
    /// However if it's a multiline token we return the token line by line
    /// Let's consider the following example using \n for newline and starting at line 0 column 0 - 
    /// /*
    /// * a multiline comment
    /// */
    /// Here is the sequence returned by sucessive calls ([lineNo startPos endPos]) : 
    /// BLOCK_COMMENT [0 0 1]     NL[0 2 2] 
    /// BLOCK_COMMENT [1 3 23]    NL[1 24 24] 
    /// BLOCK_COMMENT [2 25 26]
    ///
    /// Without this method Antlr's NextToken() would have returned this: 
    /// BLOCK_COMMENT [0 0 26]
    /// </summary>
    /// <returns></returns>
    public override IToken NextToken()
    {
        IToken antlrToken = null;

        // if there is no splitted lines it means we are on the first call or previous token was
        // not a multiline token.
        if (_lines == null)
        {
            antlrToken = base.NextToken();
            if (IsMultiLine(antlrToken))
                SplitMultiLineToken(antlrToken);
        }
        else
        {
            // Index has reached the end of our splitted lines => we have finished to handle a multi-line token
            if (_lineIndex >= _lines.Length)
            {
                _lines = null;
                _newLineLengths = null;
                _returnNewLineToken = null;

                // We get the next token and we check if it's a single or multi-line token
                antlrToken = base.NextToken();
                if (IsMultiLine(antlrToken))
                    SplitMultiLineToken(antlrToken);
            }
            else
            {
                // This time we return a NL token
                if (_returnNewLineToken[_lineIndex])
                {
                    antlrToken = new DummyToken(_token);
                    antlrToken.Type = JavaLexer.NL;
                    antlrToken.Line += _lineIndex;
                    antlrToken.StartIndex = _startIndex;
                    antlrToken.StopIndex = antlrToken.StartIndex + _newLineLengths[_lineIndex] - 1;
                    
                    int lineLen = _lines[_lineIndex].Length;
                    int newLineLen = _newLineLengths[_lineIndex];
                    antlrToken.Text = _lines[_lineIndex].Substring(lineLen - newLineLen, newLineLen);

                    _startIndex = antlrToken.StopIndex + 1;
                    _lineIndex++;
                }
                else
                {
                    antlrToken = new DummyToken(_token);
                    antlrToken.Line += _lineIndex;

                    int lenWithoutNewLine = _lines[_lineIndex].Length - _newLineLengths[_lineIndex];
                    antlrToken.StartIndex = _startIndex;
                    antlrToken.StopIndex = antlrToken.StartIndex + lenWithoutNewLine - 1;
                    antlrToken.Text = _lines[_lineIndex].Substring(0, lenWithoutNewLine);

                    // Check the current line ends with a new line (NL)
                    if (_newLineLengths[_lineIndex] != 0)
                    {
                        // The next call will return a NL token
                        _returnNewLineToken[_lineIndex] = true;
                        _startIndex = antlrToken.StopIndex + 1;
                    }
                    else
                    {
                        _lineIndex++;
                    }
                }
            }
        }

        //System.Diagnostics.Debug.WriteLine(string.Format("[{0} {1}] : !{2}!", antlrToken.StartIndex, antlrToken.StopIndex, antlrToken.Text));
        return antlrToken;
    }

    private void SplitMultiLineToken(IToken antlrToken)
    {
        // The current token can POTENTIALLY be on several lines
        // but it's not certain( ex /* foo */) so need to test before
        string[] lines = antlrToken.Text.SplitAndKeepSeparators(new string[] { "\r\n", "\n" }).ToArray();
        if (lines.Length > 1)
        {
            _token = antlrToken;
            _lineIndex = 0;
            _startIndex = antlrToken.StartIndex;
            _lines = lines;
            _newLineLengths = _lines.GetNewLineLengths();
            _returnNewLineToken = new bool[_lines.Length];

            int lenWithoutNewLine = _lines[_lineIndex].Length - _newLineLengths[_lineIndex];
            antlrToken.StopIndex = antlrToken.StartIndex + lenWithoutNewLine - 1;
            antlrToken.Text = _lines[_lineIndex].Substring(0, lenWithoutNewLine);

            _returnNewLineToken[_lineIndex] = true;
            _startIndex = antlrToken.StopIndex + 1;
        }
    }

}
