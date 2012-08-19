namespace Smi.VisualStudio.Language
{
    using Microsoft.VisualStudio.TextManager.Interop;
    using System;
    using System.Linq;
    using System.Threading;

    public class LanguagePreferences : IVsTextManagerEvents2
    {
        private LANGPREFERENCES2 _preferences;

        public event EventHandler PreferencesChanged;

        public LanguagePreferences(LANGPREFERENCES2 preferences)
        {
            this._preferences = preferences;
        }

        int IVsTextManagerEvents2.OnRegisterMarkerType(int iMarkerType)
        {
            return 0;
        }

        int IVsTextManagerEvents2.OnRegisterView(IVsTextView pView)
        {
            return 0;
        }

        int IVsTextManagerEvents2.OnReplaceAllInFilesBegin()
        {
            return 0;
        }

        int IVsTextManagerEvents2.OnReplaceAllInFilesEnd()
        {
            return 0;
        }

        int IVsTextManagerEvents2.OnUnregisterView(IVsTextView pView)
        {
            return 0;
        }

        int IVsTextManagerEvents2.OnUserPreferencesChanged2(VIEWPREFERENCES2[] pViewPrefs, FRAMEPREFERENCES2[] pFramePrefs, LANGPREFERENCES2[] pLangPrefs, FONTCOLORPREFERENCES2[] pColorPrefs)
        {
            Func<LANGPREFERENCES2, bool> predicate = null;
            if (pLangPrefs != null)
            {
                if (predicate == null)
                {
                    predicate = i => i.guidLang == this._preferences.guidLang;
                }
                LANGPREFERENCES2[] langpreferencesArray = pLangPrefs.Where<LANGPREFERENCES2>(predicate).ToArray<LANGPREFERENCES2>();
                if (langpreferencesArray.Length > 0)
                {
                    this._preferences = langpreferencesArray[0];
                }
            }
            return 0;
        }

        protected virtual void OnPreferencesChanged(EventArgs e)
        {
            EventHandler preferencesChanged = this.PreferencesChanged;
            if (preferencesChanged != null)
            {
                preferencesChanged(this, e);
            }
        }

        public LANGPREFERENCES2 RawPreferences
        {
            get
            {
                return this._preferences;
            }
        }

        public bool ShowDropdownBar
        {
            get
            {
                return (this._preferences.fDropdownBar != 0);
            }
        }
    }
}

