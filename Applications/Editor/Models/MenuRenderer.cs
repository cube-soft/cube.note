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
using System.Drawing;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// FlatColorTable
    /// 
    /// <summary>
    /// グラデーション描画を無効にするためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class FlatColorTable : ProfessionalColorTable
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// FlatColorTable
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public FlatColorTable(Color color) : base()
        {
            Color = color;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Color
        /// 
        /// <summary>
        /// メイン色を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Color Color { get; }

        #endregion

        #region Override properties

        /* ----------------------------------------------------------------- */
        ///
        /// ToolStripGradientBegin
        /// 
        /// <summary>
        /// グラデーションの開始色を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public override Color ToolStripGradientBegin => Color;

        /* ----------------------------------------------------------------- */
        ///
        /// ToolStripGradientMiddle
        /// 
        /// <summary>
        /// グラデーションの中間色を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public override Color ToolStripGradientMiddle => Color;

        /* ----------------------------------------------------------------- */
        ///
        /// ToolStripGradientEnd
        /// 
        /// <summary>
        /// グラデーションの終了色を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public override Color ToolStripGradientEnd => Color;

        #endregion
    }

    /* --------------------------------------------------------------------- */
    ///
    /// MenuRenderer
    /// 
    /// <summary>
    /// ToolStripMenu を描画するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        /* ----------------------------------------------------------------- */
        ///
        /// MenuRenderer
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public MenuRenderer(Color color)
            : base(new FlatColorTable(color))
        {
            RoundedEdges = false;
        }
    }
}
