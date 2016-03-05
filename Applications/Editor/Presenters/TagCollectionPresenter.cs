﻿/* ------------------------------------------------------------------------- */
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
using System.ComponentModel;
using System.Collections;
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
            Model.Loaded += Model_Loaded;
        }

        #endregion

        #region Event handlers

        #region EventAggregator

        /* ----------------------------------------------------------------- */
        ///
        /// Property_Handled
        ///
        /// <summary>
        /// タグ編集画面を表示する時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Property_Handled(object sender, EventArgs e)
        {
            var page = Settings.Current.Page;
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

        #endregion

        #region View

        /* ----------------------------------------------------------------- */
        ///
        /// View_SelectedIndexChanged
        ///
        /// <summary>
        /// 選択されている項目が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (View.SelectedItem.ToString() == Properties.Resources.EditTag)
            {
                View.SelectedItem = Settings.Current.Tag;
                Events.TagSettings.Raise();
            }
            else Settings.Current.Tag = View.SelectedItem as Tag;
        }

        #endregion

        #region Model

        /* ----------------------------------------------------------------- */
        ///
        /// Model_Loaded
        ///
        /// <summary>
        /// タグ情報の読み込みが完了した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_Loaded(object sender, EventArgs e)
        {
            Events.Property.Handle += Property_Handled;
            ViewReset();
            Model.CollectionChanged += Model_CollectionChanged;
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
                    SyncWait(() => View.Items.Insert(View.Items.Count - 1, Model[e.NewStartingIndex]));
                    Attach(e.NewItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Detach(e.OldItems);
                    SyncWait(() => View.Items.RemoveAt(e.OldStartingIndex));
                    break;
                default:
                    break;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Model_PropertyChanged
        ///
        /// <summary>
        /// プロパティが変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var tag = sender as Tag;
            if (tag == null) return;

            Sync(() =>
            {
                var index = View.Items.IndexOf(tag);
                if (index == -1) return;
                View.Items[index] = tag;
            });
        }

        #endregion

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Attach
        ///
        /// <summary>
        /// イベントハンドラを関連付けます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Attach(IList tags)
        {
            if (tags == null) return;

            foreach (Tag tag in tags)
            {
                tag.PropertyChanged -= Model_PropertyChanged;
                tag.PropertyChanged += Model_PropertyChanged;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Detach
        ///
        /// <summary>
        /// 関連付けられているイベントハンドラを解除します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Detach(IList tags)
        {
            if (tags == null) return;

            foreach (Tag tag in tags) tag.PropertyChanged -= Model_PropertyChanged;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ViewReset
        ///
        /// <summary>
        /// View の状態をリセットします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ViewReset() => SyncWait(() =>
        {
            View.BeginUpdate();
            View.SelectedIndexChanged -= View_SelectedIndexChanged;

            if (View.Items.Count > 0) View.Items.Clear();

            Model.Everyone.PropertyChanged -= Model_PropertyChanged;
            Model.Everyone.PropertyChanged += Model_PropertyChanged;
            View.Items.Add(Model.Everyone);

            foreach (var tag in Model)
            {
                tag.PropertyChanged -= Model_PropertyChanged;
                tag.PropertyChanged += Model_PropertyChanged;
                View.Items.Add(tag);
            }

            View.Items.Add(Properties.Resources.EditTag);
            View.SelectedIndexChanged += View_SelectedIndexChanged;
            View.SelectedIndex = 0;
            View.EndUpdate();
        });

        #endregion
    }
}
