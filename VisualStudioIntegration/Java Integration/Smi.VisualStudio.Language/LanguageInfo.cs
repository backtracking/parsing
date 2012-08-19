namespace Smi.VisualStudio.Language
{
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.ComponentModelHost;
    using Microsoft.VisualStudio.Editor;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.TextManager.Interop;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Runtime.InteropServices;
    using Smi.VisualStudio.Shell.Extensions;

    public abstract class LanguageInfo : IVsLanguageInfo, IDisposable
    {
        private readonly Guid _languageGuid;
        private Smi.VisualStudio.Language.LanguagePreferences _languagePreferences;
        private IDisposable _languagePreferencesCookie;
        private readonly SVsServiceProvider _serviceProvider;

        public LanguageInfo(SVsServiceProvider serviceProvider, Guid languageGuid)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }
            this._serviceProvider = serviceProvider;
            this._languageGuid = languageGuid;
            IVsTextManager2 manager = serviceProvider.GetTextManager2();
            LANGPREFERENCES2[] pLangPrefs = new LANGPREFERENCES2[1];
            pLangPrefs[0].guidLang = languageGuid;
            ErrorHandler.ThrowOnFailure(manager.GetUserPreferences2(null, null, pLangPrefs, null));
            this._languagePreferences = this.CreateLanguagePreferences(pLangPrefs[0]);
            this._languagePreferencesCookie = ((IConnectionPointContainer) manager).Advise<Smi.VisualStudio.Language.LanguagePreferences, IVsTextManagerEvents2>(this._languagePreferences);
        }

        protected virtual LanguagePreferences CreateLanguagePreferences(LANGPREFERENCES2 preferences)
        {
            return new Smi.VisualStudio.Language.LanguagePreferences(preferences);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (this._languagePreferencesCookie != null))
            {
                this._languagePreferencesCookie.Dispose();
                this._languagePreferencesCookie = null;
            }
        }


        protected virtual IVsCodeWindowManager GetCodeWindowManager(IVsCodeWindow codeWindow, ITextBuffer textBuffer)
        {
            //System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(codeWindow != null, "codeWindow");
            //System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(textBuffer != null, "textBuffer");
            return textBuffer.Properties.GetOrCreateSingletonProperty<CodeWindowManager>(() => new CodeWindowManager(codeWindow, this.ServiceProvider, this.LanguagePreferences));
        }

        int IVsLanguageInfo.GetCodeWindowManager(IVsCodeWindow pCodeWin, out IVsCodeWindowManager ppCodeWinMgr)
        {
            IVsTextLines lines;
            IVsEditorAdaptersFactoryService service = this.ComponentModel.GetService<IVsEditorAdaptersFactoryService>();
            ErrorHandler.ThrowOnFailure(pCodeWin.GetBuffer(out lines));
            IVsTextBuffer bufferAdapter = lines;
            ITextBuffer dataBuffer = service.GetDataBuffer(bufferAdapter);
            if (dataBuffer == null)
            {
                ppCodeWinMgr = null;
                return -2147467259;
            }
            ppCodeWinMgr = this.GetCodeWindowManager(pCodeWin, dataBuffer);
            return 0;
        }

        public virtual int GetColorizer(IVsTextLines buffer, out IVsColorizer colorizer)
        {
            colorizer = null;
            return -2147467259;
        }

        int IVsLanguageInfo.GetColorizer(IVsTextLines buffer, out IVsColorizer colorizer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            return this.GetColorizer(buffer, out colorizer);
        }

        int IVsLanguageInfo.GetFileExtensions(out string pbstrExtensions)
        {
            pbstrExtensions = string.Join(";", this.FileExtensions);
            return 0;
        }

        int IVsLanguageInfo.GetLanguageName(out string bstrName)
        {
            bstrName = this.LanguageName;
            if (!string.IsNullOrEmpty(bstrName))
            {
                return 0;
            }
            return -2147467259;
        }

        protected IComponentModel ComponentModel
        {
            get
            {
                return this._serviceProvider.GetComponentModel();
            }
        }

        public abstract IEnumerable<string> FileExtensions { get; }

        public Guid LanguageGuid
        {
            get
            {
                return this._languageGuid;
            }
        }

        public abstract string LanguageName { get; }

        public Smi.VisualStudio.Language.LanguagePreferences LanguagePreferences
        {
            get
            {
                return this._languagePreferences;
            }
        }

        protected SVsServiceProvider ServiceProvider
        {
            get
            {
                return this._serviceProvider;
            }
        }
    }
}

