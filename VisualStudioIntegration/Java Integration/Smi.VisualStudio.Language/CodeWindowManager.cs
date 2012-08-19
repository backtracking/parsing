namespace Smi.VisualStudio.Language
{
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.TextManager.Interop;
    using System;
    using System.Diagnostics.Contracts;
    using System.Runtime.InteropServices;
    using Smi.Events;

    public class CodeWindowManager : IVsCodeWindowManager
    {
        private readonly IVsCodeWindow _codeWindow;
        private IVsDropdownBarClient _dropdownBarClient;
        private readonly Smi.VisualStudio.Language.LanguagePreferences _languagePreferences;
        private readonly SVsServiceProvider _serviceProvider;

        public CodeWindowManager(IVsCodeWindow codeWindow, SVsServiceProvider serviceProvider, Smi.VisualStudio.Language.LanguagePreferences languagePreferences)
        {
            //System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(codeWindow != null, "codeWindow");
            //System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            //System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(languagePreferences != null, "languagePreferences");
            Action<EventHandler> unregister = null;
            this._codeWindow = codeWindow;
            this._serviceProvider = serviceProvider;
            this._languagePreferences = languagePreferences;
            if (unregister == null)
            {
                unregister = delegate (EventHandler handler) {
                    this._languagePreferences.PreferencesChanged -= handler;
                };
            }
            this._languagePreferences.PreferencesChanged += WeakEvents.AsWeak(new EventHandler(this.HandleLanguagePreferencesChanged), unregister);
        }

        public virtual int AddAdornments()
        {
            IVsTextView view;
            int num = 0;
            IVsDropdownBarClient client = null;
            
            if (ErrorHandler.Succeeded(this.CodeWindow.GetPrimaryView(out view)) && (view != null))
            {
                ErrorHandler.ThrowOnFailure(this.OnNewView(view));
            }
            if (ErrorHandler.Succeeded(this.CodeWindow.GetSecondaryView(out view)) && (view != null))
            {
                ErrorHandler.ThrowOnFailure(this.OnNewView(view));
            }
            if (this.LanguagePreferences.ShowDropdownBar && this.TryCreateDropdownBarClient(out num, out client))
            {
                ErrorHandler.ThrowOnFailure(this.AddDropdownBar(num, client));
                this._dropdownBarClient = client;
            }
            return 0;
        }

        protected virtual int AddDropdownBar(int comboBoxCount, IVsDropdownBarClient client)
        {
            IVsDropdownBar bar;
            System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(client != null, "client");
            IVsDropdownBarManager codeWindow = this.CodeWindow as IVsDropdownBarManager;
            if (codeWindow == null)
            {
                throw new NotSupportedException();
            }
            if (ErrorHandler.Succeeded(codeWindow.GetDropdownBar(out bar)) && (bar != null))
            {
                int hr = codeWindow.RemoveDropdownBar();
                if (ErrorHandler.Failed(hr))
                {
                    return hr;
                }
            }
            return codeWindow.AddDropdownBar(comboBoxCount, client);
        }

        protected virtual void HandleLanguagePreferencesChanged(object sender, EventArgs e)
        {
            int num = 0;
            IVsDropdownBarClient client = null;

            //System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(e != null, "e");
            if (((this._dropdownBarClient == null) && this.LanguagePreferences.ShowDropdownBar) && this.TryCreateDropdownBarClient(out num, out client))
            {
                ErrorHandler.ThrowOnFailure(this.AddDropdownBar(num, client));
                this._dropdownBarClient = client;
            }
            else if ((this._dropdownBarClient != null) && !this.LanguagePreferences.ShowDropdownBar)
            {
                ErrorHandler.ThrowOnFailure(this.RemoveDropdownBar());
            }
        }

        int IVsCodeWindowManager.OnNewView(IVsTextView pView)
        {
            if (pView == null)
            {
                throw new ArgumentNullException("pView");
            }
            return this.OnNewView(pView);
        }

        public virtual int OnNewView(IVsTextView view)
        {
            System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(view != null, "view");
            return 0;
        }

        public virtual int RemoveAdornments()
        {
            return this.RemoveDropdownBar();
        }

        protected virtual int RemoveDropdownBar()
        {
            IVsDropdownBar bar;
            IVsDropdownBarClient client;
            IVsDropdownBarManager codeWindow = this.CodeWindow as IVsDropdownBarManager;
            if (codeWindow == null)
            {
                return -2147467259;
            }
            if ((ErrorHandler.Succeeded(codeWindow.GetDropdownBar(out bar)) && (bar != null)) && (ErrorHandler.Succeeded(bar.GetClient(out client)) && (client == this._dropdownBarClient)))
            {
                this._dropdownBarClient = null;
                return codeWindow.RemoveDropdownBar();
            }
            this._dropdownBarClient = null;
            return 0;
        }

        protected virtual bool TryCreateDropdownBarClient(out int comboBoxCount, out IVsDropdownBarClient client)
        {
            comboBoxCount = 0;
            client = null;
            return false;
        }

        public IVsCodeWindow CodeWindow
        {
            get
            {
                return this._codeWindow;
            }
        }

        public Smi.VisualStudio.Language.LanguagePreferences LanguagePreferences
        {
            get
            {
                return this._languagePreferences;
            }
        }

        public SVsServiceProvider ServiceProvider
        {
            get
            {
                return this._serviceProvider;
            }
        }
    }
}

