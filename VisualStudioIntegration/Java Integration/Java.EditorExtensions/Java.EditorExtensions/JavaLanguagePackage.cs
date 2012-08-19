namespace Smi.VisualStudio.Language.Java
{
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.ComponentModel.Design;
    using System.Runtime.InteropServices;


    [ProvideLanguageExtension(typeof(JavaLanguageInfo), ".java"), 
    ProvideLanguageService(typeof(JavaLanguageInfo), "Java", 100, ShowCompletion=true, ShowDropDownOptions=true, EnableAdvancedMembersOption=false, DefaultToInsertSpaces=false, EnableLineNumbers=true, RequestStockColors=true), 
    PackageRegistration(UseManagedResourcesOnly=true), 
    InstalledProductRegistration("#110", "#111", "1.0"), 
    Guid("1782E1AA-0FBD-4982-B6A8-A1110D95CA57")]
    public class JavaLanguagePackage : Package
    {
        private static JavaLanguagePackage _instance;

        public JavaLanguagePackage()
        {
            _instance = this;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
    }
}

