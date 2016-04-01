/* ------------------------------------------------------------------------- */
///
/// PageMenuControl.cs
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
    /// PageMenuControl
    /// 
    /// <summary>
    /// ページリスト上で表示されるコンテキストメニューを表すクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class PageMenuControl : ContextMenuStrip
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// PageMenuControl
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageMenuControl() : base()
        {
            NewPageMenu   = new ToolStripMenuItem(Properties.Resources.MenuNewPage);
            ImportMenu    = new ToolStripMenuItem(Properties.Resources.MenuImport);
            ExportMenu    = new ToolStripMenuItem(Properties.Resources.MenuExport);
            DuplicateMenu = new ToolStripMenuItem(Properties.Resources.MenuDuplicate);
            RemoveMenu    = new ToolStripMenuItem(Properties.Resources.MenuRemove);
            UpMenu        = new ToolStripMenuItem(Properties.Resources.MenuUp);
            DownMenu      = new ToolStripMenuItem(Properties.Resources.MenuDown);
            PropertyMenu  = new ToolStripMenuItem(Properties.Resources.MenuProperty);

            InitialzieShortcutKeys();
            InitializeEvents();
            InitializeMenu();
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Aggregator
        ///
        /// <summary>
        /// イベントを集約するオブジェクトを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public EventAggregator Aggregator { get; set; }

        /* ----------------------------------------------------------------- */
        ///
        /// NewPageMenu
        /// 
        /// <summary>
        /// 新規作成メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem NewPageMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// ImportMenu
        /// 
        /// <summary>
        /// インポートメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem ImportMenu { get; }

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
        /// DuplicateMenu
        /// 
        /// <summary>
        /// 複製メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem DuplicateMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// RemoveMenu
        /// 
        /// <summary>
        /// 削除メニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem RemoveMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// UpMenu
        /// 
        /// <summary>
        /// 上へメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem UpMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// DownMenu
        /// 
        /// <summary>
        /// 下へメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem DownMenu { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// PropertyMenu
        /// 
        /// <summary>
        /// プロパティメニューを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ToolStripItem PropertyMenu { get; }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// InitialzieShortcutKeys
        /// 
        /// <summary>
        /// ショートカットキーを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitialzieShortcutKeys()
        {
            Menu(NewPageMenu).ShortcutKeys   = Keys.Control | Keys.Shift | Keys.N;
            Menu(ImportMenu).ShortcutKeys    = Keys.Control | Keys.O;
            Menu(ExportMenu).ShortcutKeys    = Keys.Control | Keys.E;
            Menu(DuplicateMenu).ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
            Menu(RemoveMenu).ShortcutKeys    = Keys.Control | Keys.D;
            Menu(UpMenu).ShortcutKeys        = Keys.Control | Keys.Up;
            Menu(DownMenu).ShortcutKeys      = Keys.Control | Keys.Down;
            Menu(PropertyMenu).ShortcutKeys  = Keys.Control | Keys.R;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeEvents
        /// 
        /// <summary>
        /// 項目のイベントを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeEvents()
        {
            NewPageMenu.Click += (s, e)
                => Aggregator?.NewPage.Raise(EventAggregator.Selected);
            ImportMenu.Click += (s, e)
                => Aggregator?.Import.Raise(KeyValueEventArgs.Create(-1, ""));
            ExportMenu.Click += (s, e)
                => Aggregator?.Export.Raise(EventAggregator.Selected);
            DuplicateMenu.Click += (s, e)
                => Aggregator?.Duplicate.Raise(EventAggregator.Selected);
            RemoveMenu.Click += (s, e)
                => Aggregator?.Remove.Raise(EventAggregator.Selected);
            UpMenu.Click += (s, e)
                => Aggregator?.Move.Raise(ValueEventArgs.Create(-1));
            DownMenu.Click += (s, e)
                => Aggregator?.Move.Raise(ValueEventArgs.Create(1));
            PropertyMenu.Click += (s, e)
                => Aggregator?.Property.Raise(EventAggregator.Selected);
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
                NewPageMenu,
                DuplicateMenu,
                new ToolStripSeparator(),
                PropertyMenu,
                new ToolStripSeparator(),
                UpMenu,
                DownMenu,
                new ToolStripSeparator(),
                ImportMenu,
                ExportMenu,
                new ToolStripSeparator(),
                RemoveMenu,
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
