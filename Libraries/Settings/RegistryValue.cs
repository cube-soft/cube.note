/* ------------------------------------------------------------------------- */
///
/// RegistryValue.cs
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
using System.Runtime.Serialization;

namespace Cube.Note
{
    /* --------------------------------------------------------------------- */
    ///
    /// RegistryValue
    /// 
    /// <summary>
    /// レジストリに保存されている値を表すクラスです。
    /// </summary>
    /// 
    /// <remarks>
    /// CubeNote では、一部の値以外は JSON ファイルで管理しています。
    /// 新しくユーザ設定を追加したい場合は、SettingsValue にプロパティを追加して
    /// 下さい。
    /// </remarks>
    /// 
    /* --------------------------------------------------------------------- */
    [DataContract]
    internal class RegistryValue
    {
        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Data
        ///
        /// <summary>
        /// データフォルダのパスを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public string Data { get; set; }

        #endregion
    }
}
