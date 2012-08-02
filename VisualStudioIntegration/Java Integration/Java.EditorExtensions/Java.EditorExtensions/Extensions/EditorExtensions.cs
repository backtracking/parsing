/* ****************************************************************************
 *
 * Copyright (c) Smartmobili SARL. 
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

using System;
using System.Diagnostics;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Smartmobili.JavaTools;

namespace Smartmobili.JavaTools.Editor.Core
{
    public static class EditorExtensions
    {
        public static SnapshotSpan CreateEntireBufferSnapshotSpan(this ITextBuffer textBuffer)
        {
            //Argument.ThrowIfNull(textBuffer, "textBuffer");
            return textBuffer.CurrentSnapshot.CreateEntireBufferSnapshotSpan();
        }

        public static SnapshotSpan CreateEntireBufferSnapshotSpan(this ITextSnapshot snapshot)
        {
            //Argument.ThrowIfNull(snapshot, "snapshot");
            return new SnapshotSpan(snapshot, 0, snapshot.Length);
        }
    }
}
