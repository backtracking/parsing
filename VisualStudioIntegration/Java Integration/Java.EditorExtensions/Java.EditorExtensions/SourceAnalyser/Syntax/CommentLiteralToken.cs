namespace Java.EditorExtensions
{
    using System;
    using Smartmobili.VisualStudio.Core;

    public class CommentLiteralToken : Token2
    {
        private readonly int sourceLength;

        internal CommentLiteralToken(int kind, int startIndex, int endIndex)
            : base(kind, startIndex, endIndex, JavaClassificationTypes.Comment)
        {

        }
    }
}

