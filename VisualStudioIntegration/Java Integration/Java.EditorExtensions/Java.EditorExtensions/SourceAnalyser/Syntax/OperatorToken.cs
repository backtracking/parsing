namespace Java.EditorExtensions
{
    using System;
    using Smartmobili.VisualStudio.Core;

    public class OperatorToken : Token2
    {
        private readonly int sourceLength;

        internal OperatorToken(int kind, int startIndex, int endIndex)
            : base(kind, startIndex, endIndex, JavaClassificationTypes.Unknown)
        {

        }
    }
}

