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
using System.ComponentModel;

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
    public class TextVisualPresenter : Cube.Forms.PresenterBase<TextControl, SettingsFolder>
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
        public TextVisualPresenter(TextControl view, SettingsFolder model) : base(view, model)
        {
            Model.User.PropertyChanged += Model_PropertyChanged;

            Sync(() =>
            {
                try
                {
                    Update();
                    View.ResetViewWidth();
                }
                catch (Exception err) { Logger.Error(err); }
            });
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// View_Resize
        ///
        /// <summary>
        /// View のリサイズ時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_Resize(object sender, EventArgs e)
        {
            View.ResetViewWidth();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Model_PropertyChanged
        ///
        /// <summary>
        /// Model の内容が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Sync(() =>
            {
                try
                {
                    Update(e.PropertyName);
                    View.ResetViewWidth();
                }
                catch (Exception err) { Logger.Error(err); }
            });
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
        private void Update()
        {
            View.Font                           = Model.User.Font;
            View.BackColor                      = Model.User.BackColor;
            View.ForeColor                      = Model.User.ForeColor;
            View.ColorScheme.SelectionBack      = Model.User.HighlightBackColor;
            View.ColorScheme.MatchedBracketBack = Model.User.HighlightBackColor;
            View.ColorScheme.DirtyLineBar       = Model.User.HighlightBackColor;
            View.ColorScheme.SelectionFore      = Model.User.HighlightForeColor;
            View.ColorScheme.MatchedBracketFore = Model.User.HighlightForeColor;
            View.ColorScheme.LineNumberBack     = Model.User.LineNumberBackColor;
            View.ColorScheme.CleanedLineBar     = Model.User.LineNumberBackColor;
            View.ColorScheme.LineNumberFore     = Model.User.LineNumberForeColor;
            View.ColorScheme.WhiteSpaceColor    = Model.User.SpecialCharsColor;
            View.ColorScheme.EolColor           = Model.User.SpecialCharsColor;
            View.ColorScheme.EofColor           = Model.User.SpecialCharsColor;
            View.ColorScheme.HighlightColor     = Model.User.CurrentLineColor;
            View.TabWidth                       = Model.User.TabWidth;
            View.ConvertsTabToSpaces            = Model.User.TabToSpace;
            View.ShowsLineNumber                = Model.User.LineNumberVisible;
            View.ShowsHRuler                    = Model.User.RulerVisible;
            View.HighlightsCurrentLine          = Model.User.CurrentLineVisible;
            View.ShowsDirtBar                   = Model.User.ModifiedLineVisible;
            View.HighlightsMatchedBracket       = Model.User.BracketVisible;

            UpdateSpecialCharsVisible();
            UpdateWordWrap();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Update
        ///
        /// <summary>
        /// 指定された名前の Model の内容を View に更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Update(string name)
        {
            switch (name)
            {
                case "Font":
                    View.Font = Model.User.Font;
                    break;
                case "BackColor":
                    View.BackColor = Model.User.BackColor;
                    View.ColorScheme.RightEdgeColor = Model.User.BackColor;
                    break;
                case "ForeColor":
                    View.ForeColor = Model.User.ForeColor;
                    break;
                case "HighlightBackColor":
                    View.ColorScheme.SelectionBack = Model.User.HighlightBackColor;
                    View.ColorScheme.MatchedBracketBack = Model.User.HighlightBackColor;
                    View.ColorScheme.DirtyLineBar = Model.User.HighlightBackColor;
                    break;
                case "HighlightForeColor":
                    View.ColorScheme.SelectionFore = Model.User.HighlightForeColor;
                    View.ColorScheme.MatchedBracketFore = Model.User.HighlightForeColor;
                    break;
                case "LineNumberBackColor":
                    View.ColorScheme.LineNumberBack = Model.User.LineNumberBackColor;
                    View.ColorScheme.CleanedLineBar = Model.User.LineNumberBackColor;
                    break;
                case "LineNumberForeColor":
                    View.ColorScheme.LineNumberFore = Model.User.LineNumberForeColor;
                    break;
                case "SpecialCharsColor":
                    View.ColorScheme.WhiteSpaceColor = Model.User.SpecialCharsColor;
                    View.ColorScheme.EofColor = Model.User.SpecialCharsColor;
                    View.ColorScheme.EolColor = Model.User.SpecialCharsColor;
                    break;
                case "CurrentLineColor":
                    View.ColorScheme.HighlightColor = Model.User.CurrentLineColor;
                    break;
                case "TabWidth":
                    View.TabWidth = Model.User.TabWidth;
                    break;
                case "TabToSpace":
                    View.ConvertsTabToSpaces = Model.User.TabToSpace;
                    break;
                case "WordWrap":
                case "WordWrapCount":
                case "WordWrapAsWindow":
                    UpdateWordWrap();
                    break;
                case "LineNumberVisible":
                    View.ShowsLineNumber = Model.User.LineNumberVisible;
                    break;
                case "RulerVisible":
                    View.ShowsHRuler = Model.User.RulerVisible;
                    break;
                case "EolVisible":
                    View.DrawsEolCode = Model.User.SpecialCharsVisible && Model.User.EolVisible;
                    break;
                case "TabVisible":
                    View.DrawsTab = Model.User.SpecialCharsVisible && Model.User.TabVisible;
                    break;
                case "SpaceVisible":
                    View.DrawsSpace = Model.User.SpecialCharsVisible && Model.User.SpaceVisible;
                    break;
                case "FullSpaceVisible":
                    View.DrawsFullWidthSpace = Model.User.SpecialCharsVisible && Model.User.FullSpaceVisible;
                    break;
                case "SpecialCharsVisible":
                    UpdateSpecialCharsVisible();
                    break;
                case "CurrentLineVisible":
                    View.HighlightsCurrentLine = Model.User.CurrentLineVisible;
                    break;
                case "ModifiedLineVisible":
                    View.ShowsDirtBar = Model.User.ModifiedLineVisible;
                    break;
                case "BracketVisible":
                    View.HighlightsMatchedBracket = Model.User.BracketVisible;
                    break;
                default:
                    break;
            }
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
            var enable = Model.User.SpecialCharsVisible;

            View.DrawsEolCode        = enable && Model.User.EolVisible;
            View.DrawsTab            = enable && Model.User.TabVisible;
            View.DrawsSpace          = enable && Model.User.SpaceVisible;
            View.DrawsFullWidthSpace = enable && Model.User.FullSpaceVisible;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateWordWrap
        ///
        /// <summary>
        /// 折り返し表示に関する設定を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateWordWrap()
        {
            View.Resize  -= View_Resize;

            if (Model.User.WordWrap)
            {
                View.ViewType      = Sgry.Azuki.ViewType.WrappedProportional;
                View.WordWrapCount = Model.User.WordWrapAsWindow ? -1 : Model.User.WordWrapCount;
                View.Resize       += View_Resize;
            }
            else
            {
                View.ViewType      = Sgry.Azuki.ViewType.Proportional;
                View.WordWrapCount = -1;
            }
        }

        #endregion
    }
}
