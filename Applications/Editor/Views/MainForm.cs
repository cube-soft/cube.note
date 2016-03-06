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
using log4net;

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
            Logger = LogManager.GetLogger(GetType());

            InitializeComponent();
            InitializeModels();

            Caption = TitleControl;
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

            new MenuPresenter(MenuControl, Pages, Settings, Aggregator);
            new TextPresenter(TextControl, Pages, Settings, Aggregator);
            new TextVisualPresenter(TextControl, /* User, */ Settings, Aggregator);
            new PageCollectionPresenter(PageCollectionControl.Pages, Pages, Settings, Aggregator);
            new TagCollectionPresenter(PageCollectionControl.Tags, Pages, Settings, Aggregator);
            new SearchPresenter(SearchControl, Pages, Settings, Aggregator);
            new NewsPresenter(FooterStatusControl, Settings, Aggregator);
        }

        #endregion

        #region Properties

        /* --------------------------------------------------------------------- */
        ///
        /// Logger
        /// 
        /// <summary>
        /// ログ出力用オブジェクトを取得します。
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        [Browsable(false)]
        public ILog Logger { get; }

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
            new Cube.Forms.SizeHacker(ContentsPanel, SizeGrip);
            Saver = new AutoSaver(Pages, Settings);
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
            base.OnFormClosing(e);
            Settings.User.X      = Location.X;
            Settings.User.Y      = Location.Y;
            Settings.User.Width  = Width;
            Settings.User.Height = Height;
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
                if (!e.Control && !e.Alt) return;

                var result = true;
                switch (e.KeyCode)
                {
                    case Keys.C:
                        if (e.Shift) Aggregator.Duplicate.Raise(EventAggregator.SelectedPage);
                        else result = false;
                        break;
                    case Keys.D:
                        Aggregator.Remove.Raise(EventAggregator.SelectedPage);
                        break;
                    case Keys.E:
                        Aggregator.Export.Raise(EventAggregator.SelectedPage);
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
                            EventAggregator.SelectedPage :
                            EventAggregator.TopPage
                        );
                        break;
                    case Keys.O:
                        Aggregator.Import.Raise(KeyValueEventArgs.Create(0, ""));
                        break;
                    case Keys.R:
                        if (e.Shift) Aggregator.TagSettings.Raise();
                        else RaiseProperty();
                        break;
                    case Keys.S:
                        if (e.Shift) Aggregator.Export.Raise(EventAggregator.SelectedPage);
                        else result = false;
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
                         Properties.Resources.VisibleMenu :
                         Properties.Resources.HideMenu;

            MenuControl.VisibleMenu.Text = text;
            MenuControl.VisibleMenu.ToolTipText = text;
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
        /// RaiseProperty
        ///
        /// <summary>
        /// プロパティ表示のためのイベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RaiseProperty()
            => Aggregator.Property.Raise(EventAggregator.SelectedPage);

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
        private PageCollection Pages = new PageCollection(Assembly.GetEntryAssembly());
        private SettingsFolder Settings = new SettingsFolder(Assembly.GetEntryAssembly());
        private EventAggregator Aggregator = new EventAggregator();
        private AutoSaver Saver = null;
        #endregion

        #region Views
        private SearchForm SearchControl = new SearchForm();
        private TextMenuControl TextMenuControl = new TextMenuControl();
        #endregion
    }
}
