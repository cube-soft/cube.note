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
                    if (e.PropertyName == "Font") View.Font = Model.Font;
                    else if (e.PropertyName == "BackColor") View.BackColor = Model.BackColor;
                    else if (e.PropertyName == "ForeColor") View.ForeColor = Model.ForeColor;
                    else if (e.PropertyName == "LineNumberBackColor") View.ColorScheme.LineNumberBack = Model.LineNumberBackColor;
                    else if (e.PropertyName == "LineNumberForeColor") View.ColorScheme.LineNumberFore = Model.LineNumberForeColor;
                    else if (e.PropertyName == "TabWidth") View.TabWidth = Model.TabWidth;
                    else if (e.PropertyName == "TabToSpace") View.ConvertsTabToSpaces = Model.TabToSpace;
                    else if (e.PropertyName == "LineNumberVisible") View.ShowsLineNumber = Model.LineNumberVisible;
                    else if (e.PropertyName == "RulerVisible") View.ShowsHRuler = Model.RulerVisible;
                    else if (e.PropertyName == "CurrentLineVisible") View.HighlightsCurrentLine = Model.CurrentLineVisible;
                    else if (e.PropertyName == "ModifiedLineVisible") View.ShowsDirtBar = Model.ModifiedLineVisible;
                    else if (e.PropertyName == "SpecialCharsVisible") UpdateSpecialCharsVisible();
                    else if (e.PropertyName == "EolVisible") UpdateSpecialCharsVisible();
                    else if (e.PropertyName == "SpaceVisible") UpdateSpecialCharsVisible();
                    else if (e.PropertyName == "FullSpaceVisible") UpdateSpecialCharsVisible();

                    View.ViewWidth = 0; // refresh
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
                View.Font = Model.Font;
                View.BackColor = Model.BackColor;
                View.ForeColor = Model.ForeColor;
                View.ColorScheme.LineNumberBack = Model.LineNumberBackColor;
                View.ColorScheme.LineNumberFore = Model.LineNumberForeColor;
                View.TabWidth = Model.TabWidth;
                View.ConvertsTabToSpaces = Model.TabToSpace;
                View.ShowsLineNumber = Model.LineNumberVisible;
                View.ShowsHRuler = Model.RulerVisible;
                View.HighlightsCurrentLine = Model.CurrentLineVisible;
                View.ShowsDirtBar = Model.ModifiedLineVisible;

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
