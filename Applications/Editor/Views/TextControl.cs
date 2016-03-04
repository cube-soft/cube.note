/* ------------------------------------------------------------------------- */
///
/// TextControl.cs
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
using Sgry.Azuki;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// TextControl
    /// 
    /// <summary>
    /// テキストエディタを表示するクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class TextControl : Sgry.Azuki.WinForms.AzukiControl
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TextControl
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TextControl() : base()
        {
            BackColor   = SystemColors.Window;
            ForeColor   = SystemColors.WindowText;
            BorderStyle = BorderStyle.None;
            LeftMargin  = 8;
            Margin      = new Padding(0);

            ColorScheme.LineNumberBack     = SystemColors.Control;
            ColorScheme.LineNumberFore     = SystemColors.ControlDark;
            ColorScheme.HighlightColor     = ColorScheme.LineNumberFore;
            ColorScheme.SelectionBack      = SystemColors.Highlight;
            ColorScheme.SelectionFore      = SystemColors.HighlightText;
            ColorScheme.MatchedBracketBack = SystemColors.Highlight;
            ColorScheme.MatchedBracketFore = SystemColors.HighlightText;
            ColorScheme.WhiteSpaceColor    = SystemColors.ControlDark;
            ColorScheme.EolColor           = ColorScheme.WhiteSpaceColor;
            ColorScheme.EofColor           = ColorScheme.WhiteSpaceColor;
            ColorScheme.CleanedLineBar     = ColorScheme.LineNumberBack;
            ColorScheme.DirtyLineBar       = SystemColors.Highlight;
            ColorScheme.RightEdgeColor     = BackColor;

            ColorScheme.SetColor(CharClass.Keyword, Color.White, Color.OrangeRed);

            CaretMoved += (s, e) => Report();
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// WordWrapCount
        ///
        /// <summary>
        /// 折り返し文字数を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int WordWrapCount { get; set; } = -1;

        /* ----------------------------------------------------------------- */
        ///
        /// Status
        ///
        /// <summary>
        /// ステータスを表示するためのコントロールを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public StatusControl Status { get; set; }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// ResetViewWidth
        ///
        /// <summary>
        /// ViewWidth をリセットします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void ResetViewWidth()
        {
            ViewWidth = WordWrapCount > 0 ?
                        WordWrapCount * View.HRulerUnitWidth :
                        ClientSize.Width;
        }

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// Refresh
        ///
        /// <summary>
        /// 再描画します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public override void Refresh()
        {
            base.Refresh();
            Report();
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Progress
        ///
        /// <summary>
        /// 現在の状態を表示します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Report()
        {
            if (Status == null) return;

            var count     = (Document != null) ? Document.Length : 0;
            var lineCount = (Document != null) ? Document.LineCount : 0;
            var line      = 0;
            var column    = 0;
            if (Document != null) Document.GetCaretIndex(out line, out column);

            Status.Count        = count - lineCount + 1;
            Status.LineCount    = lineCount;
            Status.LineNumber   = line + 1;
            Status.ColumnNumber = column + 1;
        }

        #endregion
    }
}
