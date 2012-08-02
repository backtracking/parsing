namespace Java.EditorExtensions
{
    using System;
    using Smartmobili.VisualStudio.Core;

    public class InvalidToken : Token2
    {
        private readonly int sourceLength;

        internal InvalidToken(int kind, int startIndex, int endIndex)
            : base(kind, startIndex, endIndex, JavaClassificationTypes.Unknown)
        {
          
        }
    }
}

