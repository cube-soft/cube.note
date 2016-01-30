/* ------------------------------------------------------------------------- */
///
/// PageCollectionResource.cs
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
using IoEx = System.IO;

namespace Cube.Note.Tests
{
    class PageCollectionResource : FileResource
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// PageCollectionResource
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected PageCollectionResource() : base()
        {
            Copy("Order.json");
            Copy("05859d5f90094ab0b8ec739b6150f455");
            Copy("a65006b41d3c47a8981a8feaec7523bc");

            Pages = new PageCollection(Results);
            Pages.Load("Order.json");
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Pages
        ///
        /// <summary>
        /// PageCollection オブジェクトを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected PageCollection Pages { get; set; }

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// Copy
        ///
        /// <summary>
        /// Examples フォルダから Results フォルダへファイルをコピーします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Copy(string filename)
        {
            IoEx.File.Copy(
                IoEx.Path.Combine(Examples, filename),
                IoEx.Path.Combine(Results, filename),
                true
            );
        }

        #endregion
    }
}
