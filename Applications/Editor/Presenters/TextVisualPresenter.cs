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
                case nameof(Model.User.Font):
                    View.Font = Model.User.Font;
                    break;
                case nameof(Model.User.BackColor):
                    View.BackColor = Model.User.BackColor;
                    View.ColorScheme.RightEdgeColor = Model.User.BackColor;
                    break;
                case nameof(Model.User.ForeColor):
                    View.ForeColor = Model.User.ForeColor;
                    break;
                case nameof(Model.User.HighlightBackColor):
                    View.ColorScheme.SelectionBack = Model.User.HighlightBackColor;
                    View.ColorScheme.MatchedBracketBack = Model.User.HighlightBackColor;
                    View.ColorScheme.DirtyLineBar = Model.User.HighlightBackColor;
                    break;
                case nameof(Model.User.HighlightForeColor):
                    View.ColorScheme.SelectionFore = Model.User.HighlightForeColor;
                    View.ColorScheme.MatchedBracketFore = Model.User.HighlightForeColor;
                    break;
                case nameof(Model.User.LineNumberBackColor):
                    View.ColorScheme.LineNumberBack = Model.User.LineNumberBackColor;
                    View.ColorScheme.CleanedLineBar = Model.User.LineNumberBackColor;
                    break;
                case nameof(Model.User.LineNumberForeColor):
                    View.ColorScheme.LineNumberFore = Model.User.LineNumberForeColor;
                    break;
                case nameof(Model.User.SpecialCharsColor):
                    View.ColorScheme.WhiteSpaceColor = Model.User.SpecialCharsColor;
                    View.ColorScheme.EofColor = Model.User.SpecialCharsColor;
                    View.ColorScheme.EolColor = Model.User.SpecialCharsColor;
                    break;
                case nameof(Model.User.CurrentLineColor):
                    View.ColorScheme.HighlightColor = Model.User.CurrentLineColor;
                    break;
                case nameof(Model.User.TabWidth):
                    View.TabWidth = Model.User.TabWidth;
                    break;
                case nameof(Model.User.TabToSpace):
                    View.ConvertsTabToSpaces = Model.User.TabToSpace;
                    break;
                case nameof(Model.User.WordWrap):
                case nameof(Model.User.WordWrapCount):
                case nameof(Model.User.WordWrapAsWindow):
                    UpdateWordWrap();
                    break;
                case nameof(Model.User.LineNumberVisible):
                    View.ShowsLineNumber = Model.User.LineNumberVisible;
                    break;
                case nameof(Model.User.RulerVisible):
                    View.ShowsHRuler = Model.User.RulerVisible;
                    break;
                case nameof(Model.User.SpecialCharsVisible):
                case nameof(Model.User.EolVisible):
                case nameof(Model.User.TabVisible):
                case nameof(Model.User.SpaceVisible):
                case nameof(Model.User.FullSpaceVisible):
                    UpdateSpecialCharsVisible();
                    break;
                case nameof(Model.User.CurrentLineVisible):
                    View.HighlightsCurrentLine = Model.User.CurrentLineVisible;
                    break;
                case nameof(Model.User.ModifiedLineVisible):
                    View.ShowsDirtBar = Model.User.ModifiedLineVisible;
                    break;
                case nameof(Model.User.BracketVisible):
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
