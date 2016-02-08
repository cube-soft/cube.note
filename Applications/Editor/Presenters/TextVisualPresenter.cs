/* ------------------------------------------------------------------------- */
///
/// TextVisualPresenter.cs
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

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// TextVisualPresenter
    /// 
    /// <summary>
    /// TextControl の外観と SettingsValue を関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class TextVisualPresenter : Cube.Forms.PresenterBase<TextControl, SettingsValue>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TextVisualPresenter
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TextVisualPresenter(TextControl view, SettingsValue model) : base(view, model)
        {
            Model.PropertyChanged += Model_PropertyChanged;

            SyncToView();
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// Model_PropertyChanged
        ///
        /// <summary>
        /// Model の内容が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                Sync(() =>
                {
                    switch (e.PropertyName)
                    {
                        case "Font":
                            View.Font = Model.Font;
                            break;
                        case "BackColor":
                            View.BackColor = Model.BackColor;
                            break;
                        case "ForeColor":
                            View.ForeColor = Model.ForeColor;
                            break;
                        case "HighlightBackColor":
                            View.ColorScheme.SelectionBack = Model.HighlightBackColor;
                            View.ColorScheme.MatchedBracketBack = Model.HighlightBackColor;
                            View.ColorScheme.DirtyLineBar = Model.HighlightBackColor;
                            break;
                        case "HighlightForeColor":
                            View.ColorScheme.SelectionFore = Model.HighlightForeColor;
                            View.ColorScheme.MatchedBracketFore = Model.HighlightForeColor;
                            break;
                        case "LineNumberBackColor":
                            View.ColorScheme.LineNumberBack = Model.LineNumberBackColor;
                            View.ColorScheme.CleanedLineBar = Model.LineNumberBackColor;
                            break;
                        case "LineNumberForeColor":
                            View.ColorScheme.LineNumberFore = Model.LineNumberForeColor;
                            break;
                        case "SpecialCharsColor":
                            View.ColorScheme.WhiteSpaceColor = Model.SpecialCharsColor;
                            View.ColorScheme.EofColor = Model.SpecialCharsColor;
                            View.ColorScheme.EolColor = Model.SpecialCharsColor;
                            break;
                        case "CurrentLineColor":
                            View.ColorScheme.HighlightColor = Model.CurrentLineColor;
                            break;
                        case "TabWidth":
                            View.TabWidth = Model.TabWidth;
                            break;
                        case "TabToSpace":
                            View.ConvertsTabToSpaces = Model.TabToSpace;
                            break;
                        case "LineNumberVisible":
                            View.ShowsLineNumber = Model.LineNumberVisible;
                            break;
                        case "RulerVisible":
                            View.ShowsHRuler = Model.RulerVisible;
                            break;
                        case "EolVisible":
                            View.DrawsEolCode = Model.SpecialCharsVisible && Model.EolVisible;
                            break;
                        case "TabVisible":
                            View.DrawsTab = Model.SpecialCharsVisible && Model.TabVisible;
                            break;
                        case "SpaceVisible":
                            View.DrawsSpace = Model.SpecialCharsVisible && Model.SpaceVisible;
                            break;
                        case "FullSpaceVisible":
                            View.DrawsFullWidthSpace = Model.SpecialCharsVisible && Model.FullSpaceVisible;
                            break;
                        case "SpecialCharsVisible":
                            UpdateSpecialCharsVisible();
                            break;
                        case "CurrentLineVisible":
                            View.HighlightsCurrentLine = Model.CurrentLineVisible;
                            break;
                        case "ModifiedLineVisible":
                            View.ShowsDirtBar = Model.ModifiedLineVisible;
                            break;
                        case "BracketVisible":
                            View.HighlightsMatchedBracket = Model.BracketVisible;
                            break;
                        default:
                            return;
                    }

                    View.Refresh();
                });
            }
            catch (Exception err) { Logger.Error(err); }
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// SyncToView
        ///
        /// <summary>
        /// Model の内容を View に反映させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void SyncToView()
        {
            Sync(() =>
            {
                View.Font                           = Model.Font;
                View.BackColor                      = Model.BackColor;
                View.ForeColor                      = Model.ForeColor;
                View.ColorScheme.SelectionBack      = Model.HighlightBackColor;
                View.ColorScheme.MatchedBracketBack = Model.HighlightBackColor;
                View.ColorScheme.DirtyLineBar       = Model.HighlightBackColor;
                View.ColorScheme.SelectionFore      = Model.HighlightForeColor;
                View.ColorScheme.MatchedBracketFore = Model.HighlightForeColor;
                View.ColorScheme.LineNumberBack     = Model.LineNumberBackColor;
                View.ColorScheme.CleanedLineBar     = Model.LineNumberBackColor;
                View.ColorScheme.LineNumberFore     = Model.LineNumberForeColor;
                View.ColorScheme.WhiteSpaceColor    = Model.SpecialCharsColor;
                View.ColorScheme.EolColor           = Model.SpecialCharsColor;
                View.ColorScheme.EofColor           = Model.SpecialCharsColor;
                View.ColorScheme.HighlightColor     = Model.CurrentLineColor;
                View.TabWidth                       = Model.TabWidth;
                View.ConvertsTabToSpaces            = Model.TabToSpace;
                View.ShowsLineNumber                = Model.LineNumberVisible;
                View.ShowsHRuler                    = Model.RulerVisible;
                View.HighlightsCurrentLine          = Model.CurrentLineVisible;
                View.ShowsDirtBar                   = Model.ModifiedLineVisible;
                View.HighlightsMatchedBracket       = Model.BracketVisible;

                UpdateSpecialCharsVisible();

                View.ViewWidth = 0;
            });
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateSpecialCharsVisible
        ///
        /// <summary>
        /// 特殊文字の表示に関する設定を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateSpecialCharsVisible()
        {
            var enable = Model.SpecialCharsVisible;

            View.DrawsEolCode        = enable && Model.EolVisible;
            View.DrawsTab            = enable && Model.TabVisible;
            View.DrawsSpace          = enable && Model.SpaceVisible;
            View.DrawsFullWidthSpace = enable && Model.FullSpaceVisible;
        }

        #endregion
    }
}
