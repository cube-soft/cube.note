/* ------------------------------------------------------------------------- */
///
/// Images.cs
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
using System.Collections.Generic;
using System.Drawing;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// Images
    /// 
    /// <summary>
    /// アプリケーションで使用する画像リソースを管理するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class Images
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// Images
        /// 
        /// <summary>
        /// 静的な要素を初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        static Images()
        {
            _resources.Add("add", new List<Image>
            {
                Properties.Resources.Add,
                Properties.Resources.Add120,
                Properties.Resources.Add144,
                Properties.Resources.Add192,
                Properties.Resources.Add240
            });

            _resources.Add("close", new List<Image>
            {
                Properties.Resources.Close,
                Properties.Resources.Close120,
                Properties.Resources.Close144,
                Properties.Resources.Close192,
                Properties.Resources.Close240
            });

            _resources.Add("export", new List<Image>
            {
                Properties.Resources.Export,
                Properties.Resources.Export120,
                Properties.Resources.Export144,
                Properties.Resources.Export192,
                Properties.Resources.Export240
            });

            _resources.Add("font", new List<Image>
            {
                Properties.Resources.Font,
                Properties.Resources.Font120,
                Properties.Resources.Font144,
                Properties.Resources.Font192,
                Properties.Resources.Font240
            });

            _resources.Add("left", new List<Image>
            {
                Properties.Resources.Left,
                Properties.Resources.Left120,
                Properties.Resources.Left144,
                Properties.Resources.Left192,
                Properties.Resources.Left240
            });

            _resources.Add("logo", new List<Image>
            {
                Properties.Resources.Logo,
                Properties.Resources.Logo120,
                Properties.Resources.Logo144,
                Properties.Resources.Logo192,
                Properties.Resources.Logo240
            });

            _resources.Add("maximize", new List<Image>
            {
                Properties.Resources.Maximize,
                Properties.Resources.Maximize120,
                Properties.Resources.Maximize144,
                Properties.Resources.Maximize192,
                Properties.Resources.Maximize240
            });

            _resources.Add("minimize", new List<Image>
            {
                Properties.Resources.Minimize,
                Properties.Resources.Minimize120,
                Properties.Resources.Minimize144,
                Properties.Resources.Minimize192,
                Properties.Resources.Minimize240
            });

            _resources.Add("normalize", new List<Image>
            {
                Properties.Resources.Normalize,
                Properties.Resources.Normalize120,
                Properties.Resources.Normalize144,
                Properties.Resources.Normalize192,
                Properties.Resources.Normalize240
            });

            _resources.Add("print", new List<Image>
            {
                Properties.Resources.Print,
                Properties.Resources.Print120,
                Properties.Resources.Print144,
                Properties.Resources.Print192,
                Properties.Resources.Print240
            });

            _resources.Add("property", new List<Image>
            {
                Properties.Resources.Property,
                Properties.Resources.Property120,
                Properties.Resources.Property144,
                Properties.Resources.Property192,
                Properties.Resources.Property240
            });

            _resources.Add("redo", new List<Image>
            {
                Properties.Resources.Redo,
                Properties.Resources.Redo120,
                Properties.Resources.Redo144,
                Properties.Resources.Redo192,
                Properties.Resources.Redo240
            });

            _resources.Add("remove", new List<Image>
            {
                Properties.Resources.Remove,
                Properties.Resources.Remove120,
                Properties.Resources.Remove144,
                Properties.Resources.Remove192,
                Properties.Resources.Remove240
            });

            _resources.Add("search", new List<Image>
            {
                Properties.Resources.Search,
                Properties.Resources.Search120,
                Properties.Resources.Search144,
                Properties.Resources.Search192,
                Properties.Resources.Search240
            });

            _resources.Add("settings", new List<Image>
            {
                Properties.Resources.Settings,
                Properties.Resources.Settings120,
                Properties.Resources.Settings144,
                Properties.Resources.Settings192,
                Properties.Resources.Settings240
            });

            _resources.Add("title", new List<Image>
            {
                Properties.Resources.Title,
                Properties.Resources.Title120,
                Properties.Resources.Title144,
                Properties.Resources.Title192,
                Properties.Resources.Title240
            });

            _resources.Add("undo", new List<Image>
            {
                Properties.Resources.Undo,
                Properties.Resources.Undo120,
                Properties.Resources.Undo144,
                Properties.Resources.Undo192,
                Properties.Resources.Undo240
            });
        }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Get
        /// 
        /// <summary>
        /// 対応する Image オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static Image Get(string name, double ratio)
        {
            List<Image> dest = null;
            if (!_resources.TryGetValue(name.ToLower(), out dest)) return null;

            var index = ratio < 1.25 ? 0 :
                        ratio < 1.50 ? 1 :
                        ratio < 2.00 ? 2 :
                        ratio < 2.50 ? 3 :
                                       4 ;
            return dest[Math.Min(index, dest.Count)];
        }

        #endregion

        #region Fields
        private static Dictionary<string, List<Image>> _resources = new Dictionary<string, List<Image>>();
        #endregion
    }
}
