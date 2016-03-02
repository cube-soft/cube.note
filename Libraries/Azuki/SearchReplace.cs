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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
            Results.CollectionChanged += Results_CollectionChanged;
        }

        #endregion

        #region Properties

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
                if (_current != null &&
                    _current.Index == value.Index &&
                    _current.Begin == value.Begin &&
                    _current.End == value.End) return;

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
            ResetHighlight(keyword, sensitive);

            var result = FindNext(page, keyword, sensitive, 0);
            if (result == null) return;

            Results.Add(Highlight(page, keyword, sensitive));
            Current = new Position(0, result.Begin, result.End);
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
            ResetHighlight(keyword, sensitive);

            Position current = null;
            foreach(var page in Pages.Search(range))
            {
                var result = FindNext(page, keyword, sensitive, 0);
                if (result == null) continue;

                Results.Add(Highlight(page, keyword, sensitive));
                if (current == null) current = new Position(0, result.Begin, result.End);
            }
            if (current != null) Current = current;
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

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// Results_CollectionChanged
        /// 
        /// <summary>
        /// コレクションの内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Results_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                case NotifyCollectionChangedAction.Reset:
                    if (Results.Count <= 0) ResetHighlight();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Document
        /// 
        /// <summary>
        /// Document オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private Document Document(Page page)
            => page?.CreateDocument(Pages.Directory);

        /* ----------------------------------------------------------------- */
        ///
        /// FindNext
        /// 
        /// <summary>
        /// 次の検索結果を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private SearchResult FindNext(Page page, string keyword, bool sensitive, int offset)
            => Document(page)?.FindNext(keyword, offset, sensitive);

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
            var src = Document(page);
            if (src == null) return page;
            
            if (src.Highlighter != _highlight) src.Highlighter = _highlight;
            return page;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ResetHighlight
        /// 
        /// <summary>
        /// 強調表示をリセットします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ResetHighlight(string keyword, bool sensitive)
        {
            ResetHighlight();
            _highlight.AddRegex(keyword, !sensitive, CharClass.Keyword);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ResetHighlight
        /// 
        /// <summary>
        /// 強調表示をリセットします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ResetHighlight() => _highlight.ClearRegex();

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
        private KeywordHighlighter _highlight = new KeywordHighlighter();
        #endregion
    }
}
