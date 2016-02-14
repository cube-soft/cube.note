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
using System.Collections.ObjectModel;
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
        PresenterBase<PageListView, PageCollection>
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
        public PageCollectionPresenter(PageListView view,　PageCollection model,
            SettingsFolder settings, EventAggregator events)
            : base(view, model, settings, events)
        {
            Events.NewPage.Handled += NewPage_Handled;
            Events.Remove.Handled += Remove_Handled;

            View.DataSource = new ObservableCollection<Page>();
            View.SelectedIndexChanged += View_SelectedIndexChanged;

            Model.CollectionChanged += Model_CollectionChanged;

            Settings.Current.PageChanged += Settings_PageChanged;
            Settings.Current.TagChanged += Settings_TagChanged;
        }

        #endregion

        #region Event handlers

        #region EventAggregator

        /* ----------------------------------------------------------------- */
        ///
        /// NewPage_Handled
        /// 
        /// <summary>
        /// 新しいページの作成要求が発生した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void NewPage_Handled(object sender, EventArgs e)
        {
            Model.NewPage(Settings.Current.Tag);
            Sync(() => View.Select(0));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Remove_Handled
        /// 
        /// <summary>
        /// 選択ページの削除要求が発生した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Remove_Handled(object sender, EventArgs e)
        {
            Sync(() =>
            {
                var pages = View.DataSource;
                if (pages == null || !View.AnyItemsSelected) return;

                var index = View.SelectedIndices[0];
                var page  = pages[index];
                if (IsRemoveCanceled(page)) return;

                pages.RemoveAt(index);
                var newindex = Math.Min(index, pages.Count - 1);
                Settings.Current.Page = newindex >= 0 ? pages[newindex] : null;

                page.PropertyChanged -= Model_PropertyChanged;
                Model.Remove(page);
            });
        }

        #endregion

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
            var pages = View.DataSource;
            var index = View.SelectedIndices[0];
            if (pages == null || index < 0 || index >= pages.Count) return;

            Settings.Current.Page = pages[index];
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
                    if (Model.Count <= 0) NewPage_Handled(sender, EventArgs.Empty);
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
            var page  = Model[index];

            page.PropertyChanged -= Model_PropertyChanged;
            page.PropertyChanged += Model_PropertyChanged;

            SyncWait(() =>
            {
                var pages = View.DataSource;
                if (pages == null || !ViewContains(page)) return;

                var newindex = Math.Min(index, pages.Count);
                pages.Insert(newindex, page);
            });
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

            Sync(() =>
            {
                var index = View.DataSource?.IndexOf(page) ?? -1;
                if (index == -1) return;

                if (e.PropertyName == nameof(page.Abstract)) View.ReplaceText(index, page.GetAbstract());
                else View.Replace(index, page);
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

            Sync(() =>
            {
                var current = View.SelectedIndices.Count > 0 ?
                              View.SelectedIndices[0] : -1;
                var changed = View.DataSource?.IndexOf(Settings.Current.Page) ?? -1;
                if (changed == -1 || changed == current) return;

                View.Select(changed);
            });
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

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// IsRemoveCanceled
        /// 
        /// <summary>
        /// キャンセルされたかどうか判別します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private bool IsRemoveCanceled(Page page)
        {
            if (page == null) return true;
            if (!Settings.User.RemoveWarning) return false;

            var message = new System.Text.StringBuilder();
            message.AppendLine(Properties.Resources.WarnRemove);
            message.AppendLine();
            message.AppendLine(page.GetAbstract());
            message.AppendLine(page.Creation.ToString(Properties.Resources.CreationFormat));
            message.AppendLine(page.LastUpdate.ToString(Properties.Resources.LastUpdateFormat));

            var result = DialogResult.Yes;
            SyncWait(() => result = MessageBox.Show(
                message.ToString(),
                Properties.Resources.WarnRemoveTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1
            ));
            return result == DialogResult.No;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ViewContains
        /// 
        /// <summary>
        /// View にページが含まれている（または含まれるべき）かどうかを判別します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private bool ViewContains(Page page)
        {
            if (View.DataSource == null) return false;

            return Settings.Current.Tag == null ||
                   Settings.Current.Tag == Model.Everyone ||
                   page.Tags.Contains(Settings.Current.Tag.Name);
        }

        #endregion
    }
}
