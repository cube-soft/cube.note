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
using System;
using Sgry.Azuki;
using Cube.Note.Azuki;
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
    [Parallelizable]
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
        public void Directory_IsResultsInbox()
        {
            Assert.That(
                Pages.Directory,
                Is.EqualTo(IoEx.Path.Combine(Results, PageCollection.DefaultInbox))
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
        /// Import_Abstract
        ///
        /// <summary>
        /// Import (Extend) のテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("Kana-EUC.txt",       "あいうえお")]
        [TestCase("Kana-JIS.txt",       "あいうえお")]
        [TestCase("Kana-Shift-JIS.txt", "あいうえお")]
        [TestCase("Kana-UTF8.txt",      "あいうえお")]
        [TestCase("Kana-UTF8-BOM.txt",  "あいうえお")]
        [TestCase("Kana-UTF16BE.txt",   "あいうえお")]
        [TestCase("Kana-UTF16LE.txt",   "あいうえお")]
        public void Import_Abstract(string filename, string expected)
        {
            Pages.Import(null, 0, IoEx.Path.Combine(Examples, filename), 100);
            Assert.That(
                Pages[0].Abstract,
                Is.EqualTo(expected)
            );
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Import_Length
        ///
        /// <summary>
        /// Import (Extend) のテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("LineCode-CR.txt",   20)]
        [TestCase("LineCode-CRLF.txt", 20)]
        [TestCase("LineCode-LF.txt",   20)]
        public void Import_Length(string filename, int expected)
        {
            Pages.Import(null, 0, IoEx.Path.Combine(Examples, filename), 100);
            var document = Pages[0].Document as Document;
            Assert.That(
                document.Text.Length,
                Is.EqualTo(expected)
            );
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Import_Directory
        ///
        /// <summary>
        /// ディレクトリをインポートするテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("Import", 3)]
        public void Import_Directory_Count(string directory, int expected)
        {
            var count = Pages.Count;
            Pages.Import(null, 0, IoEx.Path.Combine(Examples, directory), 100);
            Assert.That(
                Pages.Count - count,
                Is.EqualTo(expected)
            );
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Duplicate
        ///
        /// <summary>
        /// ページを複製するテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Duplicate()
        {
            Pages.Duplicate(0, Pages[0]);
            Assert.That(Pages[0].Abstract, Is.EqualTo(Pages[1].Abstract));
            Assert.That(Pages[0].Tags.Count, Is.EqualTo(Pages[1].Tags.Count));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Duplicate_Imported
        ///
        /// <summary>
        /// インポートしたページを複製するテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("Kana-UTF8-BOM.txt")]
        public void Duplicate_Imported(string filename)
        {
            Pages.Import(null, 0, IoEx.Path.Combine(Examples, filename), 100);
            Pages.Duplicate(0, Pages[0]);
            Assert.That(
                Pages[0].CreateDocument(Pages.Directory).Length,
                Is.AtLeast(1)
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

        /* ----------------------------------------------------------------- */
        ///
        /// Recover
        ///
        /// <summary>
        /// Recover (Extend) のテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Recover()
        {
            Pages.Clear();
            Pages.Recover(Examples, 100);
            Assert.That(
                Pages.Count,
                Is.EqualTo(3)
            );
        }

        #endregion
    }
}
