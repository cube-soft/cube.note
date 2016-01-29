/* ------------------------------------------------------------------------- */
///
/// TextEditPresenter.cs
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
    /// TextEditPresenter
    /// 
    /// <summary>
    /// TextEditControl とモデルを関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class TextEditPresenter : Cube.Forms.PresenterBase<TextEditControl, PageCollection>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TextEditPresenter
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TextEditPresenter(TextEditControl view, PageCollection model)
            : base(view, model)
        {
            Model.TargetChanged += Model_TargetChanged;
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// Model_TargetChanged
        ///
        /// <summary>
        /// 編集対象となる Page オブジェクトが変更された時に実行される
        /// ハンドラです。
        /// </summary>
        /// 
        /// <remarks>
        /// TODO: ここで View.Focus() を実行しても ListView の MouseUp
        /// 発生時にフォーカスを奪われてしまう模様。対応方法を検討する。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_TargetChanged(object sender, PageChangedEventArgs e)
        {
            if (e.NewPage == null) return;

            View.Document = e.NewPage.CreateDocument();
            View.Focus();
        }

        #endregion
    }
}
