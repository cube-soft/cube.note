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
using System;
using System.ComponentModel;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using Cube.Log;

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
    public partial class MainForm : FormBase
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
            InitializeModels();

            Aggregator = new EventAggregator();
            Caption = TitleControl;
            PageCollectionControl.Pages.Aggregator = Aggregator.Get();
            PageCollectionControl.Pages.ContextMenuStrip = PageMenuControl;
            TextControl.ContextMenuStrip = TextMenuControl;
            TextControl.Status = FooterStatusControl;

            InitializeEvents();
            InitializePresenters();
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
            MenuControl.VisibleMenu.Click += (s, e) => SwitchMenu();
            MenuControl.SearchMenu.Click += (s, e) => RaiseSearch();
            ContentsPanel.Panel2.ClientSizeChanged += ContentsPanel2_ClientSizeChanged;
            PageCollectionControl.Pages.DragEnter += (s, e) => OnDragEnter(e);
            PageCollectionControl.Pages.DragOver += (s, e) => OnDragEnter(e);
            PageCollectionControl.Pages.DragDrop += (s, e) => OnDragDrop(e);
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

            Width  = Settings.User.Width >= 0 ?
                     Settings.User.Width :
                     (int)(area.Width * 0.7);
            Height = Settings.User.Height >= 0 ?
                     Settings.User.Height :
                     (int)(area.Height * 0.7);

            var x = Settings.User.X >= 0 ?
                    Math.Max(Math.Min(Settings.User.X, area.Width - Width), 0) :
                    (int)(area.Width * 0.05);
            var y = Settings.User.Y >= 0 ?
                    Math.Max(Math.Min(Settings.User.Y, area.Height - Height), 0) :
                    (int)(area.Height * 0.05);
            Location = new Point(x, y);

            SearchControl.StartPosition = FormStartPosition.Manual;
            SearchControl.Location = new Point(Left + 20, Top + 20);

            UpdateLayout(Dpi / BaseDpi);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeModels
        ///
        /// <summary>
        /// 各種モデルの初期化を行います。
        /// </summary>
        /// 
        /// <remarks>
        /// MainForm にはモデルに関する初期化処理は最低限に留めます。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeModels()
        {
            Pages = new PageCollection(Settings.Root);
            Pages.Tags.Everyone.Name = Properties.Resources.EveryoneTag;
            Pages.Tags.Nothing.Name  = Properties.Resources.NothingTag;
            Settings.Load();
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
            PageCollectionControl.Aggregator = Aggregator;
            PageMenuControl.Aggregator = Aggregator;

            new MenuPresenter(MenuControl, Pages, Settings, Aggregator.Get());
            new TextPresenter(TextControl, Pages, Settings, Aggregator.Get());
            new TextVisualPresenter(TextControl, /* User, */ Settings, Aggregator.Get());
            new PageCollectionPresenter(PageCollectionControl.Pages, Pages, Settings, Aggregator.Get());
            new TagCollectionPresenter(PageCollectionControl.Tags, Pages, Settings, Aggregator.Get());
            new SearchPresenter(SearchControl, Pages, Settings, Aggregator.Get());
        }

        #endregion

        #region Properties

        /* --------------------------------------------------------------------- */
        ///
        /// SelectedText
        /// 
        /// <summary>
        /// 選択中のテキストを取得します。
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        [Browsable(false)]
        public string SelectedText
            => TextControl.Enabled ? TextControl.GetSelectedText() : string.Empty;

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
        public override void UpdateLayout(double ratio)
        {
            base.UpdateLayout(ratio);

            LayoutPanel.RowStyles[0].Height = (int)(30 * ratio);
            LayoutPanel.RowStyles[2].Height = (int)(22 * ratio);
            RightContentsPanel.RowStyles[0].Height = (int)(32 * ratio);
            ContentsPanel.SplitterDistance = (int)(270 * ratio);

            var caption = Caption as IDpiAwarable;
            caption?.UpdateLayout(ratio);

            MenuControl.UpdateLayout(ratio);
            PageCollectionControl.UpdateLayout(ratio);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// TextControlIsActive
        ///
        /// <summary>
        /// テキスト部分がアクティブかどうかを判別します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public bool TextControlIsActive()
            => FindActive(ActiveControl) == TextControl;

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnLoad
        ///
        /// <summary>
        /// ロード時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeLayout();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnShown
        ///
        /// <summary>
        /// 初回表示時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Saver = new AutoSaver(Pages, Settings, Aggregator.Get());
            this.LogDebug($"Location:{Location}\tSize:{Size}");
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnFormClosing
        ///
        /// <summary>
        /// フォームが閉じると直前に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                base.OnFormClosing(e);

                if (WindowState != FormWindowState.Normal) return;
                Settings.User.X      = Location.X;
                Settings.User.Y      = Location.Y;
                Settings.User.Width  = Width;
                Settings.User.Height = Height;
            }
            finally { Saver?.Dispose(); }
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
                if (e.Control) RunShortcutKeysWithCtrl(e);
                else if (e.Alt) return;
                else RunShortcutKeys(e);
            }
            finally { base.OnKeyDown(e); }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnDragEnter
        ///
        /// <summary>
        /// ファイルがドラッグされた時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnDragEnter(DragEventArgs e)
        {
            var prev = e.Effect;
            base.OnDragEnter(e);
            if (e.Effect != prev || !e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            e.Effect = DragDropEffects.Copy;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnDragDrop
        ///
        /// <summary>
        /// ファイルがドロップされた時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            var files = e.Data.GetData(DataFormats.FileDrop, false) as string[];
            if (files == null) return;

            foreach (var path in files)
            {
                var args = KeyValueEventArgs.Create(0, path);
                Aggregator.Get().Import.Publish(args);
            }
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// ContentsPanel2_ClientSizeChanged
        ///
        /// <summary>
        /// Panel2 のサイズが変更された時に実行されるハンドラです。
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
            // see remarks
            var hidden = ContentsPanel.Panel1Collapsed;
            var text   = hidden ?
                         Properties.Resources.ToolMenuVisible :
                         Properties.Resources.ToolMenuHide;

            MenuControl.VisibleMenu.Text = text;
            MenuControl.VisibleMenu.ToolTipText = text;
        }

        #endregion

        #region Shortcut keys

        /* ----------------------------------------------------------------- */
        ///
        /// RunShortcutKeys
        ///
        /// <summary>
        /// ショートカットキーを処理します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RunShortcutKeys(KeyEventArgs e)
        {
            var result = true;
            switch (e.KeyCode)
            {
                case Keys.F3:
                    if (e.Shift) Aggregator.Get().SearchPrev.Publish();
                    else Aggregator.Get().SearchNext.Publish();
                    break;
                default:
                    result = false;
                    break;
            }
            e.Handled = result;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// RunShortcutKeysWithCtrl
        ///
        /// <summary>
        /// Ctrl+Keys のショートカットキーを処理します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RunShortcutKeysWithCtrl(KeyEventArgs e)
        {
            var result = true;
            switch (e.KeyCode)
            {
                case Keys.C:
                    if (e.Shift) Aggregator.Get().Duplicate.Publish(EventAggregator.Selected);
                    else result = false;
                    break;
                case Keys.D:
                    Aggregator.Get().Remove.Publish(EventAggregator.Selected);
                    break;
                case Keys.E:
                    Aggregator.Get().Export.Publish(EventAggregator.Selected);
                    break;
                case Keys.F:
                    RaiseSearch();
                    break;
                case Keys.G:
                    Aggregator.Get().Google.Publish(ValueEventArgs.Create(SelectedText));
                    break;
                case Keys.H:
                    SwitchMenu();
                    break;
                case Keys.J:
                case Keys.Down:
                    Aggregator.Get().Move.Publish(ValueEventArgs.Create(1));
                    break;
                case Keys.K:
                case Keys.Up:
                    Aggregator.Get().Move.Publish(ValueEventArgs.Create(-1));
                    break;
                case Keys.N:
                    Aggregator.Get().NewPage.Publish(e.Shift ?
                        EventAggregator.Selected :
                        EventAggregator.Top
                    );
                    break;
                case Keys.O:
                    Aggregator.Get().Import.Publish(KeyValueEventArgs.Create(0, ""));
                    break;
                case Keys.P:
                    Aggregator.Get().Print.Publish();
                    break;
                case Keys.R:
                    if (e.Shift) Aggregator.Get().TagSettings.Publish();
                    else Aggregator.Get().Property.Publish(EventAggregator.Selected);
                    break;
                case Keys.S:
                    if (e.Shift) Aggregator.Get().Export.Publish(EventAggregator.Selected);
                    else Aggregator.Get().Save.Publish();
                    break;
                case Keys.T:
                    Aggregator.Get().Settings.Publish();
                    break;
                case Keys.U:
                    Aggregator.Get().TagSettings.Publish();
                    break;
                default:
                    result = false;
                    break;
            }
            e.Handled = result;
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// FindActive
        ///
        /// <summary>
        /// アクティブなコントロールを検索します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private Control FindActive(Control control)
        {
            var cast = control as IContainerControl;
            return cast != null ? FindActive(cast.ActiveControl) : control;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SwitchMenu
        ///
        /// <summary>
        /// 上部メニューの表示方法を変更します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void SwitchMenu()
            => ContentsPanel.Panel1Collapsed = !ContentsPanel.Panel1Collapsed;

        /* ----------------------------------------------------------------- */
        ///
        /// RaiseSearch
        ///
        /// <summary>
        /// 検索のためのイベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RaiseSearch()
        {
            var index = TextControlIsActive() ? 0 : 1;
            Aggregator.Get().Search.Publish(KeyValueEventArgs.Create(index, SelectedText));
        }

        #endregion

        #region Models
        private readonly SettingsFolder Settings = new SettingsFolder(Assembly.GetExecutingAssembly());
        private PageCollection Pages = null;
        private AutoSaver Saver = null;
        #endregion

        #region Views
        private readonly SearchForm SearchControl = new SearchForm();
        private readonly PageMenuControl PageMenuControl = new PageMenuControl();
        private readonly TextMenuControl TextMenuControl = new TextMenuControl();
        #endregion
    }
}
