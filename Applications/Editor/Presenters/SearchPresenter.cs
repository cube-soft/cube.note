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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        PresenterBase<SearchControl, PageCollection>
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
        public SearchPresenter(SearchControl view, PageCollection model,
            SettingsFolder settings, EventAggregator events)
            : base(view, model, settings, events)
        {
            View.SearchExecuted += View_Search;
            View.Pages.Cleared += (s, e) => Results.Clear();
            View.Pages.SelectedIndexChanged += View_SelectedIndexChanged;

            Results.CollectionChanged += Results_CollectionChanged;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Results
        /// 
        /// <summary>
        /// 検索結果を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ObservableCollection<Page> Results { get; } = new ObservableCollection<Page>();

        #endregion

        #region Event handlers

        #region View

        /* ----------------------------------------------------------------- */
        ///
        /// View_Search
        /// 
        /// <summary>
        /// 検索時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private async void View_Search(object sender, ValueEventArgs<string> e)
        {
            if (string.IsNullOrEmpty(e.Value)) return;

            await Async(() =>
            {
                Results.Clear();
                Model.Search(e.Value, Results);
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
        private void View_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!View.Pages.AnyItemsSelected) return;

            var index = View.Pages.SelectedIndices[0];
            if (index < 0 || index >= Results.Count) return;

            var real = Model.IndexOf(Results[index]);
            if (real < 0 || real >= Model.Count) return;

            Settings.Current.Page = Model[real];
        }

        #endregion

        #region Results

        /* ----------------------------------------------------------------- */
        ///
        /// Results_CollectionChanged
        /// 
        /// <summary>
        /// 検索結果に変更があった時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Results_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var index = e.NewStartingIndex;
                    SyncWait(() => View.Pages.Insert(index, Results[index]));
                    break;
                case NotifyCollectionChangedAction.Reset:
                    if (Results.Count == 0) SyncWait(() => View.Pages.Clear());
                    break;
            }
        }

        #endregion

        #endregion
    }
}
