/* ------------------------------------------------------------------------- */
///
/// Program.cs
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
using System.Reflection;
using Cube.Note.Azuki;
using IoEx = System.IO;

namespace Cube.Note.App.Recovery
{
    /* --------------------------------------------------------------------- */
    ///
    /// Program
    /// 
    /// <summary>
    /// メインプログラムを表すクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    class Program
    {
        /* ----------------------------------------------------------------- */
        ///
        /// Main
        /// 
        /// <summary>
        /// プログラムのエントリーポイントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        static void Main(string[] args)
        {
            try
            {
                var settings = LoadSettings(Assembly.GetExecutingAssembly());
                var pages = LoadIndices(settings);
                ExecRecovery(pages, settings);
                Launch(settings);
            }
            catch (Exception err)
            {
                Puts(Properties.Resources.ErrorUnknown);
                Puts(err.ToString());
            }
        }

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// LoadSettings
        /// 
        /// <summary>
        /// 設定情報をロードします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        static SettingsFolder LoadSettings(Assembly assembly)
        {
            Puts(Properties.Resources.LoadSettings);
            var dest = new SettingsFolder(assembly);
            Puts($"Path ... {dest.Root}");
            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LoadIndices
        /// 
        /// <summary>
        /// インデックス情報をロードします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        static PageCollection LoadIndices(SettingsFolder settings)
        {
            Puts(Properties.Resources.LoadIndices);
            var dest = new PageCollection(settings.Root);
            try { dest.Load(); }
            catch (Exception err)
            {
                Puts(Properties.Resources.ErrorIndex);
                Puts(err.ToString());
            }
            Puts($"Count ... {dest.Count}");
            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ExecRecovery
        /// 
        /// <summary>
        /// 復旧処理を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        static void ExecRecovery(PageCollection pages, SettingsFolder settings)
        {
            Puts(Properties.Resources.ExecRecovery);
            pages.Recover(settings.MaxAbstractLength);
            pages.Save();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Launch
        /// 
        /// <summary>
        /// CubeNote を起動します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        static void Launch(SettingsFolder settings)
        {
            Puts(Properties.Resources.LaunchCubeNote);
            var dir = IoEx.Path.GetDirectoryName(settings.Assembly.Location);
            var exe = IoEx.Path.Combine(dir, "CubeNote.exe");
            System.Diagnostics.Process.Start(exe);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Puts
        /// 
        /// <summary>
        /// 情報を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        static void Puts(string message) => Console.WriteLine(message);

        #endregion
    }
}
