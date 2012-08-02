namespace Smartmobili.VisualStudio.Core
{

    using System;
    using System.Collections.Generic;

    public abstract class Token
    {
        private readonly int kind;
        private readonly TokenSpan span;

        internal Token(int kind, Position startPosition, Position endPosition)
        {
            this.kind = kind;
            this.span = new TokenSpan(startPosition, endPosition);
        }

        //public abstract void Accept(ITokenVisitor visitor);

        public Position StartPosition
        {
            get
            {
                return this.span.Start;
            }
        }

        public Position EndPosition
        {
            get
            {
                return this.span.End;
            }
        }

        public int Kind
        {
            get
            {
                return this.kind;
            }
        }

        public TokenSpan Span
        {
            get
            {
                return this.span;
            }
        }
    }

    public class TokenArray : List<Token>
    {

    }
}

