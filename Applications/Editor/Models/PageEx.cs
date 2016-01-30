/* ------------------------------------------------------------------------- */
///
/// PageEx.cs
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
using IoEx = System.IO;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// PageEx
    /// 
    /// <summary>
    /// Page の拡張用クラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public static class PageEx
    {
        #region Methods

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
            var dest = CreateDocument(path);
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
            if (doc == null || doc.IsReadOnly) return;

            var path = IoEx.Path.Combine(directory, page.FileName);
            SaveDocument(doc, path);
        }

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// CreateDocument
        /// 
        /// <summary>
        /// ファイルから内容を読み込だ Document オブジェクトを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private static Document CreateDocument(string path)
        {
            var dest = new Document();
            if (!IoEx.File.Exists(path)) return dest;

            using (var stream = IoEx.File.Open(path,
                IoEx.FileMode.Open, IoEx.FileAccess.Read, IoEx.FileShare.ReadWrite))
            using (var reader = new IoEx.StreamReader(stream, _Encoding, true))
            {
                dest.Capacity = (int)(reader.BaseStream.Length / 2);

                var buffer = reader.BaseStream.Length < 1024 * 1024 ?
                             new char[reader.BaseStream.Length] :
                             new char[(reader.BaseStream.Length + 10) / 10];

                while (!reader.EndOfStream)
                {
                    var count = reader.Read(buffer, 0, buffer.Length);
                    dest.Replace(new string(buffer, 0, count), dest.Length, dest.Length);
                }

                dest.ClearHistory();
                dest.IsDirty = false;
            }

            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SaveDocument
        /// 
        /// <summary>
        /// Document の内容をファイルに保存します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private static void SaveDocument(Document src, string path)
        {
            var bytes = _Encoding.GetBytes(src.Text);
            var bom   = _Encoding.GetBytes("\xFEFF");

            using (var stream = IoEx.File.Open(path,
                IoEx.FileMode.OpenOrCreate, IoEx.FileAccess.ReadWrite, IoEx.FileShare.ReadWrite))
            {
                stream.SetLength(0);
                stream.Write(bom, 0, bom.Length);
                stream.Write(bytes, 0, bytes.Length);
            }

            src.IsDirty = false;
        }

        #endregion

        #region Fields
        private static System.Text.Encoding _Encoding = System.Text.Encoding.UTF8;
        #endregion
    }
}
