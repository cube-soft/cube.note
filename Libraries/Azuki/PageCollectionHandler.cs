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
using System.Text.RegularExpressions;
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
        {
            if (IoEx.Directory.Exists(path))
            {
                foreach (var file in IoEx.Directory.GetFiles(path))
                {
                    Import(pages, tag, index, file, maxLength);
                }
                return;
            }

            pages.NewPage(tag, index, (page) =>
            {
                var document = DocumentHandler.Create(path);
                document.Save(IoEx.Path.Combine(pages.Directory, page.FileName));
                page.Document = document;
                page.UpdateAbstract(maxLength);
            });
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Recover
        ///
        /// <summary>
        /// データが格納されているフォルダから PageCollection オブジェクトを
        /// 再構築します。
        /// </summary>
        /// 
        /// <remarks>
        /// NOTE: 現在の方法ではタグ情報を復旧することはできない。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        public static void Recover(this PageCollection pages,
            string direcotry, int maxLength)
        {
            if (!IoEx.Directory.Exists(direcotry)) return;
            foreach (var path in IoEx.Directory.GetFiles(direcotry))
            {
                var filename = IoEx.Path.GetFileName(path).ToLower();
                var exp = new Regex("^[0-9a-z]{32}$");
                if (!exp.IsMatch(filename) || pages.Contains(filename)) continue;

                pages.NewPage(pages.Tags.Everyone, 0, (page) =>
                {
                    var document = DocumentHandler.Create(path);
                    page.FileName = filename;
                    page.Document = document;
                    page.UpdateAbstract(maxLength);
                });
            }
        }
    }
}
