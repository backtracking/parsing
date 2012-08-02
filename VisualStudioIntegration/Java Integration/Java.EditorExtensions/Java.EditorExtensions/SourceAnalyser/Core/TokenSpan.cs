namespace Smartmobili.VisualStudio.Core
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TokenSpan : IEquatable<TokenSpan>
    {
        public static TokenSpan Invalid;

        public static TokenSpan Empty;

        private readonly Position start;

        private readonly Position end;

        static TokenSpan()
        {
            Invalid = new TokenSpan();
            Empty = new TokenSpan(new Position(0, 0), new Position(0, 0));
        }
        
        public TokenSpan(Position pos)
        {
            this.start = this.end = pos;
        }

        public TokenSpan(Position start, Position end)
        {
            this.start = start;
            this.end = end;
        }

        public Position Start
        {
            get
            {
                return this.start;
            }
        }
        public Position End
        {
            get
            {
                return this.end;
            }
        }
        public TokenSpan Normalize()
        {
            if (this.start > this.end)
            {
                return new TokenSpan(this.end, this.start);
            }
            return this;
        }

        public Position Middle
        {
            get
            {
                return GetMiddlePos(this);
            }
        }
        public bool Contains(Position pos)
        {
            return ((this.Start <= pos) && (pos <= this.End));
        }

        public bool Contains(TokenSpan other)
        {
            return ((this.Start <= other.Start) && (this.End >= other.End));
        }

        public bool Intersects(TokenSpan other)
        {
            if ((!this.Contains(other.Start) && !this.Contains(other.End)) && !other.Contains(this.Start))
            {
                return other.Contains(this.End);
            }
            return true;
        }

        private static Position GetMiddlePos(TokenSpan ts)
        {
            if (ts.start.Line == ts.end.Line)
            {
                return new Position(ts.start.Line, (ts.end.Character + ts.start.Character) / 2);
            }
            return new Position((ts.end.Line + ts.start.Line) / 2, 0);
        }

        public override string ToString()
        {
            return string.Concat(new object[] { "(", this.Start, ",", this.End, ")" });
        }

        public bool Equals(TokenSpan other)
        {
            return (this.start.Equals(other.start) && this.end.Equals(other.end));
        }

        public override bool Equals(object obj)
        {
            return ((obj is TokenSpan) && this.Equals((TokenSpan) obj));
        }

        public override int GetHashCode()
        {
            return (this.Start.GetHashCode() + this.End.GetHashCode());
        }

        public static bool operator ==(TokenSpan s1, TokenSpan s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(TokenSpan s1, TokenSpan s2)
        {
            return !s1.Equals(s2);
        }

        
    }
}

