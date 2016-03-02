/* ------------------------------------------------------------------------- */
///
/// SearchReplaceTest.cs
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
using System.Linq;
using NUnit.Framework;
using Cube.Note.Azuki;

namespace Cube.Note.Tests.Azuki
{
    /* --------------------------------------------------------------------- */
    ///
    /// SearchReplaceTest
    /// 
    /// <summary>
    /// SearchReplace のテスト用クラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [Parallelizable]
    [TestFixture]
    class SearchReplaceTest : PageCollectionResource
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// Search_Count
        ///
        /// <summary>
        /// 検索のテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("Hello", true,  1)]
        [TestCase("Hello", false, 2)]
        public void Search_Count(string keyword, bool sensitive, int expected)
        {
            var src = Create();
            src.Search(keyword, sensitive, Pages.Everyone);
            Assert.That(src.Results.Count(), Is.EqualTo(expected));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Reset
        ///
        /// <summary>
        /// リセットのテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("Hello", false)]
        public void Reset(string keyword, bool sensitive)
        {
            var src = Create();
            src.Search(keyword, sensitive, Pages.Everyone);
            src.Reset();
            Assert.That(src.Results.Count(), Is.EqualTo(0));
        }

        #endregion

        #region Helper methods

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// SearchReplace オブエジェクトを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SearchReplace Create() => new SearchReplace(Pages);

        #endregion
    }
}
