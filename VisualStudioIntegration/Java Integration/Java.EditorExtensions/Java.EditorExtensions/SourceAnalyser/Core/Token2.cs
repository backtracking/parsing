namespace Smartmobili.VisualStudio.Core
{

    using System;
    using System.Collections.Generic;

    public abstract class Token2
    {
        private readonly int kind;
        private readonly int startIndex;
        private readonly int stopIndex;
        protected readonly string classificationTypeKey;

        internal Token2(int kind, int startIndex, int stopIndex, string classificationKey)
        {
            this.kind = kind;
            this.startIndex = startIndex;
            this.stopIndex = stopIndex;
            this.classificationTypeKey = classificationKey;
        }

        //public abstract void Accept(ITokenVisitor visitor);

        public int StartPosition
        {
            get
            {
                return this.startIndex;
            }
        }

        public int EndPosition
        {
            get
            {
                return this.stopIndex;
            }
        }

        public string ClassificationTypeKey
        {
            get
            {
                return this.classificationTypeKey;
            }
        }
        //public int Length
        //{
        //    get
        //    {
        //        return (EndPosition - StartPosition + 1);
        //    }
        //}

        public int Kind
        {
            get
            {
                return this.kind;
            }
        }

        
    }

    public class Token2Array : List<Token2>
    {

    }
}

