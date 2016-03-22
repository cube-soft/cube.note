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
using Sgry.Azuki;
using Cube.Log;

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
    public class TextVisualPresenter
        : PresenterBase<TextControl, SettingsValue>
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
        public TextVisualPresenter(TextControl view, SettingsFolder model,
            EventAggregator events)
            : base(view, model.User, model, events)
        {
            Model.PropertyChanged += Model_PropertyChanged;

            Sync(() => this.LogException(() =>
            {
                Update();
                View.ResetViewWidth();
            }));
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
            => Sync(()
            => this.LogException(() =>
        {
            Update(e.PropertyName);
            View.ResetViewWidth();
        }));

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Update
        ///
        /// <summary>
        /// Model の内容を View に反映させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Update()
        {
            foreach (var info in Model.GetType().GetProperties()) Update(info.Name);
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
                case nameof(Model.Font):
                    View.Font = Model.Font;
                    break;
                case nameof(Model.BackColor):
                    View.BackColor = Model.BackColor;
                    View.ColorScheme.RightEdgeColor = Model.BackColor;
                    View.ColorScheme.SetMarkingDecoration(Marking.Uri,
                        new BgColorTextDecoration(Model.UriColor, Model.BackColor));
                    break;
                case nameof(Model.ForeColor):
                    View.ForeColor = Model.ForeColor;
                    break;
                case nameof(Model.UriColor):
                    View.ColorScheme.SetMarkingDecoration(Marking.Uri,
                        new BgColorTextDecoration(Model.UriColor, Model.BackColor));
                    break;
                case nameof(Model.HighlightBackColor):
                    View.ColorScheme.SelectionBack = Model.HighlightBackColor;
                    View.ColorScheme.MatchedBracketBack = Model.HighlightBackColor;
                    View.ColorScheme.DirtyLineBar = Model.HighlightBackColor;
                    break;
                case nameof(Model.HighlightForeColor):
                    View.ColorScheme.SelectionFore = Model.HighlightForeColor;
                    View.ColorScheme.MatchedBracketFore = Model.HighlightForeColor;
                    break;
                case nameof(Model.SearchBackColor):
                case nameof(Model.SearchForeColor):
                    View.ColorScheme.SetColor(CharClass.Keyword,
                        Model.SearchForeColor,
                        Model.SearchBackColor
                    );
                    break;
                case nameof(Model.LineNumberBackColor):
                    View.ColorScheme.LineNumberBack = Model.LineNumberBackColor;
                    View.ColorScheme.CleanedLineBar = Model.LineNumberBackColor;
                    break;
                case nameof(Model.LineNumberForeColor):
                    View.ColorScheme.LineNumberFore = Model.LineNumberForeColor;
                    break;
                case nameof(Model.SpecialCharsColor):
                    View.ColorScheme.WhiteSpaceColor = Model.SpecialCharsColor;
                    View.ColorScheme.EofColor = Model.SpecialCharsColor;
                    View.ColorScheme.EolColor = Model.SpecialCharsColor;
                    break;
                case nameof(Model.CurrentLineColor):
                    View.ColorScheme.HighlightColor = Model.CurrentLineColor;
                    break;
                case nameof(Model.TabWidth):
                    View.TabWidth = Model.TabWidth;
                    break;
                case nameof(Model.TabToSpace):
                    View.ConvertsTabToSpaces = Model.TabToSpace;
                    break;
                case nameof(Model.WordWrap):
                case nameof(Model.WordWrapCount):
                case nameof(Model.WordWrapAsWindow):
                    UpdateWordWrap();
                    break;
                case nameof(Model.LineNumberVisible):
                    View.ShowsLineNumber = Model.LineNumberVisible;
                    break;
                case nameof(Model.RulerVisible):
                    View.ShowsHRuler = Model.RulerVisible;
                    break;
                case nameof(Model.SpecialCharsVisible):
                case nameof(Model.EolVisible):
                case nameof(Model.TabVisible):
                case nameof(Model.SpaceVisible):
                case nameof(Model.FullSpaceVisible):
                    UpdateSpecialCharsVisible();
                    break;
                case nameof(Model.CurrentLineVisible):
                    View.HighlightsCurrentLine = Model.CurrentLineVisible;
                    break;
                case nameof(Model.ModifiedLineVisible):
                    View.ShowsDirtBar = Model.ModifiedLineVisible;
                    break;
                case nameof(Model.BracketVisible):
                    View.HighlightsMatchedBracket = Model.BracketVisible;
                    break;
                case nameof(Model.IncludeLineCode):
                    View.IncludeLineCount = Model.IncludeLineCode;
                    break;
                case nameof(Model.OpenUri):
                    UpdateLinkCursor();
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
            var enable = Model.SpecialCharsVisible;

            View.DrawsEolCode        = enable && Model.EolVisible;
            View.DrawsTab            = enable && Model.TabVisible;
            View.DrawsSpace          = enable && Model.SpaceVisible;
            View.DrawsFullWidthSpace = enable && Model.FullSpaceVisible;
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

            if (Model.WordWrap)
            {
                View.ViewType      = ViewType.WrappedProportional;
                View.WordWrapCount = Model.WordWrapAsWindow ? -1 : Model.WordWrapCount;
                View.Resize       += View_Resize;
            }
            else
            {
                View.ViewType      = ViewType.Proportional;
                View.WordWrapCount = -1;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateLinkCursor
        ///
        /// <summary>
        /// リンク部分のマウスカーソルを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateLinkCursor()
        {
            var info = Marking.GetMarkingInfo(Marking.Uri);
            info.MouseCursor = Model.OpenUri ? MouseCursor.Hand : MouseCursor.IBeam;
        }

        #endregion
    }
}
