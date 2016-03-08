/* ------------------------------------------------------------------------- */
///
/// PageCollectionHandler.cs
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

namespace Cube.Note.Azuki
{
    /* --------------------------------------------------------------------- */
    ///
    /// PageCollectionHandler
    /// 
    /// <summary>
    /// Azuki.Document オブジェクトを扱うためのクラスです。
    /// PageCollection クラスに対する拡張メソッドとして実装されます。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public static class PageCollectionHandler
    {
        /* ----------------------------------------------------------------- */
        ///
        /// Import
        /// 
        /// <summary>
        /// ファイルをインポートします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static void Import(this PageCollection pages,
            Tag tag, int index, string path, int maxLength)
            => pages.NewPage(tag, index, (page) =>
        {
            var document = DocumentHandler.Create(path);
            document.Save(IoEx.Path.Combine(pages.Directory, page.FileName));
            page.Document = document;
            page.UpdateAbstract(maxLength);
        });
    }
}
