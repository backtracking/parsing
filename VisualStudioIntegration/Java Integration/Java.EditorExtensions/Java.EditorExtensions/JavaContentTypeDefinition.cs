using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;

namespace Java.EditorExtensions
{
    /// <summary>
    /// Exports the iron python content type and file extension
    /// </summary>
    public sealed class JavaContentTypeDefinition
    {
        public const string ContentType = "IronJava";
        public const string ConsoleContentType = "IronJavaConsole";

        /// <summary>
        /// Exports the IPy content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(JavaContentTypeDefinition.ContentType)]
        [BaseDefinition("code")]
        public ContentTypeDefinition IJavaContentType { get; set; }

        /// <summary>
        /// Exports the IPy Console content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(JavaContentTypeDefinition.ConsoleContentType)]
        [BaseDefinition("code")]
        public ContentTypeDefinition IJavaContentTypeConsole { get; set; }

        /// <summary>
        /// Exports the IPy file extension
        /// </summary>
		[Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType(JavaContentTypeDefinition.ContentType)]
        [FileExtension(".java")]
        public FileExtensionToContentTypeDefinition IJavaFileExtension { get; set; }
    }
}