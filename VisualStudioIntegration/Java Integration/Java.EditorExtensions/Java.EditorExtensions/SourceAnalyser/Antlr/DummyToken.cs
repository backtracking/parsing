using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;

namespace Java.EditorExtensions
{
    //public class DummyToken : IToken
    //{
    //    public DummyToken()
    //    {

    //    }
    //    int IToken.Channel { get; set; }
    //    int IToken.CharPositionInLine { get; set; }
    //    ICharStream IToken.InputStream { get; set; }
    //    int IToken.Line { get; set; }
    //    int IToken.StartIndex { get; set; }
    //    int IToken.StopIndex { get; set; }
    //    string IToken.Text { get; set; }
    //    int IToken.TokenIndex { get; set; }
    //    int IToken.Type { get; set; }
    //}



    public class DummyToken : IToken
    {
        public DummyToken()
        {

        }

        public DummyToken(IToken other)
        {
            Channel = other.Channel;
            CharPositionInLine = other.CharPositionInLine;
            InputStream = other.InputStream;
            Line = other.Line;
            StartIndex = other.StartIndex;
            StopIndex = other.StopIndex;
            Text = other.Text;
            TokenIndex = other.TokenIndex;
            Type = other.Type;
        }

        public int Channel { get; set; }
        public int CharPositionInLine { get; set; }
        public ICharStream InputStream { get; set; }
        public int Line { get; set; }
        public int StartIndex { get; set; }
        public int StopIndex { get; set; }
        public string Text { get; set; }
        public int TokenIndex { get; set; }
        public int Type { get; set; }
    }
}
