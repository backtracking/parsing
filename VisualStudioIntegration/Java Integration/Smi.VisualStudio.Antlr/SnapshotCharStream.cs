using Antlr.Runtime;
using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Smi.VisualStudio.Antlr
{
    public class SnapshotCharStream : ICharStream, IIntStream
    {
        private string _currentSnapshotLine;
        private int _currentSnapshotLineStartIndex;
        private bool _explicitCache;
        private int _lastMarker;
        private int _markDepth;
        private List<CharStreamState> _markers;

        public int CharPositionInLine { get; set; }

        public int Count { get { return this.Snapshot.Length; } }

        public int Index { get; private set; }

        public int Line { get; set; }

        public ITextSnapshot Snapshot { get; private set; }

        public string SourceName { get { return "Snapshot"; } }

        public SnapshotCharStream(ITextSnapshot snapshot)
        {
            //System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(snapshot != null, "snapshot");
            this.Snapshot = snapshot;
            this.UpdateCachedLine();
        }

        public SnapshotCharStream(ITextSnapshot snapshot, Span cachedSpan)
        {
            //System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(snapshot != null, "snapshot");
            this.Snapshot = snapshot;
            this._explicitCache = true;
            this._currentSnapshotLineStartIndex = cachedSpan.Start;
            this._currentSnapshotLine = snapshot.GetText(cachedSpan);
        }

        public virtual void Consume()
        {
            int num = this.LA(1);
            if (num >= 0)
            {
                if (num == 10)
                {
                    this.Line++;
                    this.CharPositionInLine = 0;
                }
                else
                {
                    this.CharPositionInLine++;
                }
                this.Index++;
                this.UpdateCachedLine();
            }
        }

        public virtual int LA(int i)
        {
            if (i == 0)
            {
                return 0;
            }
            if (i < 0)
            {
                i++;
                if (((this.Index + i) - 1) < 0)
                {
                    return -1;
                }
            }
            if (((this.Index + i) - 1) >= this.Count)
            {
                return -1;
            }
            int startIndex = (this.Index + i) - 1;
            if (((this._currentSnapshotLine != null) && (startIndex >= this._currentSnapshotLineStartIndex)) && (startIndex < (this._currentSnapshotLineStartIndex + this._currentSnapshotLine.Length)))
            {
                return this._currentSnapshotLine[startIndex - this._currentSnapshotLineStartIndex];
            }
            return this.Snapshot.GetText(startIndex, 1)[0];
        }

        public int LT(int i)
        {
            return this.LA(i);
        }

        public int Mark()
        {
            if (this._markers == null)
            {
                this._markers = new List<CharStreamState>();
                this._markers.Add(null);
            }
            this._markDepth++;
            CharStreamState item = null;
            if (this._markDepth >= this._markers.Count)
            {
                item = new CharStreamState();
                this._markers.Add(item);
            }
            else
            {
                item = this._markers[this._markDepth];
            }
            item.p = this.Index;
            item.line = this.Line;
            item.charPositionInLine = this.CharPositionInLine;
            this._lastMarker = this._markDepth;
            return this._markDepth;
        }

        public void Release(int marker)
        {
            this._markDepth = marker;
            this._markDepth--;
        }

        public void Rewind()
        {
            this.Rewind(this._lastMarker);
        }

        public void Rewind(int marker)
        {
            CharStreamState state = this._markers[marker];
            this.Index = state.p;
            this.Line = state.line;
            this.CharPositionInLine = state.charPositionInLine;
            this.Release(marker);
            this.UpdateCachedLine();
        }

        public void Seek(int index)
        {
            if (index != this.Index)
            {
                this.Index = index;
                ITextSnapshotLine lineFromPosition = this.Snapshot.GetLineFromPosition(this.Index);
                this.Line = lineFromPosition.LineNumber;
                this.CharPositionInLine = this.Index - lineFromPosition.Start.Position;
                this.UpdateCachedLine();
            }
        }

        public string Substring(int startIndex, int length)
        {
            return this.Snapshot.GetText(startIndex, length);
        }

        private void UpdateCachedLine()
        {
            if (!this._explicitCache && (((this._currentSnapshotLine == null) || (this.Index < this._currentSnapshotLineStartIndex)) || (this.Index >= (this._currentSnapshotLineStartIndex + this._currentSnapshotLine.Length))))
            {
                if ((this.Index >= 0) || (this.Index < this.Count))
                {
                    ITextSnapshotLine lineFromPosition = this.Snapshot.GetLineFromPosition(this.Index);
                    this._currentSnapshotLineStartIndex = (int)lineFromPosition.Start;
                    this._currentSnapshotLine = lineFromPosition.GetTextIncludingLineBreak();
                }
                else
                {
                    this._currentSnapshotLine = null;
                    this._currentSnapshotLineStartIndex = 0;
                }
            }
        }

        
    }
}

