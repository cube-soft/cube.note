/* ------------------------------------------------------------------------- */
///
/// MenuControl.cs
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
using System.Drawing;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// MenuControl
    /// 
    /// <summary>
    /// アプリケーションの上部メニューを表すクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class MenuControl : ToolStrip
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// MenuControl
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public MenuControl() : base()
        {
            VisibleMenu  = CreateMenu(Properties.Resources.Left, Properties.Resources.HideMenu);
            SearchMenu   = CreateMenu(Properties.Resources.Search, Properties.Resources.SearchMenu);
            UndoMenu     = CreateMenu(Properties.Resources.Undo, Properties.Resources.UndoMenu);
            RedoMenu     = CreateMenu(Properties.Resources.Redo, Properties.Resources.RedoMenu);
            SettingsMenu = CreateMenu(Properties.Resources.Settings, Properties.Resources.SettingsMenu, false);
            LogoMenu     = CreateMenu(Properties.Resources.Logo, Properties.Resources.LogoMenu, false);
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// VisibleMenu
        /// 
        /// <summary>
        /// 表示方法を制御するメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripButton VisibleMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// SearchMenu
        /// 
        /// <summary>
        /// 検索メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripButton SearchMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// UndoMenu
        /// 
        /// <summary>
        /// 元に戻すメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripButton UndoMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// RedoMenu
        /// 
        /// <summary>
        /// やり直しメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripButton RedoMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsMenu
        /// 
        /// <summary>
        /// 設定メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripButton SettingsMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// LogoMenu
        /// 
        /// <summary>
        /// ロゴボタンを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripButton LogoMenu { get; }

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

            BackColor = SystemColors.Control;
            GripStyle = ToolStripGripStyle.Hidden;
            Padding   = new Padding(6, 0, 0, 0);
            Renderer  = new MenuRenderer(BackColor);

            Items.AddRange(new ToolStripItem[]
            {
                VisibleMenu,
                CreateSeparator(),
                SearchMenu,
                CreateSeparator(),
                UndoMenu,
                RedoMenu,
                CreateSeparator(),
                LogoMenu,
                SettingsMenu
            });
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// CreateMenu
        /// 
        /// <summary>
        /// メニューボタンを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private ToolStripButton CreateMenu(Image image, string text, bool left = true)
        {
            var dest  = new ToolStripButton();
            var align = left ? ToolStripItemAlignment.Left : ToolStripItemAlignment.Right;

            dest.Alignment    = align;
            dest.DisplayStyle = ToolStripItemDisplayStyle.Image;
            dest.Image        = image;
            dest.ImageScaling = ToolStripItemImageScaling.None;
            dest.Margin       = new Padding(1);
            dest.Padding      = new Padding(12, 0, 12, 0);
            dest.Size = new Size(44, 30);
            dest.Text         = text;
            dest.ToolTipText  = text;

            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CreateSeparator
        /// 
        /// <summary>
        /// 仕切り線を生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private ToolStripButton CreateSeparator()
        {
            var dest = new ToolStripButton();

            dest.AutoSize     = false;
            dest.AutoToolTip  = false;
            dest.BackColor    = Color.FromArgb(215, 215, 215);
            dest.DisplayStyle = ToolStripItemDisplayStyle.None;
            dest.Enabled      = false;
            dest.Margin       = new Padding(6, 0, 6, 0);
            dest.Padding      = new Padding(0);
            dest.Size = new Size(1, 30);

            return dest;
        }

        #endregion
    }
}
