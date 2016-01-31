/* ------------------------------------------------------------------------- */
///
/// DocumentHandlerTest.cs
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
using NUnit.Framework;
using Cube.Note.Azuki;

namespace Cube.Note.Tests.Azuki
{
    /* --------------------------------------------------------------------- */
    ///
    /// DocumentTest
    /// 
    /// <summary>
    /// DocumentHandler のテスト用クラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class DocumentHandlerTest : PageCollectionResource
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// CreateDocument
        ///
        /// <summary>
        /// Document オブジェクトを生成するテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("LastPage")]
        public void CreateDocument_Last(string expected)
        {
            Assert.That(
                Pages[Pages.Count - 1].CreateDocument(Pages.Directory).Text,
                Is.EqualTo(expected)
            );
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SaveDocument_DoesNotThrow
        ///
        /// <summary>
        /// 内容をファイルに保存するテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void SaveDocument_Last_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
            {
                var page = Pages[Pages.Count - 1];
                var document = page.CreateDocument(Pages.Directory);
                document.Replace("Replaced", 0, document.Length);
                page.SaveDocument(Pages.Directory);
            });
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Search_Count
        ///
        /// <summary>
        /// 検索のテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("Hello", 1)]
        public void Search_Count(string keyword, int expected)
        {
            var results = new List<Page>();
            Pages.Search(keyword, results);

            Assert.That(
                results.Count,
                Is.EqualTo(expected)
            );
        }

        #endregion
    }
}
