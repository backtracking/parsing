namespace Smi.VisualStudio.Language.Java
{
    using System;
    using System.ComponentModel.Design;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#111", "1.0")]
    //[ProvideAutoLoad(CommonConstants.UIContextNoSolution)]
    //[ProvideAutoLoad(CommonConstants.UIContextSolutionExists)]
    [Guid("1782E1AA-0FBD-4982-B6A8-A1110D95CA57")]
    [ProvideLanguageService(typeof(JavaLanguageInfo), "Java", 100, 
        ShowCompletion=true, 
        ShowDropDownOptions=true, 
        EnableAdvancedMembersOption=false, 
        DefaultToInsertSpaces=false, 
        EnableLineNumbers=true, 
        RequestStockColors=true)]
    [ProvideLanguageExtension(typeof(JavaLanguageInfo), ".java")]
    public sealed class JavaLanguagePackage : Package, IVsInstalledProduct
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

        #region IVsInstalledProduct Members
        /// <summary>
        /// This method is called during Devenv /Setup to get the bitmap to
        /// display on the splash screen for this package.
        /// </summary>
        /// <param name="pIdBmp">The resource id corresponding to the bitmap to display on the splash screen</param>
        /// <returns>HRESULT, indicating success or failure</returns>
        public int IdBmpSplash(out uint pIdBmp)
        {
            pIdBmp = 300;

            return VSConstants.S_FALSE;
        }

        /// <summary>
        /// This method is called to get the icon that will be displayed in the
        /// Help About dialog when this package is selected.
        /// </summary>
        /// <param name="pIdIco">The resource id corresponding to the icon to display on the Help About dialog</param>
        /// <returns>HRESULT, indicating success or failure</returns>
        public int IdIcoLogoForAboutbox(out uint pIdIco)
        {
            pIdIco = 400;

            return VSConstants.S_FALSE;
        }

        /// <summary>
        /// This methods provides the product official name, it will be
        /// displayed in the help about dialog.
        /// </summary>
        /// <param name="pbstrName">Out parameter to which to assign the product name</param>
        /// <returns>HRESULT, indicating success or failure</returns>
        public int OfficialName(out string pbstrName)
        {
            //pbstrName = GetResourceString("@ProductName");
            pbstrName = "@ProductName";
            return VSConstants.S_FALSE;
        }

        /// <summary>
        /// This methods provides the product description, it will be
        /// displayed in the help about dialog.
        /// </summary>
        /// <param name="pbstrProductDetails">Out parameter to which to assign the description of the package</param>
        /// <returns>HRESULT, indicating success or failure</returns>
        public int ProductDetails(out string pbstrProductDetails)
        {
            //pbstrProductDetails = GetResourceString("@ProductDetails");
            pbstrProductDetails = "@ProductDetails";
            return VSConstants.S_FALSE;
        }

        /// <summary>
        /// This methods provides the product version, it will be
        /// displayed in the help about dialog.
        /// </summary>
        /// <param name="pbstrPID">Out parameter to which to assign the version number</param>
        /// <returns>HRESULT, indicating success or failure</returns>
        public int ProductID(out string pbstrPID)
        {
            //pbstrPID = GetResourceString("@ProductID");
            pbstrPID = "@ProductID";
            return VSConstants.S_FALSE;
        }

        #endregion

    }
}

