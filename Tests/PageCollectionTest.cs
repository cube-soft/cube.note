﻿/* ------------------------------------------------------------------------- */
///
/// PageCollectionTest.cs
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
using NUnit.Framework;
using IoEx = System.IO;

namespace Cube.Note.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// PageCollectionTest
    /// 
    /// <summary>
    /// PageCollection のテスト用クラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class PageCollectionTest : FileResource
    {
        #region SetUp and TearDown

        /* ----------------------------------------------------------------- */
        ///
        /// OneTimeSetUp
        ///
        /// <summary>
        /// 初期化処理を一度だけ行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Copy("Order.json");
            Copy("05859d5f90094ab0b8ec739b6150f455");
            Copy("a65006b41d3c47a8981a8feaec7523bc");

            Pages = new PageCollection(Results);
            Pages.Load("Order.json");
        }

        #endregion

        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// Properties
        ///
        /// <summary>
        /// 各種プロパティのテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        #region Properties

        [Test]
        public void Directory_IsResults()
        {
            Assert.That(
                Pages.Directory,
                Is.EqualTo(Results)
            );
        }

        [Test]
        public void FileType_IsJson()
        {
            Assert.That(
                Pages.FileType,
                Is.EqualTo(Cube.Settings.FileType.Json)
            );
        }

        [TestCase("05859d5f90094ab0b8ec739b6150f455")]
        public void FileName_Last(string expected)
        {
            Assert.That(
                Pages[Pages.Count - 1].FileName,
                Is.EqualTo(expected)
            );
        }

        [TestCase("LastPage")]
        public void Abstract_Last(string expected)
        {
            Assert.That(
                Pages[Pages.Count - 1].Abstract,
                Is.EqualTo(expected)
            );
        }

        [TestCase(2016, 1, 29, 13, 15, 30, 706)]
        public void Creation_Last(int y, int m, int d, int hh, int mm, int ss, int ms)
        {
            Assert.That(
                Pages[Pages.Count - 1].Creation,
                Is.EqualTo(new DateTime(y, m, d, hh, mm, ss, ms))
            );
        }

        [Test]
        public void Document_Last_IsNull()
        {
            Assert.That(
                Pages[Pages.Count - 1].Document,
                Is.Null
            );
        }

        #endregion

        /* ----------------------------------------------------------------- */
        ///
        /// NewPage
        ///
        /// <summary>
        /// NewPage のテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void NewPage()
        {
            Pages.NewPage();
            Assert.That(
                IoEx.File.Exists(IoEx.Path.Combine(Pages.Directory, Pages[0].FileName)),
                Is.True
            );
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Save
        ///
        /// <summary>
        /// 定義ファイルの保存テストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("NewOrder.json")]
        public void Save(string filename)
        {
            Pages.Save(filename);
            Assert.That(
                IoEx.File.Exists(IoEx.Path.Combine(Pages.Directory, filename)),
                Is.True
            );
        }

        #endregion

        #region Helper methods

        /* ----------------------------------------------------------------- */
        ///
        /// Pages
        ///
        /// <summary>
        /// PageCollection オブジェクトを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private PageCollection Pages { get; set; }

        /* ----------------------------------------------------------------- */
        ///
        /// Copy
        ///
        /// <summary>
        /// Examples フォルダから Results フォルダへファイルをコピーします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Copy(string filename)
        {
            IoEx.File.Copy(
                IoEx.Path.Combine(Examples, filename),
                IoEx.Path.Combine(Results, filename),
                true
            );
        }

        #endregion
    }
}
