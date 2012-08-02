using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using Java.EditorExtensions;

public class JavaTokenizer : JavaLexer
{
    private bool _callBaseNext = true;

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
    

    public override IToken NextToken()
    {
        IToken antlrToken = null;

        if (_lines == null)
        {
            antlrToken = base.NextToken();
            if (IsMultiLine(antlrToken))
                SplitMultiLineToken(antlrToken);
        }
        else
        {
            if (_lineIndex >= _lines.Length)
            {
                _lines = null;
                _newLineLengths = null;
                _returnNewLineToken = null;

                antlrToken = base.NextToken();
                if (IsMultiLine(antlrToken))
                    SplitMultiLineToken(antlrToken);
            }
            else
            {
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

                    if (_newLineLengths[_lineIndex] != 0)
                    {
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
