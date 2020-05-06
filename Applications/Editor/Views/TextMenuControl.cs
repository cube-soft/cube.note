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
            CutMenu       = new ToolStripMenuItem(Properties.Resources.MenuCut);
            CopyMenu      = new ToolStripMenuItem(Properties.Resources.MenuCopy);
            PasteMenu     = new ToolStripMenuItem(Properties.Resources.MenuPaste);
            SearchMenu    = new ToolStripMenuItem(Properties.Resources.MenuSearch);
            GoogleMenu    = new ToolStripMenuItem(Properties.Resources.MenuGoogle);
            UndoMenu      = new ToolStripMenuItem(Properties.Resources.MenuUndo);
            RedoMenu      = new ToolStripMenuItem(Properties.Resources.MenuRedo);
            SelectAllMenu = new ToolStripMenuItem(Properties.Resources.MenuSelectAll);

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
        public ToolStripItem CutMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// CopyMenu
        /// 
        /// <summary>
        /// コピーメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem CopyMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// PasteMenu
        /// 
        /// <summary>
        /// 貼り付けメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem PasteMenu { get; }

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
        /// GoogleMenu
        /// 
        /// <summary>
        /// インターネットで検索メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem GoogleMenu { get; }

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
        /// SelectAllMenu
        /// 
        /// <summary>
        /// すべて選択メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem SelectAllMenu { get; }

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
            Menu(SearchMenu).ShortcutKeys    = Keys.Control | Keys.F;
            Menu(GoogleMenu).ShortcutKeys    = Keys.Control | Keys.G;
            Menu(UndoMenu).ShortcutKeys      = Keys.Control | Keys.Z;
            Menu(RedoMenu).ShortcutKeys      = Keys.Control | Keys.Y;
            Menu(CutMenu).ShortcutKeys       = Keys.Control | Keys.X;
            Menu(CopyMenu).ShortcutKeys      = Keys.Control | Keys.C;
            Menu(PasteMenu).ShortcutKeys     = Keys.Control | Keys.V;
            Menu(SelectAllMenu).ShortcutKeys = Keys.Control | Keys.A;
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
                CutMenu,
                CopyMenu,
                PasteMenu,
                new ToolStripSeparator(),
                UndoMenu,
                RedoMenu,
                new ToolStripSeparator(),
                SearchMenu,
                GoogleMenu,
                new ToolStripSeparator(),
                SelectAllMenu,
            });
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Menu
        /// 
        /// <summary>
        /// ToolStripMenuItem にキャストします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private ToolStripMenuItem Menu(ToolStripItem src)
            => src as ToolStripMenuItem;

        #endregion
    }
}
