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

namespace Java.EditorExtensions
{
    /// <summary>
    /// Specifies the version of the Java language to be used for parsing.
    /// </summary>
    public enum JavaLanguageVersion {
        None = 0,
        V15 = 0x0105,
        V16 = 0x0106
    }

    public static class JavaLanguageVersionExtensions
    {
        public static bool Is2x(this JavaLanguageVersion version)
        {
            return (((int)version >> 8) & 0xff) == 2;
        }

        public static bool Is3x(this JavaLanguageVersion version)
        {
            return (((int)version >> 8) & 0xff) == 3;
        }
    }
}
