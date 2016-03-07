/* ------------------------------------------------------------------------- */
///
/// TextMenuControl.cs
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
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// TextMenuControl
    /// 
    /// <summary>
    /// テキストエディタ上で表示されるコンテキストメニューを表すクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class TextMenuControl : ContextMenuStrip
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TextMenuControl
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TextMenuControl() : base()
        {
            CutMenu       = new ToolStripMenuItem(Properties.Resources.CutMenu);
            CopyMenu      = new ToolStripMenuItem(Properties.Resources.CopyMenu);
            PasteMenu     = new ToolStripMenuItem(Properties.Resources.PasteMenu);
            SearchMenu    = new ToolStripMenuItem(Properties.Resources.SearchMenu);
            GoogleMenu    = new ToolStripMenuItem(Properties.Resources.GoogleMenu);
            UndoMenu      = new ToolStripMenuItem(Properties.Resources.UndoMenu);
            RedoMenu      = new ToolStripMenuItem(Properties.Resources.RedoMenu);
            SelectAllMenu = new ToolStripMenuItem(Properties.Resources.SelectAllMenu);

            InitializeShortCutKeys();
            InitializeMenu();
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// CutMenu
        /// 
        /// <summary>
        /// 切り取りメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripMenuItem CutMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// CopyMenu
        /// 
        /// <summary>
        /// コピーメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripMenuItem CopyMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// PasteMenu
        /// 
        /// <summary>
        /// 貼り付けメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripMenuItem PasteMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// SearchMenu
        /// 
        /// <summary>
        /// 検索メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripMenuItem SearchMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// GoogleMenu
        /// 
        /// <summary>
        /// インターネットで検索メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripMenuItem GoogleMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// UndoMenu
        /// 
        /// <summary>
        /// 元に戻すメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripMenuItem UndoMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// RedoMenu
        /// 
        /// <summary>
        /// やり直しメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripMenuItem RedoMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// SelectAllMenu
        /// 
        /// <summary>
        /// すべて選択メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripMenuItem SelectAllMenu { get; }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeShortCutKeys
        /// 
        /// <summary>
        /// ショートカットキーを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeShortCutKeys()
        {
            SearchMenu.ShortcutKeys    = Keys.Control | Keys.F;
            GoogleMenu.ShortcutKeys    = Keys.Control | Keys.G;
            UndoMenu.ShortcutKeys      = Keys.Control | Keys.Z;
            RedoMenu.ShortcutKeys      = Keys.Control | Keys.Y;
            CutMenu.ShortcutKeys       = Keys.Control | Keys.X;
            CopyMenu.ShortcutKeys      = Keys.Control | Keys.C;
            PasteMenu.ShortcutKeys     = Keys.Control | Keys.V;
            SelectAllMenu.ShortcutKeys = Keys.Control | Keys.A;
        }

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
                SearchMenu,
                GoogleMenu,
                new ToolStripSeparator(),
                UndoMenu,
                RedoMenu,
                new ToolStripSeparator(),
                CutMenu,
                CopyMenu,
                PasteMenu,
                new ToolStripSeparator(),
                SelectAllMenu,
            });
        }

        #endregion
    }
}
