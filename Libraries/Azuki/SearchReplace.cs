/* ------------------------------------------------------------------------- */
///
/// SearchReplace.cs
/// 
/// Copyright (c) 2010 CubeSoft, Inc.
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///  http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
///
/* ------------------------------------------------------------------------- */
using System;
using System.ComponentModel;
using System.Threading;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Sgry.Azuki;
using Sgry.Azuki.Highlighter;

namespace Cube.Note.Azuki
{
    /* --------------------------------------------------------------------- */
    ///
    /// SearchReplace
    /// 
    /// <summary>
    /// テキストの検索および置換を行うためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class SearchReplace : INotifyPropertyChanged
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// SearchReplace
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SearchReplace(PageCollection pages)
        {
            Pages = pages;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// MaxAbstractLength
        /// 
        /// <summary>
        /// Abstract の最大長を取得または設定します。
        /// </summary>
        /// 
        /// <remarks>
        /// 置換後 Page オブジェクトを編集する際に使用します。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        public int MaxAbstractLength { get; set; } = 100;

        /* ----------------------------------------------------------------- */
        ///
        /// Keyword
        /// 
        /// <summary>
        /// 検索キーワードを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string Keyword { get; private set; }

        /* ----------------------------------------------------------------- */
        ///
        /// CaseSensitive
        /// 
        /// <summary>
        /// 大文字・小文字を区別するかどうかを示す値を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public bool CaseSensitive { get; private set; }

        /* ----------------------------------------------------------------- */
        ///
        /// Pages
        /// 
        /// <summary>
        /// 検索の対象となる PageCollection オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageCollection Pages { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// Results
        /// 
        /// <summary>
        /// 検索結果を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ObservableCollection<Page> Results { get; }
            = new ObservableCollection<Page>();

        /* ----------------------------------------------------------------- */
        ///
        /// Current
        /// 
        /// <summary>
        /// 検索結果中の現在位置を示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int Current
        {
            get { return _current; }
            set
            {
                if (_current == value) return;
                _current = value;
                RaisePropertyChanged(nameof(Current));
            }
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// PositionChanged
        /// 
        /// <summary>
        /// Current プロパティの内容が変化した時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Reset
        /// 
        /// <summary>
        /// 検索結果をリセットします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Reset()
        {
            foreach (var page in Results) UnHighlight(page);
            Results.Clear();
            Current = -1;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Search
        /// 
        /// <summary>
        /// 単一ページを対象に検索を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Search(string keyword, bool sensitive, Page page)
        {
            Reset();
            Keyword = keyword;
            CaseSensitive = sensitive;

            var result = FindFirst(page, keyword, sensitive);
            if (result == null) return;

            Highlight(page, keyword, sensitive);
            Results.Add(page);
            Current = 0;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Search
        /// 
        /// <summary>
        /// 指定された範囲を対象に検索を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Search(string keyword, bool sensitive, Tag range)
        {
            Reset();
            Keyword = keyword;
            CaseSensitive = sensitive;

            foreach(var page in Pages.Search(range))
            {
                var result = FindFirst(page, keyword, sensitive);
                if (result == null) continue;

                Highlight(page, keyword, sensitive);
                Results.Add(page);
            }

            if (Results.Count > 0) Current = 0;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Forward
        /// 
        /// <summary>
        /// 次の検索結果を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Forward()
        {
            if (Results.Count <= 0) return;

            var index = Current != -1 ?
                        Math.Max(Math.Min(Current, Results.Count - 1), 0) :
                        0;
            var start = Current != -1 ? default(int?) : 0;

            Forward(index, start);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Back
        /// 
        /// <summary>
        /// 前の検索結果を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Back()
        {
            if (Results.Count <= 0) return;

            var index = Current != -1 ?
                        Math.Max(Math.Min(Current, Results.Count - 1), 0) :
                        Results.Count - 1;
            var start = Current != -1 ? default(int?) : -1;

            Back(index, start);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Replace
        /// 
        /// <summary>
        /// 次の検索結果を置換します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Replace(string replaced)
        {
            if (Results.Count <= 0) return;

            var index = Current != -1 ?
                        Math.Max(Math.Min(Current, Results.Count - 1), 0) :
                        0;
            var start = Current != -1 ? default(int?) : 0;

            ReplaceNext(index, start, replaced);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ReplaceAll
        /// 
        /// <summary>
        /// 全ての検索結果を置換します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int ReplaceAll(string replaced)
        {
            var dest   = 0;
            var index  = 0;
            var offset = 0;

            while (index < Results.Count)
            {
                var document = Results[index].Document as Document;
                if (document == null) continue;

                var result = document.FindNext(Keyword, offset, CaseSensitive);
                if (result != null)
                {
                    Replace(index, replaced, result.Begin, result.End);
                    ++dest;
                }
                else
                {
                    ++index;
                    offset = 0;
                }
            }

            return dest;
        }

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnCurrentChanged
        ///
        /// <summary>
        /// CurrentChanged イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            => PropertyChanged?.Invoke(this, e);

        #endregion

        #region Non-virtual protected methods

        /* ----------------------------------------------------------------- */
        ///
        /// RaisePropertyChanged
        ///
        /// <summary>
        /// PropertyChanged イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
            => OnPropertyChanged(new PropertyChangedEventArgs(name));

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// FindFirst
        /// 
        /// <summary>
        /// 最初の検索結果を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private SearchResult FindFirst(Page page, string keyword, bool sensitive)
            => page?.CreateDocument(Pages.Directory)
                   ?.FindNext(keyword, 0, sensitive);

        /* ----------------------------------------------------------------- */
        ///
        /// GetOffset
        /// 
        /// <summary>
        /// Document オブジェクト内の位置を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// offset が 0 以上の場合はそのままの値、負の値の場合は末尾から
        /// offset + 1 の値を減じた値が返ります（-1 が末尾を表す）。
        /// offset が null の場合はキャレット位置が返ります。
        /// </returns>
        ///
        /* ----------------------------------------------------------------- */
        private int GetOffset(Document document, int? offset)
        {
            return !offset.HasValue ? document.CaretIndex :
                    offset.Value >= 0 ? offset.Value :
                    document.Length + (offset.Value + 1);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Forward
        /// 
        /// <summary>
        /// 次の検索結果を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Forward(int index, int? offset)
        {
            var document = Results[index].Document as Document;
            if (document == null) return;

            var start  = GetOffset(document, offset);
            var result = document.FindNext(Keyword, start, CaseSensitive);

            if (result != null)
            {
                Current = index;
                document.SetSelection(result.Begin, result.End);
            }
            else
            {
                document.SetSelection(start, start);
                if (index < Results.Count - 1) Forward(++index, 0);
                else Current = -1;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Back
        /// 
        /// <summary>
        /// 前の検索結果を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Back(int index, int? offset)
        {
            var document = Results[index].Document as Document;
            if (document == null) return;

            var start  = GetOffset(document, offset);
            var result = document.FindPrev(Keyword, start, CaseSensitive);

            if (result != null)
            {
                Current = index;
                document.SetSelection(result.End, result.Begin);
            }
            else
            {
                document.SetSelection(start, start);
                if (index > 0) Back(--index, -1 /* LastIndex */);
                else Current = -1;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ReplaceNext
        /// 
        /// <summary>
        /// 次の検索結果を置換します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ReplaceNext(int index, int? offset, string replaced)
            => SyncWait(() =>
        {
            var document = Results[index].Document as Document;
            if (document == null) return;

            var start  = GetOffset(document, offset);
            var result = document.FindNext(Keyword, start, CaseSensitive);

            if (result != null)
            {
                Current = index;
                Replace(index, replaced, result.Begin, result.End);
                document.SetSelection(result.Begin, result.Begin + replaced.Length);
            }
            else
            {
                document.SetSelection(start, start);
                if (index < Results.Count - 1) ReplaceNext(++index, 0, replaced);
                else Current = -1;
            }
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Replace
        /// 
        /// <summary>
        /// 置換を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Replace(int index, string replaced, int begin, int end)
            => SyncWait(() =>
        {
            var document = Results[index].Document as Document;
            if (document == null) return;

            document.Replace(replaced, begin, end);

            var line = 0;
            var column = 0;
            document.GetLineColumnIndexFromCharIndex(begin, out line, out column);
            if (line != 0) return;

            Results[index].UpdateAbstract(MaxAbstractLength);
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Highlight
        /// 
        /// <summary>
        /// 検索結果を強調表示します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Highlight(Page page, string keyword, bool sensitive)
            => SyncWait(() =>
        {
            var src = page?.Document as Document;
            if (src == null) return;

            var highlight = new KeywordHighlighter();
            highlight.AddRegex(keyword, !sensitive, CharClass.Keyword);
            src.Highlighter = highlight;
        });

        /* ----------------------------------------------------------------- */
        ///
        /// UnHighlight
        /// 
        /// <summary>
        /// 検索結果の強調表示を解除します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UnHighlight(Page page)
            => SyncWait(() =>
        {
            var src = page?.Document as Document;
            if (src == null) return;
            src.Highlighter = null;
        });

        /* --------------------------------------------------------------------- */
        ///
        /// SyncWait
        /// 
        /// <summary>
        /// オブジェクト初期化時のスレッド上で各種操作を実行し、
        /// 実行が完了するまで待機します。
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        private void SyncWait(Action action)
        {
            if (_ui != null) _ui.Send(_ => action(), null);
            else action();
        }

        #endregion

        #region Classes

        /* ----------------------------------------------------------------- */
        ///
        /// Position
        /// 
        /// <summary>
        /// 検索結果中の現在位置を表すクラスです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public class Position
        {
            public Position(int i, int b, int e)
            {
                Index = i;
                Begin = b;
                End   = e;
            }

            public int Index { get; }
            public int Begin { get; }
            public int End   { get; }
        }

        #endregion

        #region Fields
        private int _current = -1;
        private SynchronizationContext _ui = SynchronizationContext.Current;
        #endregion
    }
}
