/* ------------------------------------------------------------------------- */
///
/// TextEditControl.cs
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
using Sgry.Azuki;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// TextEditControl
    /// 
    /// <summary>
    /// テキストエディタを表示するクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class TextEditControl : Cube.Forms.UserControl
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TextEditControl
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TextEditControl()
        {
            InitializeComponent();

            var colors = AzukiTextControl.ColorScheme;
            colors.LineNumberBack = SystemColors.Control;
            colors.LineNumberFore = SystemColors.ControlDark;
            colors.SelectionBack  = SystemColors.Highlight;
            colors.SelectionFore  = SystemColors.HighlightText;
            colors.EolColor       = colors.WhiteSpaceColor;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Document
        ///
        /// <summary>
        /// Document オブジェクトを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Document Document
        {
            get { return AzukiTextControl.Document; }
            set { AzukiTextControl.Document = value; }
        }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Refresh
        ///
        /// <summary>
        /// コントロールを再描画します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public override void Refresh()
        {
            AzukiTextControl.ScrollToCaret();
            AzukiTextControl.ViewWidth = 0;

            base.Refresh();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SelectFont
        ///
        /// <summary>
        /// 使用するフォントを選択します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void SelectFont()
        {
            var dialog = new FontDialog();
            dialog.Font = AzukiTextControl.Font;
            dialog.Color = AzukiTextControl.ForeColor;
            dialog.ShowEffects = false;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;

            AzukiTextControl.Font = dialog.Font;
            AzukiTextControl.ForeColor = dialog.Color;
        }

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnCreateControl
        ///
        /// <summary>
        /// コントロールの生成時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            var width  = SystemInformation.VerticalScrollBarWidth;
            var height = SystemInformation.HorizontalScrollBarHeight;
            SizeGripControl.Size = new Size(width, height);
            MoveSizeGripControl();
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
            base.OnResize(e);
            MoveSizeGripControl();
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// MoveSizeGripControl
        ///
        /// <summary>
        /// リサイズ用グリップを右下に配置します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void MoveSizeGripControl()
        {
            var x = Width  - SizeGripControl.Width;
            var y = Height - SizeGripControl.Height;
            SizeGripControl.Location = new Point(x, y);
        }

        #endregion
    }
}
