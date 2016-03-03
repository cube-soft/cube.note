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
        public Position Current
        {
            get { return _current; }
            set
            {
                if (_current != null && value != null &&
                    _current.Index == value.Index &&
                    _current.Begin == value.Begin &&
                    _current.End   == value.End   ) return;

                _current = value;
                RaisePropertyChanged(nameof(Current));
            }
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// PropertyChanged
        /// 
        /// <summary>
        /// プロパティの内容が変更された時に発生するイベントです。
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
            Current = null;
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
            Results.Clear();
            Keyword = keyword;
            CaseSensitive = sensitive;

            var result = GetResult(page, keyword, sensitive);
            if (result == null) return;

            Results.Add(Highlight(page, keyword, sensitive));
            Current = new Position(0, 0, 0);
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
            Results.Clear();
            Keyword = keyword;
            CaseSensitive = sensitive;

            foreach(var page in Pages.Search(range))
            {
                var result = GetResult(page, keyword, sensitive);
                if (result == null) continue;

                Results.Add(Highlight(page, keyword, sensitive));
            }

            if (Results.Count > 0) Current = new Position(0, 0, 0);
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

            var index = Current != null ?
                        Math.Max(Math.Min(Current.Index, Results.Count - 1), 0) :
                        0;

            Forward(index, null);
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

            var index = Current != null ?
                        Math.Max(Math.Min(Current.Index, Results.Count - 1), 0) :
                        Results.Count - 1;

            Back(index, null);
        }

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnPropertyChanged
        ///
        /// <summary>
        /// PropertyChanged イベントを発生させます。
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
        /// GetResult
        /// 
        /// <summary>
        /// 次の検索結果を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private SearchResult GetResult(Page page, string keyword, bool sensitive)
            => page?.CreateDocument(Pages.Directory)
                   ?.FindNext(keyword, 0, sensitive);

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
            var doc = Results[index].Document as Document;
            if (doc == null) return;

            var start  = offset.HasValue ? offset.Value : doc.CaretIndex;
            var result = doc.FindNext(Keyword, start, CaseSensitive);

            if (result != null) Current = new Position(index, result.Begin, result.End);
            else if (index < Results.Count - 1) Forward(++index, 0);
            else Current = null;
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
            var doc = Results[index].Document as Document;
            if (doc == null) return;

            var start  = !offset.HasValue    ? doc.CaretIndex :
                          offset.Value == -1 ? doc.Length :
                                               offset.Value;
            var result = doc.FindPrev(Keyword, start, CaseSensitive);

            if (result != null) Current = new Position(index, result.End, result.Begin);
            else if (index > 0) Back(--index, -1 /* LastIndex */);
            else Current = null;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Highlight
        /// 
        /// <summary>
        /// 検索結果を強調表示します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private Page Highlight(Page page, string keyword, bool sensitive)
        {
            var src = page?.Document as Document;
            if (src == null) return page;

            var highlight = new KeywordHighlighter();
            highlight.AddRegex(keyword, !sensitive, CharClass.Keyword);
            src.Highlighter = highlight;
            
            return page;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UnHighlight
        /// 
        /// <summary>
        /// 検索結果の強調表示を解除します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private Page UnHighlight(Page page)
        {
            var src = page?.Document as Document;
            if (src == null) return page;

            src.Highlighter = null;
            return page;
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
        private Position _current;
        #endregion
    }
}
