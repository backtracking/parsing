using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Smartmobili.VisualStudio.Core;

namespace Java.EditorExtensions
{
    public class SourceAnalyzer
    {
        Dictionary<string, SourceItem> _sources = new Dictionary<string, SourceItem>();

        public static SourceAnalyzer Instance
        {
            get
            {
                return Singleton<SourceAnalyzer>.Instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="entireBuffer"></param>
        public SourceItem AddItem(string filepath, string entireBuffer, int length, int linecount)
        {
            SourceItem srcItem = null;

            if (string.IsNullOrEmpty(filepath))
                return null;

            // If entireBuffer is null we read file and fill the buffer
            if (string.IsNullOrEmpty(entireBuffer))
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    entireBuffer = sr.ReadToEnd();
                }
            }

            if (!_sources.ContainsKey(filepath))
            {
                srcItem = new SourceItem(entireBuffer, length, linecount);
                _sources.Add(filepath, srcItem);
                
                //StartLexicalAnalysis();
            }

            return srcItem;
        }

        public SourceItem GetItem(string filepath)
        {
            SourceItem srcItem = null;

            if (_sources.ContainsKey(filepath))
            {
                srcItem = _sources[filepath];
            }

            return srcItem;
        }



        


    }
}
