/* ------------------------------------------------------------------------- */
///
/// PageCollectionControl.cs
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
using System.Drawing;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// PageCollectionControl
    /// 
    /// <summary>
    /// ページ一覧を表示するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class PageCollectionControl : Cube.Forms.UserControl
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// ItemListControl
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageCollectionControl()
        {
            InitializeComponent();
            InitializeLayout();
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// SelectedIndex
        /// 
        /// <summary>
        /// 選択されている項目のインデックスを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int SelectedIndex
        {
            get
            {
                return PageListView.SelectedIndices.Count > 0 ?
                       PageListView.SelectedIndices[0] :
                       -1;
            }
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// NewPage
        ///
        /// <summary>
        /// 新しいページの追加が要求された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler NewPageRequired;

        /* ----------------------------------------------------------------- */
        ///
        /// Added
        ///
        /// <summary>
        /// ページが追加された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler<DataEventArgs<int>> Added;

        /* ----------------------------------------------------------------- */
        ///
        /// Removed
        ///
        /// <summary>
        /// ページが削除された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler<DataEventArgs<int>> Removed;

        /* ----------------------------------------------------------------- */
        ///
        /// SelectedIndexChanged
        ///
        /// <summary>
        /// 選択項目が変更された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler SelectedIndexChanged;

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// NewPage
        /// 
        /// <summary>
        /// 新しいページを追加します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void NewPage()
        {
            OnNewPageRequired(new EventArgs());
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Add
        /// 
        /// <summary>
        /// ページを追加します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Add(Page item)
        {
            var index = PageListView.Items.Count;
            Insert(index, item);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Insert
        /// 
        /// <summary>
        /// 指定されたインデックスにページを追加します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Insert(int index, Page item)
        {
            PageListView.Insert(index, item);
            OnAdded(new DataEventArgs<int>(index));
            if (PageListView.Items.Count == 1)
            {
                PageListView.Items[0].Selected = true;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Remove
        /// 
        /// <summary>
        /// ページを削除します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Remove(int index)
        {
            if (index < 0 || index >= PageListView.Items.Count) return;
            PageListView.Items.RemoveAt(index);
            OnRemoved(new DataEventArgs<int>(index));
            if (PageListView.Items.Count > 0)
            {
                var newindex = Math.Min(index, PageListView.Items.Count - 1);
                PageListView.Items[newindex].Selected = true;
            }
        }

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// NewPage
        ///
        /// <summary>
        /// 新しいページの追加要求が発生した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnNewPageRequired(EventArgs e)
        {
            if (NewPageRequired != null) NewPageRequired(this, e);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnAdded
        ///
        /// <summary>
        /// ページが追加された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnAdded(DataEventArgs<int> e)
        {
            if (Added != null) Added(this, e);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnRemoved
        ///
        /// <summary>
        /// ページが削除された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnRemoved(DataEventArgs<int> e)
        {
            if (Removed != null) Removed(this, e);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnSelectedIndexChanged
        ///
        /// <summary>
        /// 選択項目が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectedIndexChanged != null) SelectedIndexChanged(this, e);
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// PageListView_Resize
        /// 
        /// <summary>
        /// ListView のリサイズ時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void PageListView_Resize(object sender, EventArgs e)
        {
            var count  = PageListView.Items.Count;
            var height = PageListView.TileSize.Height;
            var width  = PageListView.ClientSize.Height < height * count ?
                         PageListView.Width - SystemInformation.VerticalScrollBarWidth :
                         PageListView.Width;
            PageListView.TileSize = new Size(width, height);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PageListView_SelectedIndexChanged
        /// 
        /// <summary>
        /// 選択項目が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void PageListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PageListView.SelectedIndices.Count == 0) return;
            OnSelectedIndexChanged(e);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PageListView_MouseUp
        /// 
        /// <summary>
        /// マウスのボタンから手が離れた時に実行されるハンドラです。
        /// </summary>
        /// 
        /// <remarks>
        /// 項目がまったく選択されない状態になる事を防止します。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        private void PageListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (PageListView.FocusedItem != null &&
                PageListView.SelectedIndices.Count == 0)
            {
                PageListView.FocusedItem.Selected = true;
            }
        }

        #endregion

        #region Other private methods

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeLayout
        /// 
        /// <summary>
        /// レイアウトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeLayout()
        {
            PageListView.View = View.Tile;
            PageListView.TileSize = new Size(PageListView.Width, 70);
            PageListView.Converter = new PageConverter();
            PageListView.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader(), // Title
                new ColumnHeader(), // CreationTime
            });
        }

        #endregion
    }
}
