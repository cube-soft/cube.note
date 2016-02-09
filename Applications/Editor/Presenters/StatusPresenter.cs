/* ------------------------------------------------------------------------- */
///
/// StatusPresenter.cs
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
using Sgry.Azuki;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// StatusPresenter
    /// 
    /// <summary>
    /// StatusControl と TextControl を関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class StatusPresenter : Cube.Forms.PresenterBase<StatusControl, TextControl>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// StatusPresenter
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public StatusPresenter(StatusControl view, TextControl model) : base(view, model)
        {
            Model.CaretMoved += (s, e) => UpdateView(Model.Document);
            Model.GotFocus   += (s, e) => UpdateView(Model.Document);
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateView
        ///
        /// <summary>
        /// View の状態を更新します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void UpdateView(Document src)
        {
            var count      = (src != null) ? src.Length    : 0;
            var lineCount  = (src != null) ? src.LineCount : 0;
            var line       = 0;
            var column     = 0;
            if (src != null) src.GetCaretIndex(out line, out column);

            View.Count        = count - lineCount + 1;
            View.LineCount    = lineCount;
            View.LineNumber   = line + 1;
            View.ColumnNumber = column + 1;
        }

        #endregion
    }
}
