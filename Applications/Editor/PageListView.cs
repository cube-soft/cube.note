/* ------------------------------------------------------------------------- */
///
/// PageListView.cs
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
    /// PageListView
    /// 
    /// <summary>
    /// Page オブジェクトの一覧を表示するための ListView クラスです。
    /// </summary>
    /// 
    /// <remarks>
    /// TODO: Columns の初期化
    /// </remarks>
    /// 
    /* --------------------------------------------------------------------- */
    public class PageListView : Cube.Forms.ListView
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// PageListView
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageListView() : base() { }

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
            get { return SelectedIndices.Count > 0 ? SelectedIndices[0] : -1; }
        }

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnCreateControl
        /// 
        /// <summary>
        /// コントロールが生成された時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            BorderStyle   = BorderStyle.None;
            Converter     = new PageConverter();
            FullRowSelect = true;
            HeaderStyle   = ColumnHeaderStyle.None;
            Margin        = new Padding(0);
            MultiSelect   = false;
            Theme         = Cube.Forms.WindowTheme.Explorer;
            TileSize      = new Size(Math.Max(Width, 1), 70);
            View          = View.Tile;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnMouseUp
        /// 
        /// <summary>
        /// マウスのボタンが離された時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (FocusedItem != null && SelectedIndices.Count == 0) FocusedItem.Selected = true;
            base.OnMouseUp(e);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnResize
        /// 
        /// <summary>
        /// リサイズ時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnResize(EventArgs e)
        {
            var height = TileSize.Height;
            var width = ClientSize.Height < height * Items.Count ?
                         Width - SystemInformation.VerticalScrollBarWidth :
                         Width;

            TileSize = new Size(Math.Max(width, 1), Math.Max(height, 1));
            base.OnResize(e);
        }

        #endregion
    }
}
