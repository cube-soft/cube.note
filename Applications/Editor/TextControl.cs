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
            ColorScheme.DirtyLineBar       = Color.FromArgb(251, 180, 13);
        }

        #endregion
    }
}
