namespace Java.EditorExtensions
{
    using System;
    using Smartmobili.VisualStudio.Core;

    public class KeywordToken : Token2
    {
        private readonly int sourceLength;
        

        internal KeywordToken(int kind, int startIndex, int endIndex)
            : base(kind, startIndex, endIndex, JavaClassificationTypes.Keyword)
        {
            
        }
    }
}

