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

            Caption = TitleControl;
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

            var x = Settings.User.X >= 0 ?
                    Math.Max(Math.Min(Settings.User.X, area.Width), 0) :
                    (int)(area.Width * 0.05);
            var y = Settings.User.Y >= 0 ?
                    Math.Max(Math.Min(Settings.User.Y, area.Height), 0) :
                    (int)(area.Height * 0.05);
            Location = new Point(x, y);

            Width  = Settings.User.Width >= 0 ?
                     Settings.User.Width :
                     (int)(area.Width * 0.7);
            Height = Settings.User.Height >= 0 ?
                     Settings.User.Height :
                     (int)(area.Height * 0.7);
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
            this.LogException(() => Settings.Load());
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

            new MenuPresenter(MenuControl, Pages, Settings, Aggregator);
            new TextPresenter(TextControl, Pages, Settings, Aggregator);
            new TextVisualPresenter(TextControl, /* User, */ Settings, Aggregator);
            new PageCollectionPresenter(PageCollectionControl.Pages, Pages, Settings, Aggregator);
            new TagCollectionPresenter(PageCollectionControl.Tags, Pages, Settings, Aggregator);
            new SearchPresenter(SearchControl, Pages, Settings, Aggregator);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeNetworkPresenters
        ///
        /// <summary>
        /// ネットワーク通信が発生する Presenter を初期化します。
        /// </summary>
        /// 
        /// <remarks>
        /// 通信が発生する事によって起動時間が遅れる事を防ぐため、初期化を
        /// 遅延させます。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeNetworkPresenters()
        {
            new UpdatePresenter(NotifyIcon, Activator, Settings, Aggregator);
            new NewsPresenter(FooterStatusControl, Settings, Aggregator);
        }

        #endregion

        #region Properties

        /* --------------------------------------------------------------------- */
        ///
        /// Activator
        /// 
        /// <summary>
        /// ソフトウェアのアクティブ化を行うためのオブジェクトを取得または設定します。
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Cube.Net.Update.SoftwareActivator Activator { get; set; }

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
            Saver = new AutoSaver(Pages, Settings, Aggregator);
            InitializeNetworkPresenters();
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
                if (e.Control) ShortcutKeysWithCtrl(e);
                else if (e.Alt) return;
                else ShortcutKeys(e);
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
                Aggregator.Import.Raise(args);
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
        /// ShortcutKeys
        ///
        /// <summary>
        /// ショートカットキーを処理します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ShortcutKeys(KeyEventArgs e)
        {
            var result = true;
            switch (e.KeyCode)
            {
                case Keys.F3:
                    if (e.Shift) Aggregator.SearchPrev.Raise();
                    else Aggregator.SearchNext.Raise();
                    break;
                default:
                    result = false;
                    break;
            }
            e.Handled = result;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ShortcutKeysWithCtrl
        ///
        /// <summary>
        /// Ctrl+Keys のショートカットキーを処理します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ShortcutKeysWithCtrl(KeyEventArgs e)
        {
            var result = true;
            switch (e.KeyCode)
            {
                case Keys.C:
                    if (e.Shift) Aggregator.Duplicate.Raise(EventAggregator.Selected);
                    else result = false;
                    break;
                case Keys.D:
                    Aggregator.Remove.Raise(EventAggregator.Selected);
                    break;
                case Keys.E:
                    Aggregator.Export.Raise(EventAggregator.Selected);
                    break;
                case Keys.F:
                    RaiseSearch();
                    break;
                case Keys.G:
                    Aggregator.Google.Raise(ValueEventArgs.Create(SelectedText));
                    break;
                case Keys.H:
                    SwitchMenu();
                    break;
                case Keys.J:
                case Keys.Down:
                    Aggregator.Move.Raise(ValueEventArgs.Create(1));
                    break;
                case Keys.K:
                case Keys.Up:
                    Aggregator.Move.Raise(ValueEventArgs.Create(-1));
                    break;
                case Keys.N:
                    Aggregator.NewPage.Raise(e.Shift ?
                        EventAggregator.Selected :
                        EventAggregator.Top
                    );
                    break;
                case Keys.O:
                    Aggregator.Import.Raise(KeyValueEventArgs.Create(0, ""));
                    break;
                case Keys.P:
                    Aggregator.Print.Raise();
                    break;
                case Keys.R:
                    if (e.Shift) Aggregator.TagSettings.Raise();
                    else Aggregator.Property.Raise(EventAggregator.Selected);
                    break;
                case Keys.S:
                    if (e.Shift) Aggregator.Export.Raise(EventAggregator.Selected);
                    else Aggregator.Save.Raise();
                    break;
                case Keys.T:
                    Aggregator.Settings.Raise();
                    break;
                case Keys.U:
                    Aggregator.TagSettings.Raise();
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
            Aggregator.Search.Raise(KeyValueEventArgs.Create(index, SelectedText));
        }

        #endregion

        #region Models
        private EventAggregator Aggregator = new EventAggregator();
        private SettingsFolder Settings = new SettingsFolder(Assembly.GetExecutingAssembly());
        private PageCollection Pages = null;
        private AutoSaver Saver = null;
        #endregion

        #region Views
        private SearchForm SearchControl = new SearchForm();
        private PageMenuControl PageMenuControl = new PageMenuControl();
        private TextMenuControl TextMenuControl = new TextMenuControl();
        #endregion
    }
}
