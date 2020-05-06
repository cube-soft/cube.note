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
using NUnit.Framework;
using IoEx = System.IO;

namespace Cube.Note.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// TagCollectionTest
    /// 
    /// <summary>
    /// TagCollection のテスト用クラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [Parallelizable]
    [TestFixture]
    class TagCollectionTest : FileResource
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// Load
        ///
        /// <summary>
        /// ファイルからタグ情報を読み込むテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase(5)]
        public void Load(int expected)
        {
            Assert.That(
                Create().Count,
                Is.EqualTo(expected)
            );
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Save
        ///
        /// <summary>
        /// タグ情報をファイルに保存するテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("NewTags.json")]
        public void Save(string filename)
        {
            var dest = IoEx.Path.Combine(Results, filename);
            var tags = Create();
            tags.Create("NewTag1");
            tags.Save(dest);

            Assert.That(IoEx.File.Exists(dest), Is.True);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Create_IsNotNull
        ///
        /// <summary>
        /// 新しいタグを追加するテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("Tag1")]
        [TestCase("NonExistedTagName")]
        public void Create_IsNotNull(string name)
        {
            Assert.That(
                Create().Create(name),
                Is.Not.Null
            );
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Remove
        ///
        /// <summary>
        /// タグを削除するテストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("Tag1", 4)]
        [TestCase("NonExistedTagNameRemoving", 5)]
        public void Remove(string name, int expected)
        {
            var tags = Create();
            tags.Remove(name);
            Assert.That(
                tags.Count,
                Is.EqualTo(expected)
            );
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Tag_Name
        ///
        /// <summary>
        /// Name が取得できているかどうかをテストします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase(0, "Tag1")]
        public void Tag_Name(int index, string expected)
        {
            Assert.That(
                Create()[index].Name,
                Is.EqualTo(expected)
            );
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Tag_Count
        ///
        /// <summary>
        /// Count が初期化できているかどうかをテストします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase(0, 0)]
        public void Tag_Count(int index, int expected)
        {
            Assert.That(
                Create()[index].Count,
                Is.EqualTo(expected)
            );
        }

        #endregion

        #region Helper methods

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// TagCollection オブジェクトを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagCollection Create()
        {
            var dest = new TagCollection(Examples);
            dest.Load();
            return dest;
        }

        #endregion
    }
}
