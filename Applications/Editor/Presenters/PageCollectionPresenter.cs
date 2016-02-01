/* ------------------------------------------------------------------------- */
///
/// PageCollectionPresenter.cs
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
using System.Collections.Specialized;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// PageCollectionPresenter
    /// 
    /// <summary>
    /// PageCollectionControl とモデルを関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class PageCollectionPresenter : Cube.Forms.PresenterBase<PageCollectionControl, PageCollection>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// PageCollectionPresenter
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageCollectionPresenter(PageCollectionControl view, PageCollection model)
            : base(view, model)
        {
            View.SelectedIndexChanged += View_SelectedIndexChanged;
            View.NewPageRequired      += View_NewPageRequired;
            View.Added                += View_Added;
            View.Removed              += View_Removed;

            Model.ActiveChanged       += Model_ActiveChanged;
            Model.CollectionChanged   += Model_CollectionChanged;
        }

        #endregion

        #region Event handlers

        #region View

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
            var index = View.SelectedIndex;
            if (index < 0 || index >= Model.Count) return;
            Model.Active = Model[index];
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_NewPageRequired
        /// 
        /// <summary>
        /// 新しいページの作成要求が発生した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_NewPageRequired(object sender, EventArgs e)
        {
            Model.NewPage();
            View.Select(0);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_Added
        /// 
        /// <summary>
        /// 項目が追加された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_Added(object sender, EventArgs e)
        {
            if (View.Count == 1) View.Select(0);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_Removed
        /// 
        /// <summary>
        /// ページが削除された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_Removed(object sender, DataEventArgs<int> e)
        {
            var index = e.Value;
            if (index < 0 || index >= Model.Count) return;
            if (View.Count > 0) View.Select(Math.Min(index, View.Count - 1));

            Model[index].PropertyChanged -= Model_PropertyChanged;
            Model.RemoveAt(index);
            Model.Active = Model[Math.Min(index, Model.Count - 1)];
        }

        #endregion

        #region Model

        /* ----------------------------------------------------------------- */
        ///
        /// Model_ActiveChanged
        /// 
        /// <summary>
        /// アクティブな Page が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_ActiveChanged(object sender, EventArgs e)
        {
            if (Model.Active == null) return;

            var index = View.SelectedIndex;
            if (index >= 0 && index < Model.Count && Model.Active == Model[index]) return;

            var changed = Model.IndexOf(Model.Active);
            if (changed == -1) return;

            Sync(() => View.Select(changed));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Model_CollectionChanged
        /// 
        /// <summary>
        /// コレクションの内容に変更があった時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Model_Added(sender, e);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (Model.Count <= 0) Model.NewPage();
                    break;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Model_Added
        /// 
        /// <summary>
        /// コレクションに要素が追加された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_Added(object sender, NotifyCollectionChangedEventArgs e)
        {
            var index = e.NewStartingIndex;
            Model[index].PropertyChanged -= Model_PropertyChanged;
            Model[index].PropertyChanged += Model_PropertyChanged;
            SyncWait(() => View.Insert(index, Model[index]));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Model_PropertyChanged
        /// 
        /// <summary>
        /// プロパティの値が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Abstract") return;

            var page = sender as Page;
            if (page == null) return;

            var index = Model.IndexOf(page);
            if (index == -1) return;

            Sync(() => View.UpdateText(index, page.GetAbstract()));
        }

        #endregion

        #endregion
    }
}
