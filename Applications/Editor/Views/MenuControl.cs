/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
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
    public class MenuControl : ToolStrip, IDpiAwarable
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
            VisibleMenu  = CreateMenuButton("left",     Properties.Resources.ToolMenuHide);
            SearchMenu   = CreateMenuButton("search",   Properties.Resources.ToolMenuSearch);
            UndoMenu     = CreateMenuButton("undo",     Properties.Resources.ToolMenuUndo);
            RedoMenu     = CreateMenuButton("redo",     Properties.Resources.ToolMenuRedo);
            ExportMenu   = CreateMenuButton("export",   Properties.Resources.ToolMenuExport);
            PrintMenu    = CreateMenuButton("print",    Properties.Resources.ToolMenuPrint);
            SettingsMenu = CreateMenuButton("settings", Properties.Resources.ToolMenuSettings, false);
            LogoMenu     = CreateMenuButton("logo",     Properties.Resources.ToolMenuLogo, false);

            InitializeMenu();
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
        public ToolStripItem VisibleMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// SearchMenu
        ///
        /// <summary>
        /// 検索メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem SearchMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// UndoMenu
        ///
        /// <summary>
        /// 元に戻すメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem UndoMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// RedoMenu
        ///
        /// <summary>
        /// やり直しメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem RedoMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// ExportMenu
        ///
        /// <summary>
        /// エクスポートメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem ExportMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// PrintMenu
        ///
        /// <summary>
        /// 印刷メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem PrintMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsMenu
        ///
        /// <summary>
        /// 設定メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem SettingsMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// LogoMenu
        ///
        /// <summary>
        /// ロゴボタンを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem LogoMenu { get; }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateLayout
        ///
        /// <summary>
        /// レイアウトを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void UpdateLayout(double ratio)
        {
            foreach (var item in Items)
            {
                var control = item as ToolStripButton;
                if (control == null) continue;

                var separator = (control.DisplayStyle == ToolStripItemDisplayStyle.None);
                if (separator) UpdateSeparator(control, ratio);
                else UpdateMenuButton(control, ratio);
            }
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

            BackColor = SystemColors.Control;
            GripStyle = ToolStripGripStyle.Hidden;
            Padding   = new Padding(6, 0, 0, 0);
            Renderer  = new MenuRenderer(BackColor);

            UndoMenu.Enabled = false;
            RedoMenu.Enabled = false;
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeMenu
        ///
        /// <summary>
        /// メニューを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeMenu()
        {
            Items.AddRange(new ToolStripItem[]
            {
                VisibleMenu,
                CreateSeparator(),
                SearchMenu,
                CreateSeparator(),
                UndoMenu,
                RedoMenu,
                CreateSeparator(),
                ExportMenu,
                PrintMenu,
                CreateSeparator(),
                SettingsMenu,
                LogoMenu,
            });
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CreateMenuButton
        ///
        /// <summary>
        /// メニューボタンを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private ToolStripButton CreateMenuButton(string name, string text, bool left = true)
        {
            var dest  = new ToolStripButton();
            var align = left ? ToolStripItemAlignment.Left : ToolStripItemAlignment.Right;

            dest.Name         = name;
            dest.Alignment    = align;
            dest.DisplayStyle = ToolStripItemDisplayStyle.Image;
            dest.Image        = Images.Get(name, 1.0);
            dest.ImageScaling = ToolStripItemImageScaling.None;
            dest.Margin       = new Padding(1);
            dest.Padding      = new Padding(12, 0, 12, 0);
            dest.Size         = new Size(44, 30);
            dest.Text         = text;
            dest.ToolTipText  = text;

            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateMenuButton
        ///
        /// <summary>
        /// メニューボタンのレイアウトを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateMenuButton(ToolStripButton src, double ratio)
        {
            var padding = (int)(12 * ratio);
            var width   = (int)(44 * ratio);
            var height  = (int)(30 * ratio);

            src.Image   = Images.Get(src.Name, ratio);
            src.Padding = new Padding(padding, 0, padding, 0);
            src.Size    = new Size(width, height);
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
            dest.Size         = new Size(1, 30);

            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateSeparator
        ///
        /// <summary>
        /// 区切り線のレイアウトを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateSeparator(ToolStripButton src, double ratio)
        {
            var padding = (int)(6 * ratio);
            var width   = 1;
            var height  = (int)(30 * ratio);

            src.Margin = new Padding(padding, 0, padding, 0);
            src.Size   = new Size(width, height);
        }

        #endregion
    }
}
