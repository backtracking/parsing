using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;

namespace Java.EditorExtensions
{
    /// <summary>
    /// Exports the java content type and file extension
    /// </summary>
    public sealed class JavaContentTypeDefinition
    {
        public const string ContentType = "Java";

        /// <summary>
        /// Exports the java content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(JavaContentTypeDefinition.ContentType)]
        [BaseDefinition("code")]
        public ContentTypeDefinition IJavaContentType { get; set; }

        /// <summary>
        /// Exports the java file extension
        /// </summary>
		[Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType(JavaContentTypeDefinition.ContentType)]
        [FileExtension(".java")]
        public FileExtensionToContentTypeDefinition IJavaFileExtension { get; set; }
    }
}