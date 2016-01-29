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

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Add
        /// 
        /// <summary>
        /// 新しいページを追加します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Add(Page item)
        {
            PageListView.Add(item);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Insert
        /// 
        /// <summary>
        /// 指定されたインデックスに新しいページを追加します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Insert(int index, Page item)
        {
            PageListView.Insert(index, item);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Select
        /// 
        /// <summary>
        /// 項目を選択します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Select(int index)
        {
            if (index < 0 || index >= PageListView.Items.Count) return;
            PageListView.Items[index].Selected = true;
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
        /// 選択されている項目が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void PageListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PageListView.SelectedIndices.Count <= 0 && _lastIndex >= 0)
            {
                PageListView.SelectedIndices.Add(_lastIndex);
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PageListView_ItemSelectionChanged
        /// 
        /// <summary>
        /// 選択されている項目が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void PageListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected) _lastIndex = e.ItemIndex;
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

        #region Fields
        private int _lastIndex = -1;
        #endregion
    }
}
