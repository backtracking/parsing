namespace Java.EditorExtensions
{
    using System;
    using Smartmobili.VisualStudio.Core;

    public class NumericLiteralToken : Token2
    {
        private readonly int sourceLength;

        internal NumericLiteralToken(int kind, int startIndex, int endIndex)
            : base(kind, startIndex, endIndex, JavaClassificationTypes.Number)
        {

        }
    }
}

