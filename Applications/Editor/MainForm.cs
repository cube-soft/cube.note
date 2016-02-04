/* ------------------------------------------------------------------------- */
///
/// MainForm.cs
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
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// MainForm
    /// 
    /// <summary>
    /// メイン画面を表示するクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class MainForm : Cube.Forms.WidgetForm
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// MainForm
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public MainForm()
        {
            InitializeComponent();
            InitializeEvents();
            InitializePresenters();
        }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Maximize
        ///
        /// <summary>
        /// 最大化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Maximize()
        {
            WindowState = WindowState == FormWindowState.Normal ?
                          FormWindowState.Maximized :
                          FormWindowState.Normal;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Minimize
        ///
        /// <summary>
        /// 最小化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Minimize()
        {
            if (WindowState == FormWindowState.Minimized) return;
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Initialize methods

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeEvents
        ///
        /// <summary>
        /// 各種イベントハンドラを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeEvents()
        {
            Activated  += (s, e) => BackColor = Color.FromArgb(  0, 169, 157);
            Deactivate += (s, e) => BackColor = Color.FromArgb(186, 224, 215);

            TitleControl.CloseRequired    += (s, e) => Close();
            TitleControl.MaximizeRequired += (s, e) => Maximize();
            TitleControl.MinimizeRequired += (s, e) => Minimize();

            NewPageMenuItem.Click  += NewPageMenuItem_Click;
            RemoveMenuItem.Click   += RemoveMenuItem_Click;
            SearchMenuItem.Click   += SearchMenuItem_Click;
            VisibleMenuItem.Click  += VisibleMenuItem_Click;
            LogoMenuItem.Click     += LogoMenuItem_Click;
            SettingsMenuItem.Click += (s, e) => TextEditControl.SelectFont();

            PageCollectionControl.ParentChanged += PageCollectionControl_ParentChanged;
            ContentsPanel.Panel2.ClientSizeChanged += ContentsPanel2_ClientSizeChanged;
        }

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
            var area = Screen.FromControl(this).WorkingArea.Size;
            Width   = (int)(area.Width  * 0.7);
            Height  = (int)(area.Height * 0.7);
            Caption = TitleControl;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InitializePresenters
        ///
        /// <summary>
        /// 各種 Presenter を初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializePresenters()
        {
            new TextEditPresenter(TextEditControl, Pages);
            new PageCollectionPresenter(PageCollectionControl, Pages);
            new SearchPresenter(SearchControl, Pages);
        }

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnLoad
        ///
        /// <summary>
        /// ロード時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeLayout();
            Saver = new AutoSaver(Pages);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnBackColorChanged
        ///
        /// <summary>
        /// 背景色が変更された時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            TitleControl.BackColor = BackColor;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnKeyDown
        ///
        /// <summary>
        /// キーが押下された時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                if (!e.Control) return;

                var result = true;
                switch (e.KeyCode)
                {
                    case Keys.D:
                        RemoveMenuItem_Click(this, e);
                        break;
                    case Keys.F:
                        SearchMenuItem_Click(this, e);
                        break;
                    case Keys.N:
                        NewPageMenuItem_Click(this, e);
                        break;
                    default:
                        result = false;
                        break;
                }
                e.Handled = result;
            }
            finally { base.OnKeyDown(e); }
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// NewPageMenuItem_Click
        ///
        /// <summary>
        /// 新規追加メニューが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void NewPageMenuItem_Click(object sender, EventArgs e)
        {
            PageCollectionControl.NewPage();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// RemoveMenuItem_Click
        ///
        /// <summary>
        /// 削除メニューが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            PageCollectionControl.Pages.RemoveItems();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SearchMenuItem_Click
        ///
        /// <summary>
        /// 検索メニューが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void SearchMenuItem_Click(object sender, EventArgs e)
        {
            SearchControl.Switch(ContentsPanel.Panel1);

            if (IsActive(SearchControl))
            {
                SearchMenuItem.Image = Properties.Resources.SearchEnd;
                ContentsPanel.Panel1Collapsed = false;
            }
            else SearchMenuItem.Image = Properties.Resources.Search;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// VisibleMenuItem_Click
        ///
        /// <summary>
        /// 表示方法の変更メニューが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void VisibleMenuItem_Click(object sender, EventArgs e)
        {
            ContentsPanel.Panel1Collapsed = !ContentsPanel.Panel1Collapsed;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LogoMenuItem_Click
        ///
        /// <summary>
        /// ロゴが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void LogoMenuItem_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start(Properties.Resources.WebUrl); }
            catch (Exception /* err */) { /* ignore errors */ }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PageCollectionControl_ParentChanged
        ///
        /// <summary>
        /// 親コントロールが変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void PageCollectionControl_ParentChanged(object sender, EventArgs e)
        {
            var active = IsActive(PageCollectionControl);
            NewPageMenuItem.Enabled = active;
            RemoveMenuItem.Enabled = active;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ContentsPanel2_ClientSizeChanged
        ///
        /// <summary>
        /// ページリストの表示方法が変更された時に実行されるハンドラです。
        /// </summary>
        /// 
        /// <remarks>
        /// ContentsPanel.Panel1Collapsed の変更を通知するイベントが
        /// 存在しないため Panel2 側のサイズ変更イベントで代替します。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        private void ContentsPanel2_ClientSizeChanged(object sender, EventArgs e)
        {
            var hidden = ContentsPanel.Panel1Collapsed;
            var text   = hidden ?
                         Properties.Resources.VisibleMenu :
                         Properties.Resources.HideMenu;

            VisibleMenuItem.Text = text;
            VisibleMenuItem.ToolTipText = text;
        }

        #endregion

        #region Other private methods

        /* ----------------------------------------------------------------- */
        ///
        /// IsActive
        ///
        /// <summary>
        /// コントロールがアクティブ状態になっているかどうかを判別します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private bool IsActive(Control control)
        {
            return control.Parent == ContentsPanel.Panel1;
        }

        #endregion

        #region Models
        private PageCollection Pages = new PageCollection(Assembly.GetEntryAssembly());
        private AutoSaver Saver = null;
        #endregion

        #region Views
        private SearchControl SearchControl = new SearchControl();
        #endregion
    }
}
