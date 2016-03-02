/* ------------------------------------------------------------------------- */
///
/// SearchPresenter.cs
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cube.Note.Azuki;
using Cube.Collections;
using Sgry.Azuki;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// SearchPresenter
    /// 
    /// <summary>
    /// SearchControl とモデルを関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class SearchPresenter : 
        PresenterBase<SearchForm, PageCollection>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// SearchPresenter
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SearchPresenter(SearchForm view, PageCollection model,
            SettingsFolder settings, EventAggregator events)
            : base(view, model, settings, events)
        {
            Events.SearchMode.Handle += SearchMode_Handle;
            Events.Search.Handle += Search_Handled;

            View.Showing += View_Showing;
            View.Hiding += View_Hiding;
            View.Pages.SelectedIndexChanged += View_SelectedIndexChanged;
            View.Aggregator = Events;
        }

        #endregion

        #region Event handlers

        #region EventAggregator

        /* ----------------------------------------------------------------- */
        ///
        /// SearchMode_Handle
        /// 
        /// <summary>
        /// 検索画面を表示します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void SearchMode_Handle(object sender, ValueEventArgs<int> e)
        {
            Sync(() =>
            {
                View.Show();

                var count = View.SearchRange.Items.Count;
                if (count <= 0) return;

                var index = Math.Max(Math.Min(e.Value, count - 1), 0);
                View.SearchRange.SelectedIndex = index;
            });
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Search_Handled
        /// 
        /// <summary>
        /// 検索を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private async void Search_Handled(object sender, EventArgs e)
        {
            var keyword   = string.Empty;
            var sensitive = true;
            var one       = false;

            SyncWait(() =>
            {
                keyword   = View.Keyword;
                sensitive = View.CaseSensitive;
                one       = View.SearchRange.SelectedIndex == 0;
            });

            if (string.IsNullOrEmpty(keyword)) return;

            await Async(() =>
            {
                if (one) Search(Settings.Current.Page, keyword, sensitive);
                else Search(Model.Search(Model.Everyone), keyword, sensitive);
            });
        }

        #endregion

        #region View

        /* ----------------------------------------------------------------- */
        ///
        /// View_Showing
        /// 
        /// <summary>
        /// 表示時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_Showing(object sender, CancelEventArgs e)
           => SyncWait(() => ResetSearchRange());

        /* ----------------------------------------------------------------- */
        ///
        /// View_Hiding
        /// 
        /// <summary>
        /// 非表示時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private async void View_Hiding(object sender, CancelEventArgs e)
        {
            var source = View.Pages.DataSource;

            View.Pages.DataSource = null;
            View.Found = -1;
            View.ShowPages = false;

            await Async(() => Cleanup(source));
            Events.Refresh.Raise();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_SelectedIndexChanged
        /// 
        /// <summary>
        /// 選択項目が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_SelectedIndexChanged(object sender, EventArgs e)
        {
            var page = SelectedPage();
            if (page == null) return;
            Settings.Current.Page = page;
            Events.Refresh.Raise();
        }

        #endregion

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Search
        /// 
        /// <summary>
        /// 現在のページから検索を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Search(Page page, string keyword, bool sensitive)
        {
            var result = page.CreateDocument(Model.Directory)?
                             .FindNext(keyword, 0, sensitive);
            if (result == null) return;

            page.Highlight(keyword, sensitive);

            var source = new ObservableCollection<Page>();
            source.Add(page);
            Sync(() =>
            {
                View.Found = source.Count;
                View.ShowPages = false;
                View.Pages.DataSource = source;
                Events.Refresh.Raise();
            });
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Search
        /// 
        /// <summary>
        /// 指定されたページ一覧から検索を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Search(IEnumerable<Page> pages, string keyword, bool sensitive)
        {
            var results = pages.Search(keyword, sensitive, 0, Model.Directory);
            if (!results.Any()) return;

            var source = results.ToObservable();
            Sync(() =>
            {
                View.Found = source.Count;
                View.ShowPages = true;
                View.Pages.DataSource = source;
            });
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Cleanup
        /// 
        /// <summary>
        /// 終了処理を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Cleanup(IList<Page> pages)
        {
            if (pages == null) return;

            foreach (var page in pages)
            {
                var document = page.Document as Document;
                if (document == null || document.Highlighter == null) continue;
                document.Highlighter = null;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ResetSearchRange
        /// 
        /// <summary>
        /// 検索範囲用の項目を設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ResetSearchRange()
        {
            View.SearchRange.Items.Clear();
            View.SearchRange.Items.Add(Properties.Resources.CurrentNote);
            View.SearchRange.Items.Add(Model.Everyone);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SelectedPage
        /// 
        /// <summary>
        /// 選択ページを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private Page SelectedPage()
        {
            if (!View.Pages.AnyItemsSelected) return null;

            var pages = View.Pages.DataSource;
            if (pages == null) return null;

            var index = View.Pages.SelectedIndices[0];
            if (index < 0 || index >= pages.Count) return null;

            return pages[index];
        }

        #endregion
    }
}
