/* ------------------------------------------------------------------------- */
///
/// TagCollectionPresenter.cs
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

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// TagCollectionPresenter
    /// 
    /// <summary>
    /// タグ一覧と Model を関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class TagCollectionPresenter
        : PresenterBase<ComboBox, TagCollection>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TagCollectionPresenter
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagCollectionPresenter(ComboBox view, PageCollection pages,
            SettingsFolder settings, EventAggregator events)
            : base(view, pages.Tags, settings, events)
        {
            Everyone = pages.Everyone;

            Events.Property.Handled += Property_Handled;

            Model.CollectionChanged += Model_CollectionChanged;

            View.SelectedIndexChanged += View_SelectedIndexChanged;
            View.Items.Add(Everyone);
            View.SelectedIndex = 0;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Everyone
        ///
        /// <summary>
        /// すべてのノートを表示する事を表すタグを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Tag Everyone { get; }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// Property_Handled
        ///
        /// <summary>
        /// タグ編集画面を表示する時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Property_Handled(object sender, ValueEventArgs<Page> e)
        {
            var page = e.Value ?? Settings.Current.Page;
            if (page == null) return;

            SyncWait(() =>
            {
                var dialog = new PropertyForm(page, Model);
                if (dialog.ShowDialog() == DialogResult.Cancel) return;

                Model.Decrease(page.Tags);
                page.Tags.Clear();
                foreach (var name in dialog.Tags)
                {
                    Model.Create(name).Count++;
                    page.Tags.Add(name);
                }
            });

            Events.Edit.Raise(new ValueEventArgs<Page>(page));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_SelectedIndexChanged
        ///
        /// <summary>
        /// 選択されている項目が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Settings.Current.Tag = View.SelectedItem as Tag;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Model_CollectionChanged
        ///
        /// <summary>
        /// タグの内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    SyncWait(() => View.Items.Add(Model[e.NewStartingIndex]));
                    break;
                case NotifyCollectionChangedAction.Remove:
                    SyncWait(() => View.Items.RemoveAt(e.OldStartingIndex));
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
