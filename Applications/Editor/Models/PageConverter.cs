/* ------------------------------------------------------------------------- */
///
/// PageConverter.cs
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
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// PageConverter
    /// 
    /// <summary>
    /// Page オブジェクトを ListViewItem オブジェクトに変換するための
    /// クラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class PageConverter : Cube.Forms.IListViewItemConverter
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// PageConverter
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageConverter() : this(-1, null, null) { }

        /* ----------------------------------------------------------------- */
        ///
        /// PageConverter
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageConverter(int upper, Graphics graphics, Font font)
        {
            UpperWidth = upper;
            Graphics   = graphics;
            Font       = font;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// UpperWidth
        ///
        /// <summary>
        /// 1 行の最大長をピクセル単位で取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int UpperWidth { get; set; } = -1;

        /* ----------------------------------------------------------------- */
        ///
        /// Graphics
        ///
        /// <summary>
        /// 描画用オブジェクトを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Graphics Graphics { get; set; }

        /* ----------------------------------------------------------------- */
        ///
        /// Font
        ///
        /// <summary>
        /// フォントを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Font Font { get; set; }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Convert
        ///
        /// <summary>
        /// ListViewItem オブジェクトに変換します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ListViewItem Convert<T>(T src)
        {
            var page = src as Page;
            if (page == null) return new ListViewItem(src.ToString());
            
            var items = new List<string>();
            items.Add(Trim(page.GetAbstract()));
            items.Add(page.LastUpdate.ToString(Properties.Resources.LastUpdateFormat));
            items.Add(string.Join(", ", page.Tags));

            var dest = new ListViewItem(items.ToArray());
            return dest;
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Trim
        ///
        /// <summary>
        /// 1 行 (UpperWidth) に収まるように、末尾の文字列を除去します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private string Trim(string src)
        {
            if (Graphics == null || Font == null || UpperWidth <= 0 ||
                Measure(src) <= UpperWidth) return src;

            var unit     = Font.Size; // average font width
            var capacity = (int)Math.Round(UpperWidth / unit);
            var dest     = new StringBuilder(src.Substring(0, capacity));
            var result   = Measure(dest.ToString());

            while (src.Length > dest.Length && result < UpperWidth)
            {
                unit = result / dest.Length;
                capacity = (int)Math.Round(UpperWidth / unit);

                var add = Math.Min(Math.Max(capacity - dest.Length, 1), src.Length - dest.Length);
                if (add <= 0) break;
                dest.Append(src.Substring(dest.Length, add));

                result = Measure(dest.ToString());
            }

            while (dest.Length > 0 && result > UpperWidth)
            {
                dest.Remove(dest.Length - 1, 1);
                result = Measure(dest.ToString());
            }

            return dest.ToString();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Measure
        ///
        /// <summary>
        /// テキストの幅を計測します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private float Measure(string src)
            => Graphics?.MeasureString(src, Font).Width ?? 0;

        #endregion
    }
}
