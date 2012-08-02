namespace Java.EditorExtensions
{
    using System;
    using Smartmobili.VisualStudio.Core;

    public class StringLiteralToken : Token2
    {
        private readonly int sourceLength;

        internal StringLiteralToken(int kind, int startIndex, int endIndex)
            : base(kind, startIndex, endIndex, JavaClassificationTypes.String)
        {

        }
    }
}

