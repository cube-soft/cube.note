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

            DummyData(5);
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
            PageListView.LargeImageList = new ImageList();
            PageListView.LargeImageList.ImageSize = new Size(8, 1);
            PageListView.LargeImageList.Images.Add(new Bitmap(8, 1));
            PageListView.Columns.AddRange(new ColumnHeader[]
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
                PageListView.Items.Add(new ListViewItem(new string[]
                {
                    string.Format("ダミーノート ({0}) 株式会社キューブ・ソフト abcdefghijklmnopqrstuvwxyz", i),
                    DateTime.Now.ToString("yyyy/mm/dd HH:MM 作成")
                }, 0));
            }
        }

        #endregion
    }
}
