namespace Smartmobili.VisualStudio.Core
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Position : IComparable, IComparable<Position>, IEquatable<Position>
    {
        public static Position Unknown;
        private readonly bool isValid;
        private readonly int lineIndex;
        private readonly int charIndex;
        public Position(int lineIndex, int charIndex)
        {
            this.isValid = true;
            this.lineIndex = lineIndex;
            this.charIndex = charIndex;
        }

        public int Line
        {
            get
            {
                return this.lineIndex;
            }
        }
        public int Character
        {
            get
            {
                return this.charIndex;
            }
        }
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
        }
        public override bool Equals(object o)
        {
            return ((o is Position) && (Compare(this, (Position) o) == 0));
        }

        public bool Equals(Position p2)
        {
            return (Compare(this, p2) == 0);
        }

        public override int GetHashCode()
        {
            return (this.Line.GetHashCode() + this.Character.GetHashCode());
        }

        public int CompareTo(object other)
        {
            //Argument.Validate(other is Position, "other");
            return this.CompareTo((Position) other);
        }

        public int CompareTo(Position p)
        {
            return Compare(this, p);
        }

        public static int Compare(Position p1, Position p2)
        {
            int num = p1.Line.CompareTo(p2.Line);
            if (num == 0)
            {
                num = p1.Character.CompareTo(p2.Character);
            }
            return num;
        }

        public static bool operator ==(Position p1, Position p2)
        {
            return (Compare(p1, p2) == 0);
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return (Compare(p1, p2) != 0);
        }

        public static bool operator <(Position p1, Position p2)
        {
            return (Compare(p1, p2) < 0);
        }

        public static bool operator >(Position p1, Position p2)
        {
            return (Compare(p1, p2) > 0);
        }

        public static bool operator >=(Position p1, Position p2)
        {
            return (Compare(p1, p2) >= 0);
        }

        public static bool operator <=(Position p1, Position p2)
        {
            return (Compare(p1, p2) <= 0);
        }

        public override string ToString()
        {
            if (this.IsValid)
            {
                return string.Concat(new object[] { "(", this.Line, ",", this.Character, ")" });
            }
            return "(?,?)";
        }

        static Position()
        {
            Unknown = new Position();
        }
    }
}

