/* ------------------------------------------------------------------------- */
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
    class PageCollectionTest : PageCollectionResource
    {
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

        [TestCase(2016, 2, 5, 19, 52, 52, 418)]
        public void LastUpdate_Last(int y, int m, int d, int hh, int mm, int ss, int ms)
        {
            Assert.That(
                Pages[Pages.Count - 1].LastUpdate,
                Is.EqualTo(new DateTime(y, m, d, hh, mm, ss, ms))
            );
        }

        [TestCase("Tag2", 2)]
        public void Tags_Count(string name, int expected)
        {
            Assert.That(
                Pages.Tags.Create(name).Count,
                Is.EqualTo(expected)
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
        /// Remove
        ///
        /// <summary>
        /// ページを削除するテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Remove()
        {
            var filename = Pages[0].FileName;
            Pages.RemoveAt(0);
            Assert.That(
                IoEx.File.Exists(IoEx.Path.Combine(Pages.Directory, filename)),
                Is.False
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
    }
}
