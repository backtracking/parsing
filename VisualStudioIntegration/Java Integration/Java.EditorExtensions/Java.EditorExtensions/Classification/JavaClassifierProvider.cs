/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Media;
//using Microsoft.PythonTools.Parsing;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Java.EditorExtensions
{
    /// <summary>
    /// Implements classification of text by using a ScriptEngine which supports the
    /// TokenCategorizer service.
    /// 
    /// Languages should subclass this type and override the Engine property. They 
    /// should then export the provider using MEF indicating the content type 
    /// which it is applicable to.
    /// </summary>
    [Export(typeof(IClassifierProvider)), ContentType(JavaCoreConstants.ContentType)]
    internal class JavaClassifierProvider : IClassifierProvider
    {
        private Dictionary<TokenCategory, IClassificationType> _categoryMap;
        private IClassificationType _comment;
        private IClassificationType _stringLiteral;
        private IClassificationType _keyword;
        private IClassificationType _operator;
        private IClassificationType _groupingClassification;
        private IClassificationType _dotClassification;
        private IClassificationType _commaClassification;
        private readonly IContentType _type;

        [ImportingConstructor]
        public JavaClassifierProvider(IContentTypeRegistryService contentTypeRegistryService)
        {
            _type = contentTypeRegistryService.GetContentType(JavaCoreConstants.ContentType);
        }

        /// <summary>
        /// Import the classification registry to be used for getting a reference
        /// to the custom classification type later.
        /// </summary>
        [Import]
        public IClassificationTypeRegistryService _classificationRegistry = null; // Set via MEF

        #region Java Classification Type Definitions

        [Export]
        [Name(JavaPredefinedClassificationTypeNames.Grouping)]
        [BaseDefinition(JavaPredefinedClassificationTypeNames.Operator)]
        internal static ClassificationTypeDefinition GroupingClassificationDefinition = null; // Set via MEF

        [Export]
        [Name(JavaPredefinedClassificationTypeNames.Dot)]
        [BaseDefinition(JavaPredefinedClassificationTypeNames.Operator)]
        internal static ClassificationTypeDefinition DotClassificationDefinition = null; // Set via MEF

        [Export]
        [Name(JavaPredefinedClassificationTypeNames.Comma)]
        [BaseDefinition(JavaPredefinedClassificationTypeNames.Operator)]
        internal static ClassificationTypeDefinition CommaClassificationDefinition = null; // Set via MEF

        [Export]
        [Name(JavaPredefinedClassificationTypeNames.Operator)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        internal static ClassificationTypeDefinition OperatorClassificationDefinition = null; // Set via MEF

        #endregion

        #region IDlrClassifierProvider

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            if (_categoryMap == null)
            {
                _categoryMap = FillCategoryMap(_classificationRegistry);
            }

            JavaClassifier res;
            if (!buffer.Properties.TryGetProperty<JavaClassifier>(typeof(JavaClassifier), out res) &&
                buffer.ContentType.IsOfType(ContentType.TypeName))
            {
                res = new JavaClassifier(this, buffer);
                buffer.Properties.AddProperty(typeof(JavaClassifier), res);
            }

            return res;
        }

        public virtual IContentType ContentType
        {
            get { return _type; }
        }

        public IClassificationType Comment
        {
            get { return _comment; }
        }

        public IClassificationType StringLiteral
        {
            get { return _stringLiteral; }
        }

        public IClassificationType Keyword
        {
            get { return _keyword; }
        }

        public IClassificationType Operator
        {
            get { return _operator; }
        }

        public IClassificationType GroupingClassification
        {
            get { return _groupingClassification; }
        }

        public IClassificationType DotClassification
        {
            get { return _dotClassification; }
        }

        public IClassificationType CommaClassification
        {
            get { return _commaClassification; }
        }

        #endregion

        internal Dictionary<TokenCategory, IClassificationType> CategoryMap
        {
            get { return _categoryMap; }
        }

        private Dictionary<TokenCategory, IClassificationType> FillCategoryMap(IClassificationTypeRegistryService registry)
        {
            var categoryMap = new Dictionary<TokenCategory, IClassificationType>();

            categoryMap[TokenCategory.DocComment] = _comment = registry.GetClassificationType(PredefinedClassificationTypeNames.Comment);
            categoryMap[TokenCategory.LineComment] = registry.GetClassificationType(PredefinedClassificationTypeNames.Comment);
            categoryMap[TokenCategory.Comment] = registry.GetClassificationType(PredefinedClassificationTypeNames.Comment);
            categoryMap[TokenCategory.NumericLiteral] = registry.GetClassificationType(PredefinedClassificationTypeNames.Literal);
            categoryMap[TokenCategory.CharacterLiteral] = registry.GetClassificationType(PredefinedClassificationTypeNames.Character);
            categoryMap[TokenCategory.StringLiteral] = _stringLiteral = registry.GetClassificationType(PredefinedClassificationTypeNames.String);
            categoryMap[TokenCategory.Keyword] = _keyword = registry.GetClassificationType(PredefinedClassificationTypeNames.Keyword);
            categoryMap[TokenCategory.Directive] = registry.GetClassificationType(PredefinedClassificationTypeNames.Keyword);
            categoryMap[TokenCategory.Identifier] = registry.GetClassificationType(PredefinedClassificationTypeNames.Identifier);
            categoryMap[TokenCategory.Operator] = _operator = registry.GetClassificationType(JavaPredefinedClassificationTypeNames.Operator);
            categoryMap[TokenCategory.Delimiter] = registry.GetClassificationType(JavaPredefinedClassificationTypeNames.Operator);
            categoryMap[TokenCategory.Grouping] = registry.GetClassificationType(JavaPredefinedClassificationTypeNames.Operator);
            categoryMap[TokenCategory.WhiteSpace] = registry.GetClassificationType(PredefinedClassificationTypeNames.WhiteSpace);
            categoryMap[TokenCategory.RegularExpressionLiteral] = registry.GetClassificationType(PredefinedClassificationTypeNames.Literal);
            _groupingClassification = registry.GetClassificationType(JavaPredefinedClassificationTypeNames.Grouping);
            _commaClassification = registry.GetClassificationType(JavaPredefinedClassificationTypeNames.Comma);
            _dotClassification = registry.GetClassificationType(JavaPredefinedClassificationTypeNames.Dot);

            return categoryMap;
        }
    }

    #region Editor Format Definitions

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = JavaPredefinedClassificationTypeNames.Operator)]
    [Name(JavaPredefinedClassificationTypeNames.Operator)]
    [DisplayName(JavaPredefinedClassificationTypeNames.Operator)]
    [UserVisible(true)]
    [Order(After = LanguagePriority.NaturalLanguage, Before = LanguagePriority.FormalLanguage)]
    internal sealed class OperatorFormat : ClassificationFormatDefinition
    {
        public OperatorFormat()
        {
            ForegroundColor = Color.FromRgb(0x00, 0x80, 0x80);
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = JavaPredefinedClassificationTypeNames.Grouping)]
    [Name(JavaPredefinedClassificationTypeNames.Grouping)]
    [DisplayName(JavaPredefinedClassificationTypeNames.Grouping)]
    [UserVisible(true)]
    [Order(After = LanguagePriority.NaturalLanguage, Before = LanguagePriority.FormalLanguage)]
    internal sealed class GroupingFormat : ClassificationFormatDefinition
    {
        public GroupingFormat()
        {
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = JavaPredefinedClassificationTypeNames.Comma)]
    [Name(JavaPredefinedClassificationTypeNames.Comma)]
    [DisplayName(JavaPredefinedClassificationTypeNames.Comma)]
    [UserVisible(true)]
    [Order(After = LanguagePriority.NaturalLanguage, Before = LanguagePriority.FormalLanguage)]
    internal sealed class CommaFormat : ClassificationFormatDefinition
    {
        public CommaFormat()
        {
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = JavaPredefinedClassificationTypeNames.Dot)]
    [Name(JavaPredefinedClassificationTypeNames.Dot)]
    [DisplayName(JavaPredefinedClassificationTypeNames.Dot)]
    [UserVisible(true)]
    [Order(After = LanguagePriority.NaturalLanguage, Before = LanguagePriority.FormalLanguage)]
    internal sealed class DotFormat : ClassificationFormatDefinition
    {
        public DotFormat()
        {
            ForegroundColor = Colors.Blue;
        }
    }

    #endregion
}
