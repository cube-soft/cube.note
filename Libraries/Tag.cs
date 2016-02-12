/* ------------------------------------------------------------------------- */
///
/// Tag.cs
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

namespace Cube.Note
{
    /* --------------------------------------------------------------------- */
    ///
    /// Tag
    /// 
    /// <summary>
    /// タグ情報を保持するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class Tag
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// Tag
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Tag(string name)
        {
            Name = name;
            Count = 0;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Name
        ///
        /// <summary>
        /// タグ名を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string Name { get; set; }

        /* ----------------------------------------------------------------- */
        ///
        /// Count
        ///
        /// <summary>
        /// このタグに関連付けられている Page オブジェクトの個数を取得
        /// または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int Count { get; set; }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// ToString
        ///
        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public override string ToString() => Name;

        #endregion
    }
}
