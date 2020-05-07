/* ------------------------------------------------------------------------- */
// 
// Copyright (c) 2010 CubeSoft, Inc.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
/* ------------------------------------------------------------------------- */
using System;
using System.Text;
using Sgry.Azuki;
using IoEx = System.IO;

namespace Cube.Note.Azuki
{
    /* --------------------------------------------------------------------- */
    ///
    /// PageHandler
    /// 
    /// <summary>
    /// Azuki.Document オブジェクトを扱うためのクラスです。
    /// Page クラスに対する拡張メソッドとして実装されます。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public static class PageHandler
    {
        /* ----------------------------------------------------------------- */
        ///
        /// CreateDocument
        /// 
        /// <summary>
        /// 新しい Document オブジェクトを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static Document CreateDocument(this Page page, string directory)
        {
            var done = page.Document as Document;
            if (done != null) return done;

            var path = IoEx.Path.Combine(directory, page.FileName);
            var dest = DocumentHandler.Create(path, Encoding.UTF8, false);
            page.Document = dest;
            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SaveDocument
        /// 
        /// <summary>
        /// 内容を保存します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static void SaveDocument(this Page page, string directory)
        {
            var doc = page.Document as Document;
            if (doc == null || doc.IsReadOnly || !doc.IsDirty) return;

            var path = IoEx.Path.Combine(directory, page.FileName);
            doc.Save(path);
            page.LastUpdate = DateTime.Now;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateAbstract
        /// 
        /// <summary>
        /// Abstract プロパティの内容を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static void UpdateAbstract(this Page page, int maxLength)
        {
            var document = page.Document as Document;
            if (document == null) return;
            page.Abstract = document.GetAbstract(maxLength);
        }
    }
}
