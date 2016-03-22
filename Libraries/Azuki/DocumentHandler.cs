/* ------------------------------------------------------------------------- */
///
/// DocumentHandler.cs
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
using System.Text.RegularExpressions;
using System.Text;
using Sgry.Azuki;
using IoEx = System.IO;

namespace Cube.Note.Azuki
{
    /* --------------------------------------------------------------------- */
    ///
    /// DocumentHandler
    /// 
    /// <summary>
    /// Azuki.Document オブジェクトを扱うためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public static class DocumentHandler
    {
        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        /// 
        /// <summary>
        /// ファイルから内容を読み込だ Document オブジェクトを生成します。
        /// </summary>
        /// 
        /// <remarks>
        /// ファイルの文字コードは Sgry.EncodingAnalyzer を用いて判別します。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        public static Document Create(string path)
            => Create(path, Sgry.EncodingAnalyzer.Analyze(path), true);

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        /// 
        /// <summary>
        /// ファイルから内容を読み込だ Document オブジェクトを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static Document Create(string path, Encoding encoding, bool careLine)
        {
            var dest = new Document { MarksUri = true };
            if (!IoEx.File.Exists(path)) return dest;

            using (var stream = IoEx.File.Open(path,
                IoEx.FileMode.Open, IoEx.FileAccess.Read, IoEx.FileShare.ReadWrite))
            using (var reader = new IoEx.StreamReader(stream, encoding, true))
            {
                dest.Capacity = (int)(reader.BaseStream.Length / 2);

                var buffer = reader.BaseStream.Length < 1024 * 1024 ?
                             new char[reader.BaseStream.Length] :
                             new char[(reader.BaseStream.Length + 10) / 10];

                while (!reader.EndOfStream)
                {
                    var count = reader.Read(buffer, 0, buffer.Length);
                    var text  = CreateText(buffer, count, careLine);
                    dest.Replace(text, dest.Length, dest.Length);
                }

                dest.SetCaretIndex(0, 0);
                dest.ClearHistory();
                dest.IsDirty = false;
            }

            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Save
        /// 
        /// <summary>
        /// Document の内容をファイルに保存します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static void Save(this Document src, string path)
        {
            var encoding = Encoding.UTF8;
            var bytes    = encoding.GetBytes(src.Text);
            var bom      = encoding.GetBytes("\xFEFF");

            using (var stream = IoEx.File.Open(path,
                IoEx.FileMode.OpenOrCreate, IoEx.FileAccess.ReadWrite, IoEx.FileShare.ReadWrite))
            {
                stream.SetLength(0);
                stream.Write(bom, 0, bom.Length);
                stream.Write(bytes, 0, bytes.Length);
            }

            src.IsDirty = false;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetAbstract
        ///
        /// <summary>
        /// 概要を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static string GetAbstract(this Document document, int maxLength)
        {
            for (var i = 0; i < document.LineCount; ++i)
            {
                var content = document.GetLineContent(i).Trim();
                if (content.Length <= 0) continue;

                return content.Length > maxLength ?
                       content.Substring(0, maxLength) :
                       content;
            }
            return string.Empty;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetSelectedText
        ///
        /// <summary>
        /// 選択中のテキストを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static string GetSelectedText(this Document src)
        {
            var begin = 0;
            var end   = 0;
            src.GetSelection(out begin, out end);
            return (begin != end) ? src.GetTextInRange(begin, end) : string.Empty;
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// CreateText
        ///
        /// <summary>
        /// string オブジェクトを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private static string CreateText(char[] src, int length, bool careLine)
        {
            var dest = new string(src, 0, length);
            return careLine ?
                   new Regex("\r\n|\r|\n").Replace(dest, Environment.NewLine) :
                   dest;
        }

        #endregion
    }
}
