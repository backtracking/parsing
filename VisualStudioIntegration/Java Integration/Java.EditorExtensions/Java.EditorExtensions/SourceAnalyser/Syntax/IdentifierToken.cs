namespace Java.EditorExtensions
{
    using System;
    using Smartmobili.VisualStudio.Core;

    public class IdentifierToken : Token2
    {
        private readonly int sourceLength;

        internal IdentifierToken(int kind, int startIndex, int endIndex)
            : base(kind, startIndex, endIndex, JavaClassificationTypes.Unknown)
        {

        }
    }
}

