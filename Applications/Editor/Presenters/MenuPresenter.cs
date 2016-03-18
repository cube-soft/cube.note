/* ------------------------------------------------------------------------- */
///
/// MenuPresenter.cs
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using Cube.Conversions;
using Cube.Note.Azuki;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// MenuPresenter
    /// 
    /// <summary>
    /// MenuControl とモデルを関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class MenuPresenter
        : PresenterBase<MenuControl, PageCollection>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// MenuPresenter
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public MenuPresenter(MenuControl view, PageCollection model,
            SettingsFolder settings, EventAggregator events)
            : base(view, model, settings, events)
        {
            Events.Print.Handle += Print_Handle;
            Events.Web.Handle += Web_Handle;
            Events.Google.Handle += Google_Handle;
            Events.Settings.Handle += (s, e) => ShowSettings(0);
            Events.TagSettings.Handle += (s, e) => ShowTagSettings();

            View.UndoMenu.Click += (s, e) => Events.Undo.Raise();
            View.RedoMenu.Click += (s, e) => Events.Redo.Raise();
            View.ExportMenu.Click += (s, e) => Events.Export.Raise(EventAggregator.SelectedPage);
            View.PrintMenu.Click += (s, e) => Events.Print.Raise();
            View.SettingsMenu.Click += (s, e) => Events.Settings.Raise();
            View.LogoMenu.Click += View_LogoMenu;

            Settings.Current.PropertyChanged += Settings_CurrentChanged;
        }

        #endregion

        #region Event handlers

        #region EventAggregator

        /* ----------------------------------------------------------------- */
        ///
        /// Print_Handle
        /// 
        /// <summary>
        /// 印刷時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Print_Handle(object sender, EventArgs e)
            => SyncWait(() =>
        {
            var dialog = CreatePrintDialog();
            if (dialog.ShowDialog() == DialogResult.Cancel) return;

            var text = GetText(dialog.PrinterSettings.PrintRange == PrintRange.Selection);
            if (text == null) return;

            var document = new PrintDocument();
            document.DocumentName = Settings.Current.Page.Abstract;
            document.PrinterSettings = dialog.PrinterSettings;
            document.DefaultPageSettings.Margins = CreateMargins(Settings.User.PrintMargin);
            document.PrintPage += (s, ev) =>
            {
                var font   = Settings.User.Font;
                var bounds = ev.MarginBounds;
                var format = StringFormat.GenericTypographic;
                var brush  = Brushes.Black;
                var offset = 0;
                var lines  = 0;

                ev.Graphics.MeasureString(text, font, bounds.Size, format, out offset, out lines);
                ev.Graphics.DrawString(text, font, brush, bounds, format);

                text = text.Substring(offset);
                ev.HasMorePages = (text.Length > 0);
            };
            document.Print();
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Web_Handle
        /// 
        /// <summary>
        /// 既定のブラウザで URL を開く時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Web_Handle(object sender, ValueEventArgs<string> e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.Value)) return;
                var uri = new Uri(e.Value).With(Settings.UriQuery);
                System.Diagnostics.Process.Start(uri.ToString());
            }
            catch (Exception err) { Logger.Error(err); }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Google_Handle
        /// 
        /// <summary>
        /// インターネットで検索時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Google_Handle(object sender, ValueEventArgs<string> e)
        {
            if (string.IsNullOrEmpty(e.Value)) return;
            Events.Web.Raise(ValueEventArgs.Create(Settings.User.SearchQuery + e.Value));
        }

        #endregion

        #region View

        /* ----------------------------------------------------------------- */
        ///
        /// View_LogoMenu
        /// 
        /// <summary>
        /// ロゴメニューがクリックされた時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_LogoMenu(object sender, EventArgs e)
            => Events.Web.Raise(ValueEventArgs.Create(Properties.Resources.WebUrl));

        #endregion

        #region Settings

        /* ----------------------------------------------------------------- */
        ///
        /// Settings_CurrentChanged
        /// 
        /// <summary>
        /// プロパティの内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Settings_CurrentChanged(object sender,
            PropertyChangedEventArgs e) => Sync(() =>
        {
            switch (e.PropertyName)
            {
                case nameof(Settings.Current.CanUndo):
                    View.UndoMenu.Enabled = Settings.Current.CanUndo;
                    break;
                case nameof(Settings.Current.CanRedo):
                    View.RedoMenu.Enabled = Settings.Current.CanRedo;
                    break;
                default:
                    break;
            }
        });

        #endregion

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// GetText
        /// 
        /// <summary>
        /// テキストを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private string GetText(bool selection)
        {
            var page = Settings.Current.Page;
            if (page == null) return null;

            var document = page.Document as Sgry.Azuki.Document;
            if (document == null) return null;

            return selection ? document.GetSelectedText() : document.Text;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CreatePrintDialog
        /// 
        /// <summary>
        /// PrintDialog オブジェクトを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private PrintDialog CreatePrintDialog() => new PrintDialog
        {
            AllowPrintToFile = false,
            AllowSelection   = true,
            UseEXDialog      = true
        };

        /* ----------------------------------------------------------------- */
        ///
        /// CreateMargins
        /// 
        /// <summary>
        /// Margins オブジェクトを生成します。
        /// </summary>
        /// 
        /// <remarks>
        /// GUI 等の都合で Settings.User.PrintMargin は mm 単位で値を保持して
        /// います。そこで、実際に値を適用する時に 1/100 インチ単位に変換します。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        private Margins CreateMargins(Margins src) => new Margins
        {
            // mm -> 1/100 inch (1 inch = 25.4 mm)
            Left   = (int)(src.Left   / 0.254f),
            Right  = (int)(src.Right  / 0.254f),
            Top    = (int)(src.Top    / 0.254f),
            Bottom = (int)(src.Bottom / 0.254f)
        };

        /* ----------------------------------------------------------------- */
        ///
        /// ShowSettings
        /// 
        /// <summary>
        /// 設定フォームを開きます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ShowSettings(int index)
            => Sync(() =>
        {
            var dialog = new SettingsForm(Settings.User, index);
            using (var presenter = new SettingsPresenter(dialog, /* User, */ Settings, Events))
            {
                dialog.ShowDialog();
                Events.Refresh.Raise();
            }
        });

        /* ----------------------------------------------------------------- */
        ///
        /// ShowTagSettings
        /// 
        /// <summary>
        /// タグ設定フォームを開きます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ShowTagSettings()
            => Sync(() =>
        {
            var dialog = new TagForm(Model.Tags);
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.Cancel) return;

            var add = dialog.NewTags;
            var remove = dialog.RemoveTags;

            Async(() =>
            {
                foreach (var tag in add) Events.NewTag.Raise(ValueEventArgs.Create(tag));
                foreach (var tag in remove) Events.RemoveTag.Raise(ValueEventArgs.Create(tag));
            });
        });

        #endregion
    }
}
