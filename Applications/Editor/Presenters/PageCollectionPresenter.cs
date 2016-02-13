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
using System.Windows.Forms;

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
    public class PageCollectionPresenter :
        PresenterBase<PageCollectionControl, PageCollection>
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
        public PageCollectionPresenter(PageCollectionControl view,　PageCollection model,
            SettingsFolder settings, EventAggregator events)
            : base(view, model, settings, events)
        {
            View.NewPageExecuted += View_NewPageExecuted;
            View.Pages.SelectedIndexChanged += View_SelectedIndexChanged;
            View.Pages.Added += View_Added;
            View.Pages.Removing += View_Removing;
            View.Pages.Removed += View_Removed;

            Model.CollectionChanged += Model_CollectionChanged;

            Settings.Current.PageChanged += Settings_PageChanged;
            Settings.Current.TagChanged += Settings_TagChanged;
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
            var index = View.Pages.SelectedIndices[0];
            if (index < 0 || index >= Model.Count) return;

            Settings.Current.Page = Model[index];
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_NewPageExecuted
        /// 
        /// <summary>
        /// 新しいページの作成要求が発生した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_NewPageExecuted(object sender, EventArgs e)
        {
            Model.NewPage();
            View.Pages.Select(0);
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
        private void View_Added(object sender, ValueEventArgs<int> e)
        {
            if (View.Pages.Count == 1) View.Pages.Select(0);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_Removing
        /// 
        /// <summary>
        /// ページが削除される直前に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_Removing(object sender, ValueCancelEventArgs<int[]> e)
        {
            if (e.Value == null || e.Value.Length <= 0) return;
            if (!Settings.User.RemoveWarning)
            {
                e.Cancel = false;
                return;
            }

            var index = e.Value[0];
            var message = new System.Text.StringBuilder();
            message.AppendLine(Properties.Resources.WarnRemove);
            message.AppendLine();
            message.AppendLine(Model[index].GetAbstract());
            message.AppendLine(Model[index].Creation.ToString(Properties.Resources.CreationFormat));
            message.AppendLine(Model[index].LastUpdate.ToString(Properties.Resources.LastUpdateFormat));

            var result = MessageBox.Show(
                message.ToString(),
                Properties.Resources.WarnRemoveTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1
            );

            e.Cancel = (result == DialogResult.No);
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
        private void View_Removed(object sender, ValueEventArgs<int[]> e)
        {
            if (e.Value == null || e.Value.Length <= 0) return;

            var index = e.Value[0];
            if (index < 0 || index >= Model.Count) return;

            Model[index].PropertyChanged -= Model_PropertyChanged;
            Model.RemoveAt(index);

            Settings.Current.Page = Model[Math.Min(index, Model.Count - 1)];
        }

        #endregion

        #region Model

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
            SyncWait(() => View.Pages.Insert(index, Model[index]));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Model_PropertyChanged
        /// 
        /// <summary>
        /// プロパティの値が変化した時に実行されるハンドラです。
        /// </summary>
        /// 
        /// <remarks>
        /// 項目全体を置換すると画面のちらつき目立つため、概要の更新に
        /// ついては Text 部分のみを置換します。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var page = sender as Page;
            if (page == null) return;

            var index = Model.IndexOf(page);
            if (index == -1) return;

            Sync(() =>
            {
                if (e.PropertyName == nameof(page.Abstract)) View.Pages.ReplaceText(index, page.GetAbstract());
                else View.Pages.Replace(index, page);
            });
        }

        #endregion

        #region Settings

        /* ----------------------------------------------------------------- */
        ///
        /// Model_ActiveChanged
        /// 
        /// <summary>
        /// アクティブな Page が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Settings_PageChanged(object sender, EventArgs e)
        {
            if (Settings.Current.Page == null) return;

            var index = View.Pages.SelectedIndices.Count > 0 ?
                        View.Pages.SelectedIndices[0] : -1;
            if (index >= 0 && index < Model.Count && Settings.Current.Page == Model[index]) return;

            var changed = Model.IndexOf(Settings.Current.Page);
            if (changed == -1) return;

            Sync(() => View.Pages.Select(changed));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Settings_TagChanged
        /// 
        /// <summary>
        /// タグが変化した時に実行されるハンドラです。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void Settings_TagChanged(object sender, ValueChangedEventArgs<Tag> e)
        {
            // TODO: implementations
        }

        #endregion

        #endregion
    }
}
