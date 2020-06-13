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
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// Dialogs
    ///
    /// <summary>
    /// 各種ダイアログを生成するためのクラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public static class Dialogs
    {
        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Import
        ///
        /// <summary>
        /// インポート用ダイアログを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static OpenFileDialog Import()
        {
            var dialog = new OpenFileDialog();

            dialog.Title           = Properties.Resources.ImportTitle;
            dialog.Filter          = Properties.Resources.TextFilter;
            dialog.CheckFileExists = true;
            dialog.Multiselect     = false;

            return dialog;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Export
        ///
        /// <summary>
        /// エクスポート用ダイアログを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static SaveFileDialog Export(string filename, int limit)
        {
            var dest = new SaveFileDialog();

            dest.FileName        = filename.Length <= limit ?
                                   filename :
                                   filename.Substring(0, limit);
            dest.Filter          = Properties.Resources.TextFilter;
            dest.OverwritePrompt = true;

            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Print
        ///
        /// <summary>
        /// 印刷用ダイアログを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static PrintDialog Print()
            => new PrintDialog
        {
            AllowPrintToFile = false,
            AllowSelection   = true,
            UseEXDialog      = true
        };

        /* ----------------------------------------------------------------- */
        ///
        /// Property
        ///
        /// <summary>
        /// プロパティ用ダイアログ（タグの設定）を生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static PropertyForm Property(Form owner, Page page, IEnumerable<Tag> tags)
        {
            var dest = new PropertyForm(page, tags);
            dest.StartPosition = FormStartPosition.Manual;
            dest.Location = CreateLocation(owner);
            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Settings
        ///
        /// <summary>
        /// 設定用ダイアログを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static SettingsForm Settings(Form owner, SettingsFolder model)
        {
            var dest = new SettingsForm(model.User);

            dest.DataFolder     = model.Root;
            dest.Product        = new AssemblyReader(model.Assembly).Product;
            dest.Version        = model.Version.ToString(true);
            dest.StartPosition  = FormStartPosition.Manual;
            dest.Location = CreateLocation(owner);

            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// TagSettings
        ///
        /// <summary>
        /// タグ設定用ダイアログを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static TagForm TagSettings(Form owner, TagCollection model, SettingsValue settings)
        {
            var dest = new TagForm(model);

            dest.StartPosition = FormStartPosition.Manual;
            dest.Location = CreateLocation(owner);
            dest.FormClosing += (s, e) =>
            {
                e.Cancel = CancelTagRemoving(s, settings.TagRemoveWarning);
            };

            return dest;
        }

        #region MessageBox

        /* ----------------------------------------------------------------- */
        ///
        /// Remove
        ///
        /// <summary>
        /// ページを削除するかどうかを確認するメッセージを表示します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static DialogResult Remove(Page page)
        {
            var message = new System.Text.StringBuilder();
            message.AppendLine(Properties.Resources.WarnRemove);
            message.AppendLine();
            message.AppendLine(page.GetAbstract());
            message.AppendLine(page.Creation.ToString(Properties.Resources.CreationFormat));
            message.AppendLine(page.LastUpdate.ToString(Properties.Resources.LastUpdateFormat));

            return MessageBox.Show(
                message.ToString(),
                Properties.Resources.WarnRemoveTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1
            );
        }

        #endregion

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// CreateLocation
        ///
        /// <summary>
        /// 表示位置を表すオブジェクトを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private static Point CreateLocation(Form owner)
        {
            var offset = 20;
            return owner != null ?
                   new Point(owner.Left + offset, owner.Top + offset) :
                   new Point(offset, offset);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CancelTagRemoving
        ///
        /// <summary>
        /// タグの削除がキャンセルされたかどうか判別します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private static bool CancelTagRemoving(object sender, bool force)
        {
            var dialog = sender as TagForm;
            if (dialog == null) return false;

            if (dialog.DialogResult == DialogResult.Cancel ||
                dialog.RemoveTags.Count <= 0 ||
                force) return false;

            var result = MessageBox.Show(
                Properties.Resources.WarnTagRemove,
                Properties.Resources.WarnTagRemoveTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1
            );
            return result == DialogResult.No;
        }

        #endregion
    }
}
