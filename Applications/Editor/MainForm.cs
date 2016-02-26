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
            InitializeEvents();
            InitializePresenters();

            Caption = TitleControl;
            TextControl.Status = FooterStatusControl;
            MenuToolStrip.Renderer = new MenuRenderer(MenuToolStrip.BackColor);
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
            VisibleMenuItem.Click += (s, e) => SwitchMenu();
            UndoMenuItem.Click += (s, e) => Aggregator.Undo.Raise();
            RedoMenuItem.Click += (s, e) => Aggregator.Redo.Raise();
            SearchMenuItem.Click += (s, e) => RaiseSearch();
            LogoMenuItem.Click += LogoMenuItem_Click;
            SettingsMenuItem.Click += SettingsMenuItem_Click;

            ContentsPanel.Panel2.ClientSizeChanged += ContentsPanel2_ClientSizeChanged;

            // TODO: Presenter に移譲
            Aggregator.TagSettings.Handle += SettingsMenuItem_Click;
            Settings.Current.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(Settings.Current.CanUndo):
                        UndoMenuItem.Enabled = Settings.Current.CanUndo;
                        break;
                    case nameof(Settings.Current.CanRedo):
                        RedoMenuItem.Enabled = Settings.Current.CanRedo;
                        break;
                    default:
                        break;
                }
            };
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
            Pages.Everyone = new Tag(Properties.Resources.EveryoneTag);
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
            SearchControl.Aggregator = Aggregator;

            new TextPresenter(TextControl, Pages, Settings, Aggregator);
            new TextVisualPresenter(TextControl, /* User, */ Settings, Aggregator);
            new PageCollectionPresenter(PageCollectionControl.Pages, Pages, Settings, Aggregator);
            new TagCollectionPresenter(PageCollectionControl.Tags, Pages, Settings, Aggregator);
            new SearchPresenter(SearchControl, Pages, Settings, Aggregator);
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
        public ILog Logger { get; }

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
            Saver = new AutoSaver(Pages, Settings);
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
                        Aggregator.Remove.Raise();
                        break;
                    case Keys.E:
                        Aggregator.Export.Raise();
                        break;
                    case Keys.F:
                        RaiseSearch();
                        break;
                    case Keys.H:
                        SwitchMenu();
                        break;
                    case Keys.J:
                    case Keys.Down:
                        Aggregator.Move.Raise(new ValueEventArgs<int>(1));
                        break;
                    case Keys.K:
                    case Keys.Up:
                        Aggregator.Move.Raise(new ValueEventArgs<int>(-1));
                        break;
                    case Keys.N:
                        Aggregator.NewPage.Raise();
                        break;
                    case Keys.T:
                        RaiseProperty();
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
            catch (Exception err) { Logger.Error(err); }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsMenuItem_Click
        ///
        /// <summary>
        /// 設定メニューが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            var view = new SettingsForm(Settings.User);
            using (var presenter = new SettingsPresenter(view, /* User, */ Settings, Aggregator))
            {
                view.ShowDialog(this);
                TextControl.ResetViewWidth(); // refresh
            }
        }

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

            VisibleMenuItem.Text = text;
            VisibleMenuItem.ToolTipText = text;
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
        public Control FindActive(Control control)
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
        private void RaiseProperty() => Aggregator.Property.Raise();

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
            var control = FindActive(ActiveControl);
            var index = (control == TextControl) ? 0 : 1;
            Aggregator.SearchMode.Raise(new ValueEventArgs<int>(index));
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
        #endregion
    }
}
