namespace Smi.VisualStudio.Language.Java
{
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using Smi.VisualStudio.Language;

    [Guid("54098E6C-FC60-47F9-9621-0298FDB102EA")]
    internal class JavaLanguageInfo : LanguageInfo
    {
        public JavaLanguageInfo(SVsServiceProvider serviceProvider) : base(serviceProvider, typeof(JavaLanguageInfo).GUID)
        {
        }

        public override IEnumerable<string> FileExtensions
        {
            get
            {
                yield return ".java";
            }
        }

        public override string LanguageName
        {
            get
            {
                return "Java";
            }
        }

    }
}

