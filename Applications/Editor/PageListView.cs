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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// PageListView
    /// 
    /// <summary>
    /// ページ一覧を表示するための ListView クラスです。
    /// </summary>
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
        /// AllowNoSelect
        /// 
        /// <summary>
        /// 選択項目がゼロの状態を許可するかどうかを示す値を取得または
        /// 設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(true)]
        [DefaultValue(true)]
        public bool AllowNoSelect { get; set; } = true;

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

            BorderStyle = BorderStyle.None;
            Converter   = new PageConverter();
            HeaderStyle = ColumnHeaderStyle.None;
            Margin      = new Padding(0);
            MultiSelect = false;
            Theme       = Cube.Forms.WindowTheme.Explorer;
            TileSize    = new Size(Width, 70);
            View        = View.Tile;

            Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader(), // Title
                new ColumnHeader(), // CreationTime
            });

        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnMouseUp
        /// 
        /// <summary>
        /// マウスのボタンから離れた時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (AllowNoSelect || SelectedIndices.Count > 0) return;
            if (FocusedItem != null) FocusedItem.Selected = true;
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
            var width  = Height < height * Count ?
                         Width - SystemInformation.VerticalScrollBarWidth :
                         Width;
            TileSize   = new Size(width, height);

            base.OnResize(e);
        }

        #endregion
    }
}
