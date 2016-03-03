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
using System.Linq;
using Cube.Note.Azuki;

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
        PresenterBase<SearchForm, SearchReplace>
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
        public SearchPresenter(SearchForm view, PageCollection parent,
            SettingsFolder settings, EventAggregator events)
            : base(view, new SearchReplace(parent), settings, events)
        {
            Events.Search.Handle += Search_Handle;
            Settings.Current.PageChanged += Settings_PageChanged;

            View.Hiding += View_Hiding;
            View.Search += View_Search;
            View.SearchNext += (s, e) => Model.Forward();
            View.SearchPrev += (s, e) => Model.Back();
            View.Pages.SelectedIndexChanged += View_SelectedIndexChanged;
            View.Pages.DataSource = Model.Results;
            View.Aggregator = Events;

            Model.PropertyChanged += Model_PropertyChanged;
        }

        #endregion

        #region Event handlers

        #region EventAggregator

        /* ----------------------------------------------------------------- */
        ///
        /// Search_Handle
        /// 
        /// <summary>
        /// 検索画面を表示します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Search_Handle(object sender, ValueEventArgs<int> e)
        {
            Sync(() =>
            {
                ResetRange();
                View.Show();

                var count = View.SearchRange.Items.Count;
                if (count <= 0) return;

                var index = Math.Max(Math.Min(e.Value, count - 1), 0);
                View.SearchRange.SelectedIndex = index;
            });
        }

        #endregion

        #region Settings

        /* ----------------------------------------------------------------- */
        ///
        /// Settings_PageChanged
        /// 
        /// <summary>
        /// 現在のページが変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Settings_PageChanged(object sender, ValueChangedEventArgs<Page> e)
        {
            if (e.NewValue == null) return;
            Model.Current = Model.Results.IndexOf(e.NewValue);
        }

        #endregion

        #region View

        /* ----------------------------------------------------------------- */
        ///
        /// View_Search
        /// 
        /// <summary>
        /// 検索を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private async void View_Search(object sender, EventArgs e)
        {
            var keyword   = View.Keyword;
            var sensitive = View.CaseSensitive;
            var tag       = View.SearchRange.SelectedItem as Tag;

            if (string.IsNullOrEmpty(keyword)) return;

            await Async(() =>
            {
                if (tag == null) Model.Search(keyword, sensitive, Settings.Current.Page);
                else Model.Search(keyword, sensitive, tag);
            });

            View.ShowPages = tag != null && Model.Results.Count > 0;
        }

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
            View.Found = -1;
            View.ShowPages = false;

            await Async(() =>
            {
                Model.Reset();
                Events.Refresh.Raise();
            });
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
        private void View_SelectedIndexChanged(object sender, EventArgs e) => Sync(() =>
        {
            if (!View.Pages.AnyItemsSelected) return;
            Model.Current = View.Pages.SelectedIndices[0];
        });

        #endregion

        #region Model

        /* ----------------------------------------------------------------- */
        ///
        /// Model_PropertyChanged
        /// 
        /// <summary>
        /// プロパティの内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(Model.Current)) return;
            SetPage(Model.Current);
        }

        #endregion

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// ResetRange
        /// 
        /// <summary>
        /// 検索範囲用の項目を設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ResetRange()
        {
            View.SearchRange.BeginUpdate();
            View.SearchRange.Items.Clear();
            View.SearchRange.Items.Add(Properties.Resources.CurrentNote);
            View.SearchRange.Items.Add(Model.Pages.Everyone);
            View.SearchRange.Items.AddRange(Model.Pages.Tags.ToArray());
            View.SearchRange.EndUpdate();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SetPage
        /// 
        /// <summary>
        /// 指定されたインデックスに対応するページを設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void SetPage(int index)
        {
            if (index < 0 || index >= Model.Results.Count) return;

            var page = Model.Results[index];
            if (page != Settings.Current.Page) Settings.Current.Page = page;
            else Events.Refresh.Raise();

            Sync(() =>
            {
                View.Pages.Select(index);
                View.Pages.EnsureVisible(index);
            });
        }

        #endregion
    }
}
