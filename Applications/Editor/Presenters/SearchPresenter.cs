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
using System.Linq;
using Cube.Note.Azuki;
using Cube.Collections;

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
            Events.Search.Handle += Search_Handled;

            View.Pages.SelectedIndexChanged += View_SelectedIndexChanged;
            View.Hidden += View_Hidden;

            ResetSearchRange();
            View.SearchRange.SelectedIndex = 1;
        }

        #endregion

        #region Event handlers

        #region EventAggregator

        /* ----------------------------------------------------------------- */
        ///
        /// Search_Handled
        /// 
        /// <summary>
        /// 検索を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private async void Search_Handled(object sender, ValueEventArgs<string> e)
        {
            if (string.IsNullOrEmpty(e.Value)) return;

            await Async(() =>
            {
                var results = Model.Search(e.Value);
                if (!results.Any()) return;

                var source = results.ToObservable();
                Sync(() =>
                {
                    View.Found = source.Count;
                    View.ShowPages = View.SearchRange.SelectedIndex != 0;
                    if (View.ShowPages) View.Pages.DataSource = source;
                });
            });
        }

        #endregion

        #region View

        /* ----------------------------------------------------------------- */
        ///
        /// View_Hidden
        /// 
        /// <summary>
        /// メイン画面から削除された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_Hidden(object sender, EventArgs e)
        {
            View.Pages.DataSource = null;
            View.Found = -1;
            View.ShowPages = false;
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
            if (!View.Pages.AnyItemsSelected) return;

            var pages = View.Pages.DataSource;
            if (pages == null) return;

            var index = View.Pages.SelectedIndices[0];
            if (index < 0 || index >= pages.Count) return;

            var real = Model.IndexOf(pages[index]);
            if (real < 0 || real >= Model.Count) return;

            Settings.Current.Page = Model[real];
        }

        #endregion

        #endregion

        #region Others

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

        #endregion
    }
}
