using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using System.Text.RegularExpressions;
using Smartmobili.JavaTools.Editor.Core;
using Smartmobili.VisualStudio.Core;

namespace Java.EditorExtensions
{

    internal class TextRange
    {
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public TextRange() 
        {}

        public TextRange(int startIndex, int endIndex) 
        {
            this.StartIndex = startIndex;
            this.EndIndex = endIndex;
        }
    }

    internal class TextRangeList : List<TextRange>
    {
        public bool Belongs(int startIndex)
        {
            TextRange textRange = this.Find(delegate(TextRange t) 
            {
                return startIndex >= t.StartIndex && startIndex < t.EndIndex; 
            }) ;

            return textRange != null;
        }
    }


    /// <summary>
    /// Implements <see cref="IClassifier"/> in order to provide coloring
    /// </summary>
    internal class JavaClassifier : IClassifier
    {
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        private IClassificationTypeRegistryService classificationRegistryService;
        private ITextBuffer textBuffer;

        private TextRangeList _commentRanges = new TextRangeList();

        private SourceItem _srcItem;
        //private JavaParser _parser;
        //private List<> _toto;
        

        internal JavaClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService)
        {
            this.textBuffer = textBuffer;
            this.classificationRegistryService = classificationRegistryService;

            //ITextSnapshot curSnapshot = textBuffer.CurrentSnapshot;
            //SnapshotSpan entireSnapSpan = Smartmobili.JavaTools.Editor.Core.EditorExtensions.CreateEntireBufferSnapshotSpan(textBuffer);
            //var entireBuffer = entireSnapSpan.GetText();
            _srcItem = SourceAnalyzer.Instance.AddItem(textBuffer);
            //_srcItem = SourceAnalyzer.Instance.AddItem(textBuffer.GetFileName(), entireBuffer, curSnapshot.Length, curSnapshot.LineCount);

            

            this.textBuffer.Changed += new EventHandler<TextContentChangedEventArgs>(textBuffer_TextContentChanged);
            this.textBuffer.ReadOnlyRegionsChanged += new EventHandler<SnapshotSpanEventArgs>(textBuffer_ReadOnlyRegionsChanged);
        }

        public void PrintTree(CommonTree t, int indent)
        {
            if (t != null)
            {

                StringBuilder sb = new StringBuilder(indent);

                for (int i = 0; i < indent; i++)
                    sb = sb.Append("   ");

                for (int i = 0; i < t.ChildCount; i++)
                {
                    ITree curNode = t.GetChild(i);
                    int curLine = curNode.Line;
                    string nodeText = string.Format("{0}({1},{2})", curNode.ToString(), curLine, curNode.CharPositionInLine);
                    System.Diagnostics.Debug.WriteLine(sb.ToString() + nodeText);
                    
                    PrintTree((CommonTree)t.GetChild(i), indent + 1);
                }
            }
        }


        
        void textBuffer_TextContentChanged(object sender, TextContentChangedEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine("textBuffer_TextContentChanged");
            //Microsoft.VisualStudio.Text.Implementation.TextBuffer textBuffer = sender as TextBuffer;
            _srcItem.Changed(e);
        }

        void textBuffer_ReadOnlyRegionsChanged(object sender, SnapshotSpanEventArgs e)
        {
            // We need to call this event when read-only regions are added, so they will be grayed out.
            OnClassificationChanged(new SnapshotSpan(textBuffer.CurrentSnapshot, e.Span));
        }

        private void OnClassificationChanged(SnapshotSpan changeSpan)
        {
            if (ClassificationChanged != null)
            {
                ClassificationChanged(this, new ClassificationChangedEventArgs(changeSpan));
            }
        }



        IList<ClassificationSpan> IClassifier.GetClassificationSpans(SnapshotSpan span)
        {
            var textSnapshot = span.Snapshot;
            var classifications = new List<ClassificationSpan>();
            System.Diagnostics.Debug.Write(span.GetText());

            try
            {
                //SourceItem srcItem = SourceAnalyzer.Instance.GetItem(textBuffer.GetFileName());
                if (_srcItem != null)
                {
                    IClassificationType classType = null;
                    int line = span.Snapshot.GetLineFromLineNumber(span.Start.GetContainingLine().LineNumber).LineNumber;
                    var tokenLines = _srcItem.TokenLines[line];
                    foreach (var token in tokenLines.Tokens)
                    {
                        int startIndex = token.StartPosition;
                        int length = token.EndPosition - token.StartPosition + 1;
                        classType = GetClassificationType(token);
                        classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, startIndex, length), classType));
                    }

                    // Add classfication for read only regions
                    foreach (var region in span.Snapshot.TextBuffer.GetReadOnlyExtents(span))
                    {
                        classType = classificationRegistryService.GetClassificationType(JavaClassificationTypes.ReadOnlyRegion);
                        classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, region), classType));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception");
            }

            return classifications;
        }

        private IClassificationType GetClassificationType(Token2 token)
        {
            return classificationRegistryService.GetClassificationType(token.ClassificationTypeKey);
        }


        
    }
}
