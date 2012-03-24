using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Java.EditorExtensions
{

    /// <summary>
    /// Defines the classification type names
    /// </summary>
    internal class JavaClassificationTypes
    {
        internal const string ReadOnlyRegion = "JavaReadOnlyRegion";
        internal const string Comment = "JavaComment";
        internal const string Delimiter = "JavaDelimiter";
        internal const string Operator = "JavaOperator";
        internal const string Keyword = "JavaKeyword";
        internal const string Identifier = "JavaIdentifier";
        internal const string String = "JavaString";
        internal const string Number = "JavaNumber";
        internal const string Unknown = "JavaUnknown";
    }
}
