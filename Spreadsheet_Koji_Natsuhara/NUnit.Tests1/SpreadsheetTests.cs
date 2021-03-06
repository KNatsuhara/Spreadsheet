// <copyright file="SpreadsheetTests.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using NUnit.Framework;
using static CptS321.Spreadsheet;

namespace NUnit.Tests1
{
    /// <summary>
    /// This class will test functions in a class.
    /// </summary>
    [TestFixture]
    public class SpreadsheetTests
    {
        /// <summary>
        /// Temporary test method.
        /// </summary>
        [Test]
        public void TestEvaluateText()
        {
            Assert.That(true, Is.EqualTo(EvaluateText("=test")), "Did not identify =test");
            Assert.That(false, Is.EqualTo(EvaluateText("test")), "Did not identify test");
            Assert.That(true, Is.EqualTo(EvaluateText("=A1")), "Did not identify =A1");
            Assert.That(false, Is.EqualTo(EvaluateText(string.Empty)), "Did not identify string.Empty");
            Assert.That(false, Is.EqualTo(EvaluateText(" ")), "Did not identify whitespace");
            Assert.That(false, Is.EqualTo(EvaluateText(" =A1")), "Did not identify ' '=A1");
        }
    }
}
