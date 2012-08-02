/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * contact@smartmobili.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;

namespace Java.EditorExtensions
{
    internal static class JavaCoreConstants {
        public const string ContentType = "Java";
        public const string BaseRegistryKey = "JavaTools";
        
        [Export, Name(ContentType), BaseDefinition("code")]
        internal static ContentTypeDefinition ContentTypeDefinition = null;

        internal static bool IsJavaContent(ITextBuffer buffer) {
            return buffer.ContentType.IsOfType(JavaCoreConstants.ContentType);
        }

        internal static bool IsJavaContent(ITextSnapshot buffer) {
            return buffer.ContentType.IsOfType(JavaCoreConstants.ContentType);
        }

        [Export]
        [FileExtension(".java")]
        [ContentType(JavaCoreConstants.ContentType)]
        internal static FileExtensionToContentTypeDefinition JavaFileType = null;
    }
}
