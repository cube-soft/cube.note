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
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using Cube.Conversions;
using Cube.Log;
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
            Events.Print.Subscribe(Print_Handle);
            Events.Settings.Subscribe(Settings_Handle);
            Events.TagSettings.Subscribe(TagSettings_Handle);
            Events.Web.Subscribe(Web_Handle);
            Events.Google.Subscribe(Google_Handle);

            View.UndoMenu.Click += (s, e) => Events.Undo.Publish();
            View.RedoMenu.Click += (s, e) => Events.Redo.Publish();
            View.ExportMenu.Click += (s, e) => Events.Export.Publish(EventAggregator.Selected);
            View.PrintMenu.Click += (s, e) => Events.Print.Publish();
            View.SettingsMenu.Click += (s, e) => Events.Settings.Publish();
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
        private void Print_Handle()
            => SyncWait(() =>
        {
            var dialog = Dialogs.Print();
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
        /// Settings_Handle
        ///
        /// <summary>
        /// 設定画面を表示する時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Settings_Handle()
            => Sync(() =>
        {
            var dialog = Dialogs.Settings(View.FindForm(), Settings);
            using (var ps = new SettingsPresenter(dialog, Settings, Events))
            {
                var result = dialog.ShowDialog();
                Events.Refresh.Publish();
                if (result == DialogResult.Cancel) return;
            }

            if (dialog.DataFolder == Settings.Root) return;
            Settings.SaveRoot(dialog.DataFolder);
            if (dialog.RestartRequired) Application.Restart();
        });

        /* ----------------------------------------------------------------- */
        ///
        /// TagSettings_Handle
        ///
        /// <summary>
        /// タグ設定画面を表示する時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private async void TagSettings_Handle()
        {
            var tags = SyncWait(() =>
            {
                var dialog = Dialogs.TagSettings(View.FindForm(), Model.Tags, Settings.User);
                dialog.ShowDialog();
                return dialog.DialogResult == DialogResult.Cancel ?
                       new KeyValuePair<Tag[], Tag[]>(null, null) :
                       new KeyValuePair<Tag[], Tag[]>(
                           dialog.NewTags.ToArray(),
                           dialog.RemoveTags.ToArray()
                       );
            });

            if (tags.Key == null || tags.Value == null) return;

            await Async(() =>
            {
                foreach (var tag in tags.Key) Events.NewTag.Publish(ValueEventArgs.Create(tag));
                foreach (var tag in tags.Value) Events.RemoveTag.Publish(ValueEventArgs.Create(tag));
            });
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Web_Handle
        ///
        /// <summary>
        /// 既定のブラウザで URL を開く時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Web_Handle(ValueEventArgs<string> e)
            => this.LogWarn(() =>
        {
            if (string.IsNullOrEmpty(e.Value)) return;
            var uri = new Uri(e.Value).With(Settings.UriQuery);
            System.Diagnostics.Process.Start(uri.ToString());
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Google_Handle
        ///
        /// <summary>
        /// インターネットで検索時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Google_Handle(ValueEventArgs<string> e)
        {
            if (string.IsNullOrEmpty(e.Value)) return;
            Events.Web.Publish(ValueEventArgs.Create(Settings.User.SearchQuery + e.Value));
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
            => Events.Web.Publish(ValueEventArgs.Create(Properties.Resources.UrlWeb));

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
        private void Settings_CurrentChanged(object sender, PropertyChangedEventArgs e)
            => Sync(() =>
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

        #endregion
    }
}
