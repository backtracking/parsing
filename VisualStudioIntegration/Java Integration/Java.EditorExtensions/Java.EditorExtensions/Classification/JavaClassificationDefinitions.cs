using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;


namespace Java.EditorExtensions
{
    #region Format definition


    /// <summary>
    /// Classification definitions
    /// </summary>
    internal class JavaClassificationDefinitions
    {
        [Name(JavaClassificationTypes.ReadOnlyRegion), Export]
        internal ClassificationTypeDefinition JavaReadOnlyRegionClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = JavaClassificationTypes.ReadOnlyRegion)]
        [Name("JavaReadOnlyRegionFormatDefinition")]
        [Order]
        internal sealed class JavaReadOnlyRegionClassificationFormat : ClassificationFormatDefinition
        {
            internal JavaReadOnlyRegionClassificationFormat()
            {
                BackgroundColor = Colors.LightGray;
                this.DisplayName = "Java Read Only Region";
            }
        }

        [Name(JavaClassificationTypes.Comment), Export]
        internal ClassificationTypeDefinition CommentClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = JavaClassificationTypes.Comment)]
        [Name("JavaCommentFormatDefinition")]
        [Order]
        internal sealed class CommentClassificationFormat : ClassificationFormatDefinition
        {
            internal CommentClassificationFormat()
            {
                ForegroundColor = Colors.Green;
                this.DisplayName = "Java Comment";
            }
        }

        [Name(JavaClassificationTypes.Delimiter), Export]
        internal ClassificationTypeDefinition DelimiterClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = JavaClassificationTypes.Delimiter)]
        [Name("JavaDelimiterFormatDefinition")]
        [Order]
        internal sealed class DelimiterClassificationFormat : ClassificationFormatDefinition
        {
            public DelimiterClassificationFormat()
            {
                this.DisplayName = "Java Delimiter";
            }
        }

        [Name(JavaClassificationTypes.Operator), Export]
        internal ClassificationTypeDefinition OperatorClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = JavaClassificationTypes.Operator)]
        [Name("JavaOperatorFormatDefinition")]
        [Order]
        internal sealed class OperatorClassificationFormat : ClassificationFormatDefinition
        {
            public OperatorClassificationFormat()
            {
                this.DisplayName = "Java Operator";
            }
        }

        [Name(JavaClassificationTypes.Keyword), Export]
        internal ClassificationTypeDefinition KeywordClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = JavaClassificationTypes.Keyword)]
        [Name("JavaKeywordFormatDefinition")]
        [Order]
        internal sealed class KeywordClassificationFormat : ClassificationFormatDefinition
        {
            internal KeywordClassificationFormat()
            {
                ForegroundColor = Colors.Blue;
                this.DisplayName = "Java Keyword";
            }
        }

        [Name(JavaClassificationTypes.Identifier), Export]
        internal ClassificationTypeDefinition IdentifierClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = JavaClassificationTypes.Identifier)]
        [Name("JavaIdentifierFormatDefinition")]
        [Order]
        internal sealed class IdentifierClassificationFormat : ClassificationFormatDefinition
        {
            public IdentifierClassificationFormat()
            {
                this.DisplayName = "Java Identifier";
            }
        }

        [Name(JavaClassificationTypes.String), Export]
        internal ClassificationTypeDefinition StringClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = JavaClassificationTypes.String)]
        [Name("JavaStringFormatDefinition")]
        [Order]
        internal sealed class StringClassificationFormat : ClassificationFormatDefinition
        {
            internal StringClassificationFormat()
            {
                ForegroundColor = Colors.Brown;
                this.DisplayName = "Java String";
            }
        }

        [Name(JavaClassificationTypes.Number), Export]
        internal ClassificationTypeDefinition NumberClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = JavaClassificationTypes.Number)]
        [Name("JavaNumberFormatDefinition")]
        [Order]
        internal sealed class NumberClassificationFormat : ClassificationFormatDefinition
        {
            public NumberClassificationFormat()
            {
                ForegroundColor = Colors.Orange;
                this.DisplayName = "Java Number";
            }
        }

        [Name(JavaClassificationTypes.Unknown), Export]
        internal ClassificationTypeDefinition UnknownClassificationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = JavaClassificationTypes.Number)]
        [Name("JavaUnknownFormatDefinition")]
        [Order]
        internal sealed class UnknownClassificationFormat : ClassificationFormatDefinition
        {
            public UnknownClassificationFormat()
            {
                this.DisplayName = "Java Unknown";
            }
        }
    }
    #endregion //Format definition
}
