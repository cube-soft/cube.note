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
using System.Windows.Forms;

namespace Cube.Note.App.Editor
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
    static class Program
    {
        /* ----------------------------------------------------------------- */
        ///
        /// Main
        /// 
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [STAThread]
        static void Main(string[] args)
        {
            var name = Application.ProductName.ToLower();
            using (var bootstrap = new Bootstrap(name))
            {
                if (bootstrap.Exists())
                {
                    bootstrap.Activate(args);
                    return;
                }

                InitLog();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var form = new MainForm();
                form.Bootstrap = bootstrap;
                Application.Run(form);
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InitLog
        /// 
        /// <summary>
        /// ログを出力します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        static void InitLog()
        {
            log4net.Config.XmlConfigurator.Configure();

            var logger = log4net.LogManager.GetLogger(typeof(Program));
            var reader = new AssemblyReader(Assembly.GetExecutingAssembly());
            logger.Info($"{reader.Product} {reader.Version}");
            logger.Info($"{Environment.OSVersion}");
            logger.Info($"{Environment.Version}");
        }
    }
}
