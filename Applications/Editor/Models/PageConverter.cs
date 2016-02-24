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
        public int UpperWidth { get; set; }

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
            
            var text = page.GetAbstract();
            // 1 行に収まらない場合は 1 行に収まるように削る
            if (Graphics.MeasureString(text, Font).Width >= UpperWidth)
            {
                var fontWidth = Font.Size;
                var textLength = (int)(UpperWidth / fontWidth);
                var builder = new System.Text.StringBuilder(text.Substring(0, textLength));
                var measuredWidth = 0.0F;
                do
                {
                    measuredWidth = Graphics.MeasureString(builder.ToString(), Font).Width;
                    fontWidth = measuredWidth / builder.Length;
                    textLength = (int)(UpperWidth / fontWidth);
                    builder.Append(text.Substring(builder.Length, System.Math.Max(textLength - builder.Length, 1)));
                } while (fontWidth < UpperWidth - measuredWidth);

                while (Graphics.MeasureString(builder.ToString(), Font).Width >= UpperWidth)
                {
                    builder.Remove(builder.Length - 1, 1);
                }

                text = builder.ToString();
            }

            var items = new List<string>();
            items.Add(text);
            items.Add(page.LastUpdate.ToString(Properties.Resources.LastUpdateFormat));
            items.Add(string.Join(", ", page.Tags));

            var dest = new ListViewItem(items.ToArray());
            return dest;
        }

        #endregion
    }
}
