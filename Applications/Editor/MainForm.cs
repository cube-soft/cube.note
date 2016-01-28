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
    public partial class MainForm : Cube.Forms.Form
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
            InitializeColorScheme();

            FontMenuItem.Click += (s, e) => ChangeFont();
            VisibleMenuItem.Click += (s, e) => ChangeMenuPanelVisibility();

            VisibleMenuItem.Tag = true;
        }

        #endregion

        #region Other private methods

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeColorScheme
        ///
        /// <summary>
        /// テキストエディタ部の色を初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeColorScheme()
        {
            var colors = TextEditor.ColorScheme;
            colors.LineNumberBack = SystemColors.Control;
            colors.LineNumberFore = SystemColors.ControlDark;
            colors.SelectionBack  = SystemColors.Highlight;
            colors.SelectionFore  = SystemColors.HighlightText;
            colors.EolColor       = colors.WhiteSpaceColor;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ChangeFont
        ///
        /// <summary>
        /// 使用するフォントを変更します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ChangeFont()
        {
            var dialog = new FontDialog();
            dialog.Font = TextEditor.Font;
            dialog.Color = TextEditor.ForeColor;
            dialog.ShowEffects = false;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;

            TextEditor.Font = dialog.Font;
            TextEditor.ForeColor = dialog.Color;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ChangeMenuPanelVisibility
        ///
        /// <summary>
        /// 左側のメニューパネルの表示状態を変更します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ChangeMenuPanelVisibility()
        {
            var visible = !(bool)VisibleMenuItem.Tag;
            var text    = visible ?
                          Properties.Resources.HideMenu :
                          Properties.Resources.VisibleMenu;
            var image   = visible ?
                          Properties.Resources.ArrowLeft :
                          Properties.Resources.ArrowRight;

            VisibleMenuItem.Image = image;
            VisibleMenuItem.Text = text;
            VisibleMenuItem.ToolTipText = text;
            VisibleMenuItem.Tag = visible;
            ContentsPanel.Panel1Collapsed = !visible;
        }

        #endregion
    }
}
