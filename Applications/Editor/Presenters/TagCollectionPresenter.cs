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
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;
using Cube.Log;

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
            View.DrawMode = DrawMode.OwnerDrawFixed;
            View.DrawItem += View_DrawItem;
            Model.Loaded += Model_Loaded;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// EditIndex
        ///
        /// <summary>
        /// 編集用のインデックスを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int EditIndex => View.Items.Count - 1;

        #endregion

        #region Event handlers

        #region EventAggregator

        /* ----------------------------------------------------------------- */
        ///
        /// NewTag_Handle
        ///
        /// <summary>
        /// タグが追加された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void NewTag_Handle(object sender, ValueEventArgs<Tag> e)
            => this.LogException(() => Model.Add(e.Value));

        /* ----------------------------------------------------------------- */
        ///
        /// RemoveTag_Handle
        ///
        /// <summary>
        /// タグが削除された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RemoveTag_Handle(object sender, ValueEventArgs<Tag> e)
            => this.LogException(() => Model.Remove(e.Value));

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

                this.LogException(() =>
                {
                    if (page.Tags.Count == 0) Model.Nothing?.Decrement();
                    else Model.Decrement(page.Tags);
                    page.Tags.Clear();

                    if (dialog.Tags.Count == 0) Model.Nothing?.Increment();
                    else foreach (var name in dialog.Tags)
                    {
                        Model.Create(name).Count++;
                        page.Tags.Add(name);
                    }
                });
            });

            Events.Edit.Raise(ValueEventArgs.Create(page));
        }

        #endregion

        #region Settings

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
            => Settings.User.Tag = e.NewValue?.Name ?? string.Empty;

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

        /* ----------------------------------------------------------------- */
        ///
        /// View_DrawItem
        ///
        /// <summary>
        /// 項目を描画します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_DrawItem(object sender, DrawItemEventArgs e)
        {
            var control = sender as ComboBox;
            if (control == null || e.Index < 0) return;

            var text = control.Items[e.Index].ToString();

            if ((e.State & DrawItemState.ComboBoxEdit) != 0)
            {
                e.Graphics.FillRectangle(Brushes.Transparent, e.Bounds);
                e.Graphics.DrawString(text, control.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                return;
            }

            var system = (e.Index == 0 || e.Index == 1 || e.Index == View.Items.Count - 1);
            var style  = system ? FontStyle.Bold : FontStyle.Regular;
            using (var font = new Font(control.Font, style))
            using (var brush = new SolidBrush(e.ForeColor))
            {
                e.DrawBackground();
                e.Graphics.DrawString(text, font, brush, e.Bounds.X, e.Bounds.Y);
            }
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
            Events.NewTag.Handle += NewTag_Handle;
            Events.RemoveTag.Handle += RemoveTag_Handle;
            Events.Property.Handle += Property_Handled;
            Settings.Current.TagChanged += Settings_TagChanged;
            ViewReset(Model.Get(Settings.User.Tag));
            Model.CollectionChanged += Model_CollectionChanged;

            this.LogDebug($"Loaded\tCount:{Model.Count}");
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
                    SyncWait(() => InsertItem(e.NewStartingIndex));
                    Attach(e.NewItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Detach(e.OldItems);
                    SyncWait(() => RemoveItem(e.OldStartingIndex));
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Tag

        /* ----------------------------------------------------------------- */
        ///
        /// Tag_PropertyChanged
        ///
        /// <summary>
        /// プロパティが変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Tag_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
        private void Attach(Tag tag)
        {
            if (tag == null) return;
            tag.PropertyChanged -= Tag_PropertyChanged;
            tag.PropertyChanged += Tag_PropertyChanged;
        }

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
            foreach (Tag tag in tags) Attach(tag);
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
        private void Detach(Tag tag)
        {
            if (tag == null) return;
            tag.PropertyChanged -= Tag_PropertyChanged;
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
            foreach (Tag tag in tags) Detach(tag);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// AddItem
        ///
        /// <summary>
        /// タグを View.Items に追加します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void AddItem(Tag tag)
        {
            if (tag == null) return;
            Attach(tag);
            View.Items.Add(tag);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InsertItem
        ///
        /// <summary>
        /// タグを View.Items に挿入します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InsertItem(int modelIndex)
        {
            if (modelIndex < 0 || modelIndex >= Model.Count) return;

            var tag = Model[modelIndex];
            if (tag == null) return;

            Attach(tag);

            var index = Math.Min(modelIndex + Model.SystemTagCount, EditIndex);
            View.Items.Insert(index, tag);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// RemoveItem
        ///
        /// <summary>
        /// タグを View.Items から削除します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RemoveItem(int modelIndex)
        {
            if (modelIndex < 0) return;
            var index = Math.Min(modelIndex + Model.SystemTagCount, EditIndex - 1);
            if (View.SelectedIndex == index) View.SelectedIndex = 0;
            View.Items.RemoveAt(index);
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
        private void ViewReset(Tag init = null) => SyncWait(() =>
        {
            var index = init == null ? 1 :
                        init == Model.Everyone ? 0 :
                        init == Model.Nothing  ? 1 :
                        Model.IndexOf(init) + Model.SystemTagCount;

            View.BeginUpdate();
            View.SelectedIndexChanged -= View_SelectedIndexChanged;

            if (View.Items.Count > 0) View.Items.Clear();
            AddItem(Model.Everyone);
            AddItem(Model.Nothing);
            foreach (var tag in Model) AddItem(tag);
            View.Items.Add(Properties.Resources.EditTag);

            View.SelectedIndexChanged += View_SelectedIndexChanged;
            View.SelectedIndex = Math.Max(Math.Min(index, EditIndex - 1), 0);
            View.EndUpdate();
        });

        #endregion
    }
}
