/* ------------------------------------------------------------------------- */
///
/// SettingsValueTest.cs
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
using System.Drawing;
using NUnit.Framework;
using IoEx = System.IO;


namespace Cube.Note.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// SettingsValueTest
    /// 
    /// <summary>
    /// SettingsValue のテスト用クラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class SettingsValueTest : FileResource
    {
        #region SetUp and TearDown

        /* ----------------------------------------------------------------- */
        ///
        /// OneTimeSetUp
        ///
        /// <summary>
        /// 1 度だけ初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var src = IoEx.Path.Combine(Examples, "Settings.json");
            Settings = SettingsValue.Create(src);
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Settings
        ///
        /// <summary>
        /// SettingsValue オブジェクトを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private SettingsValue Settings { get; set; }

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
        
        [TestCase("Settings.json")]
        public void Path(string expected)
        {
            Assert.That(
                Settings.Path,
                Is.EqualTo(IoEx.Path.Combine(Examples, expected))
            );
        }

        [TestCase("MS Gothic UI", 9.0)]
        public void Font(string name, double size)
        {
            Assert.That(
                Settings.Font,
                Is.EqualTo(new Font(name, (float)size, FontStyle.Regular, GraphicsUnit.Point))
            );
        }

        [TestCase(1, 1, 1)]
        public void ForeColor(int red, int green, int blue)
        {
            Assert.That(
                Settings.ForeColor,
                Is.EqualTo(Color.FromArgb(red, green, blue))
            );
        }

        [TestCase("Window")]
        public void BackColor(string expected)
        {
            Assert.That(
                Settings.BackColor,
                Is.EqualTo(Color.FromName(expected))
            );
        }

        [TestCase("Highlight")]
        public void HighlightBackColor(string expected)
        {
            Assert.That(
                Settings.HighlightBackColor,
                Is.EqualTo(Color.FromName(expected))
            );
        }

        [TestCase("HighlightText")]
        public void HighlightForeColor(string expected)
        {
            Assert.That(
                Settings.HighlightForeColor,
                Is.EqualTo(Color.FromName(expected))
            );
        }

        [TestCase("Control")]
        public void LineNumberBackColor(string expected)
        {
            Assert.That(
                Settings.LineNumberBackColor,
                Is.EqualTo(Color.FromName(expected))
            );
        }

        [TestCase("ControlDark")]
        public void LineNumberForeColor(string expected)
        {
            Assert.That(
                Settings.LineNumberForeColor,
                Is.EqualTo(Color.FromName(expected))
            );
        }

        [TestCase("ControlDark")]
        public void SpecialCharsColor(string expected)
        {
            Assert.That(
                Settings.SpecialCharsColor,
                Is.EqualTo(Color.FromName(expected))
            );
        }

        [TestCase("ControlDark")]
        public void CurrentLineColor(string expected)
        {
            Assert.That(
                Settings.CurrentLineColor,
                Is.EqualTo(Color.FromName(expected))
            );
        }

        [TestCase(10)]
        public void AutoSaveTime(int expected)
        {
            Assert.That(
                Settings.AutoSaveTime,
                Is.EqualTo(TimeSpan.FromSeconds(expected))
            );
        }

        [TestCase(4)]
        public void TabWidth(int expected)
        {
            Assert.That(
                Settings.TabWidth,
                Is.EqualTo(expected)
            );
        }

        [TestCase(false)]
        public void TabToSpace(bool expected)
        {
            Assert.That(
                Settings.TabToSpace,
                Is.EqualTo(expected)
            );
        }

        [TestCase(true)]
        public void LineNumberVisible(bool expected)
        {
            Assert.That(
                Settings.LineNumberVisible,
                Is.EqualTo(expected)
            );
        }

        [TestCase(true)]
        public void RulerVisible(bool expected)
        {
            Assert.That(
                Settings.RulerVisible,
                Is.EqualTo(expected)
            );
        }

        [TestCase(false)]
        public void SpecialCharsVisible(bool expected)
        {
            Assert.That(
                Settings.SpecialCharsVisible,
                Is.EqualTo(expected)
            );
        }

        [TestCase(true)]
        public void EolVisible(bool expected)
        {
            Assert.That(
                Settings.EolVisible,
                Is.EqualTo(expected)
            );
        }

        [TestCase(true)]
        public void TabVisible(bool expected)
        {
            Assert.That(
                Settings.TabVisible,
                Is.EqualTo(expected)
            );
        }

        [TestCase(false)]
        public void SpaceVisible(bool expected)
        {
            Assert.That(
                Settings.SpaceVisible,
                Is.EqualTo(expected)
            );
        }

        [TestCase(true)]
        public void FullSpaceVisible(bool expected)
        {
            Assert.That(
                Settings.FullSpaceVisible,
                Is.EqualTo(expected)
            );
        }

        [TestCase(false)]
        public void CurrentLineVisible(bool expected)
        {
            Assert.That(
                Settings.CurrentLineVisible,
                Is.EqualTo(expected)
            );
        }

        [TestCase(false)]
        public void ModifiedLineVisible(bool expected)
        {
            Assert.That(
                Settings.ModifiedLineVisible,
                Is.EqualTo(expected)
            );
        }

        [TestCase(true)]
        public void RemoveWarning(bool expected)
        {
            Assert.That(
                Settings.RemoveWarning,
                Is.EqualTo(expected)
            );
        }

        #endregion

        /* ----------------------------------------------------------------- */
        ///
        /// Save
        ///
        /// <summary>
        /// 定義ファイルの保存テストを行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("NewSettings.json")]
        public void Save(string filename)
        {
            var dest = IoEx.Path.Combine(Results, filename);
            Settings.Save(dest);
            Assert.That(
                IoEx.File.Exists(dest),
                Is.True
            );
        }

        #endregion

    }
}
