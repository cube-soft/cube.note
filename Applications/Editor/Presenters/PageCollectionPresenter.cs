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
using System.Collections.Specialized;
using System.Windows.Forms;
using Cube.Collections;
using Cube.Log;
using Cube.Note.Azuki;

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
            Model.Loaded += Model_Loaded;
        }

        #endregion

        #region Event handlers

        #region Model

        /* ----------------------------------------------------------------- */
        ///
        /// Model_Loaded
        /// 
        /// <summary>
        /// ページ情報の読み込みが完了した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_Loaded(object sender, EventArgs e)
        {
            Events.NewPage.Handle   += NewPage_Handle;
            Events.Duplicate.Handle += Duplicate_Handle;
            Events.Import.Handle    += Import_Handle;
            Events.Export.Handle    += Export_Handle;
            Events.Edit.Handle      += Edit_Handle;
            Events.Move.Handle      += Move_Handle;
            Events.Remove.Handle    += Remove_Handle;
            Events.RemoveTag.Handle += RemoveTag_Handle;

            View.SelectedIndexChanged += View_SelectedIndexChanged;

            var tag = Settings.Current.Tag ?? Model.Tags.Nothing;
            if (tag.Count <= 0) tag = Model.Tags.Everyone;
            Settings.Current.Tag = tag;
            ResetView(tag);

            Model.CollectionChanged += Model_CollectionChanged;

            Settings.Current.PageChanged += Settings_PageChanged;
            Settings.Current.TagChanged  += Settings_TagChanged;

            this.LogDebug($"Count:{Model.Count}");
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
                    if (Model.Count <= 0) NewPage_Handle(sender, ValueEventArgs.Create(0));
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
            var page = Model[index];

            SyncWait(() =>
            {
                var pages = View.DataSource;
                if (pages == null || !ContainsInView(page)) return;

                var newindex = Math.Min(index, pages.Count);
                pages.Insert(newindex, page);
            });
        }

        #endregion

        #region EventAggregator

        /* ----------------------------------------------------------------- */
        ///
        /// NewPage_Handle
        /// 
        /// <summary>
        /// 新しいページの作成要求が発生した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void NewPage_Handle(object sender, ValueEventArgs<int> e)
        {
            var index = GetInsertIndex(e.Value);
            Model.NewPage(Settings.Current.Tag, index);
            Sync(() => View.Select(index));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Duplicate_Handle
        /// 
        /// <summary>
        /// ページの複製要求が発生した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Duplicate_Handle(object sender, ValueEventArgs<int> e)
            => Sync(() =>
        {
            if (View.DataSource == null) return;
            var src = GetIndex(e.Value);
            if (src < 0 || src >= View.DataSource.Count) return;

            var dest = GetInsertIndex(e.Value);
            Model.Duplicate(dest, View.DataSource[src]);
            View.Select(dest);
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Import_Handle
        /// 
        /// <summary>
        /// ページのインポート時に実行されるハンドラです。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private async void Import_Handle(object sender, KeyValueEventArgs<int, string> e)
        {
            var path = !string.IsNullOrEmpty(e.Value) ? e.Value : GetImportFile();
            if (string.IsNullOrEmpty(path)) return;

            var index = GetInsertIndex(e.Key);
            await Async(() => Model.Import(
                Settings.Current.Tag,
                index,
                path,
                Settings.MaxAbstractLength
            ));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Export_Handle
        /// 
        /// <summary>
        /// ページのエクスポート時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private async void Export_Handle(object sender, ValueEventArgs<int> e)
        {
            if (Settings.Current.Page == null) return;

            var page = Settings.Current.Page;
            var path = GetExportFile(page);
            if (string.IsNullOrEmpty(path)) return;

            await Async(() => page.CreateDocument(Model.Directory)?.Save(path));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Edit_Handled
        /// 
        /// <summary>
        /// ページの情報が編集された時に実行されるハンドラです。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void Edit_Handle(object sender, ValueEventArgs<Page> e)
            => Sync(() =>
        {
            var page = e.Value;
            if (page == null) return;

            if (ContainsInView(page)) View.Update(View.DataSource?.IndexOf(page) ?? -1);
            else
            {
                var source = View.DataSource;
                if (source == null) return;

                source.Remove(page);
                if (source.Count <= 0) Settings.Current.Page = null;
            }
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Move_Handle
        /// 
        /// <summary>
        /// 選択ページの移動要求が発生した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Move_Handle(object sender, ValueEventArgs<int> e)
            => Sync(async () =>
        {
            if (View.DataSource == null || View.SelectedIndices.Count <= 0) return;

            // View
            var count = View.DataSource.Count;
            var vold  = View.SelectedIndices[0];
            var vnew  = Math.Min(Math.Max(vold + e.Value, 0), count - 1);
            if (vold < 0 || vold >= count || vold == vnew) return;

            // Model
            var mold = Model.IndexOf(View.DataSource[vold]);
            var mnew = Model.IndexOf(View.DataSource[vnew]);
            if (mold  < 0 || mnew < 0) return;
            await Async(() => Model.Move(mold, mnew));
            
            View.DataSource.Move(vold, vnew);
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Remove_Handle
        /// 
        /// <summary>
        /// ページの削除要求が発生した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Remove_Handle(object sender, ValueEventArgs<int> e)
            => Sync(() =>
        {
            var pages = View.DataSource;
            if (pages == null || !View.AnyItemsSelected) return;

            var index = View.SelectedIndices[0];
            var page  = pages[index];
            if (IsRemoveCanceled(page)) return;

            pages.RemoveAt(index);
            var newindex = Math.Min(index, pages.Count - 1);
            Settings.Current.Page = (newindex >= 0) ? pages[newindex] : null;

            Model.Remove(page);
        });


        /* ----------------------------------------------------------------- */
        ///
        /// RemoveTag_Handle
        /// 
        /// <summary>
        /// タグの削除要求が発生した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RemoveTag_Handle(object sender, ValueEventArgs<Tag> e)
            => Sync(() =>
        {
            if (e.Value == null) return;

            foreach (var page in Model.Search(e.Value))
            {
                page.Tags.Remove(e.Value.Name);
                if (!ContainsInView(page)) continue;
                View.Update(View.DataSource?.IndexOf(page) ?? -1);
            }
        });

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

        #region Settings

        /* ----------------------------------------------------------------- */
        ///
        /// Settings_PageChanged
        /// 
        /// <summary>
        /// アクティブな Page が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Settings_PageChanged(object sender, EventArgs e)
            => Sync(() =>
        {
            if (Settings.Current.Page == null) return;

            var current = View.SelectedIndices.Count > 0 ?
                          View.SelectedIndices[0] : -1;
            var changed = View.DataSource?.IndexOf(Settings.Current.Page) ?? -1;
            if (changed == -1 || changed == current) return;

            View.Select(changed);
            View.EnsureVisible(changed);
        });

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
            => ResetView(e.NewValue);

        #endregion

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// GetIndex
        /// 
        /// <summary>
        /// インデックスを取得します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private int GetIndex(int index)
            => index != -1 ?
               index :
               SyncWait(() => View.AnyItemsSelected ? View.SelectedIndices[0] : -1);

        /* ----------------------------------------------------------------- */
        ///
        /// GetInsertIndex
        /// 
        /// <summary>
        /// 挿入先インデックスを取得します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private int GetInsertIndex(int index)
            => SyncWait(() =>
        {
            var dest  = index != -1 ? index :
                        View.AnyItemsSelected ? View.SelectedIndices[0] + 1 :
                        0;
            var count = View.DataSource?.Count ?? 0;
            return Math.Max(Math.Min(dest, count), 0);
        });

        /* ----------------------------------------------------------------- */
        ///
        /// GetImportFile
        /// 
        /// <summary>
        /// インポートするファイルを取得します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private string GetImportFile()
            => SyncWait(() =>
        {
            var dialog = Dialogs.Import();
            return dialog.ShowDialog() != DialogResult.Cancel ?
                   dialog.FileName :
                   string.Empty;
        });

        /* ----------------------------------------------------------------- */
        ///
        /// GetExportFile
        /// 
        /// <summary>
        /// エクスポートしたファイルの保存先を取得します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private string GetExportFile(Page page)
            => SyncWait(() =>
        {
            if (page == null) return string.Empty;
            var dialog = Dialogs.Export(page.GetAbstract(), 30);
            return dialog.ShowDialog() != DialogResult.Cancel ?
                   dialog.FileName :
                   string.Empty;
        });

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
            return SyncWait(() => Dialogs.Remove(page) == DialogResult.No);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ContainsInView
        /// 
        /// <summary>
        /// View にページが含まれている（または含まれるべき）かどうかを判別します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private bool ContainsInView(Page page)
        {
            if (View.DataSource == null) return false;

            return Settings.Current.Tag == null ||
                   Settings.Current.Tag == Model.Tags.Everyone ||
                   Settings.Current.Tag == Model.Tags.Nothing && page.Tags.Count == 0 ||
                   page.Tags.Contains(Settings.Current.Tag.Name);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ResetView
        /// 
        /// <summary>
        /// View の状態をリセットします。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void ResetView(Tag tag)
        {
            if (tag == null) return;

            var result = Model.Search(tag)?.ToObservable();

            Sync(() =>
            {
                View.DataSource = result;
                if (View.DataSource?.Count > 0)
                {
                    var index = result.IndexOf(Settings.Current.Page);
                    View.Select(Math.Max(index, 0));
                }
                else Settings.Current.Page = null;
            });
        }

        #endregion
    }
}
