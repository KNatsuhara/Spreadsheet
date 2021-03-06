// <copyright file="SpreadsheetTests.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using CptS321;
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
        /// Will test the EvaluateText and return true if the string begins with an "=" or false otherwise.
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

        /// <summary>
        /// Will test the set and get Text function from the SpreadsheetCellValue class.
        /// </summary>
        [Test]
        public void TestSetText()
        {
            Spreadsheet testSheet = new Spreadsheet(11, 11);

            testSheet.GetCell(0, 0).Text = "(0,0)";
            testSheet.GetCell(1, 1).Text = "(1,1)";
            testSheet.GetCell(3, 3).Text = "(3,3)";
            testSheet.GetCell(10, 10).Text = "(10,10)";

            Assert.That("(0,0)", Is.EqualTo(testSheet.GetCell(0, 0).Text), "Did not set 0,0");
            Assert.That("(1,1)", Is.EqualTo(testSheet.GetCell(1, 1).Text), "Did not set 1,1");
            Assert.That("(3,3)", Is.EqualTo(testSheet.GetCell(3, 3).Text), "Did not set 3,3");
            Assert.That("(10,10)", Is.EqualTo(testSheet.GetCell(10, 10).Text), "Did not set 10,10");
        }

        /// <summary>
        /// Will test the set and get Value function from the SpreadsheetCellValue class.
        /// </summary>
        [Test]
        public void TestSetValue()
        {
            Spreadsheet testSheet = new Spreadsheet(50, 26);

            testSheet.TestForSetValue();

            Assert.That("test", Is.EqualTo(testSheet.GetCell(0, 0).Value), "Did not get null");
            Assert.That("=Test", Is.EqualTo(testSheet.GetCell(1, 1).Value), "Did not get =Test");
            Assert.That("=A1", Is.EqualTo(testSheet.GetCell(3, 3).Value), "Did not get =A1");
            Assert.That("=B33", Is.EqualTo(testSheet.GetCell(10, 10).Value), "Did not get =B33");
        }
    }
}
