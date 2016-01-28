/* ------------------------------------------------------------------------- */
///
/// ItemListControl.cs
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
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// ItemListControl
    /// 
    /// <summary>
    /// ノート一覧を表示するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class ItemListControl : Cube.Forms.UserControl
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
        public ItemListControl()
        {
            InitializeComponent();
            InitializeLayout();

            DummyData(5);
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// ItemListView_Resize
        /// 
        /// <summary>
        /// ListView のリサイズ時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ItemListView_Resize(object sender, EventArgs e)
        {
            var count  = ItemListView.Items.Count;
            var height = ItemListView.TileSize.Height;
            var width  = ItemListView.ClientSize.Height < height * count ?
                         ItemListView.Width - SystemInformation.VerticalScrollBarWidth :
                         ItemListView.Width;
            ItemListView.TileSize = new Size(width, height);
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
            ItemListView.View = View.Tile;
            ItemListView.TileSize = new Size(ItemListView.Width, 70);
            ItemListView.LargeImageList = new ImageList();
            ItemListView.LargeImageList.ImageSize = new Size(8, 1);
            ItemListView.LargeImageList.Images.Add(new Bitmap(8, 1));
            ItemListView.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader(), // Title
                new ColumnHeader(), // CreationTime
            });
        }

        #endregion

        #region For debug

        /* ----------------------------------------------------------------- */
        ///
        /// DummyData
        /// 
        /// <summary>
        /// ダミーデータを追加します。
        /// </summary>
        /// 
        /// <remarks>
        /// 見た目の確認用です。追加処理が実装され次第、削除されます。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        [Conditional("DEBUG")]
        public void DummyData(int count)
        {
            for (var i = 0; i < count; ++i)
            {
                ItemListView.Items.Add(new ListViewItem(new string[]
                {
                    string.Format("ダミーノート ({0}) 株式会社キューブ・ソフト abcdefghijklmnopqrstuvwxyz", i),
                    DateTime.Now.ToString("yyyy/mm/dd HH:MM 作成")
                }, 0));
            }
        }

        #endregion
    }
}
