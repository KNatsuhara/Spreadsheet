// <copyright file="SpreadsheetTests.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System.Collections.Generic;
using CptS321;
using NUnit.Framework;
using SpreadsheetEngine;
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
        public void TestCheckText()
        {
            Assert.That(true, Is.EqualTo(CheckText("=test")), "Did not identify =test");
            Assert.That(false, Is.EqualTo(CheckText("test")), "Did not identify test");
            Assert.That(true, Is.EqualTo(CheckText("=A1")), "Did not identify =A1");
            Assert.That(false, Is.EqualTo(CheckText(string.Empty)), "Did not identify string.Empty");
            Assert.That(false, Is.EqualTo(CheckText(" ")), "Did not identify whitespace");
            Assert.That(false, Is.EqualTo(CheckText(" =A1")), "Did not identify ' '=A1");
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

        /// <summary>
        /// Will test the CheckIfLetter method and return true if the string begins with a letter or false otherwise.
        /// </summary>
        [Test]
        public void TestCheckIsLetter()
        {
            Assert.That(true, Is.EqualTo(CheckIfLetter("A1")), "Did not identify A1");
            Assert.That(true, Is.EqualTo(CheckIfLetter("B1")), "Did not identify B1");
            Assert.That(false, Is.EqualTo(CheckIfLetter("12")), "Did not identify 12");
            Assert.That(false, Is.EqualTo(CheckIfLetter(string.Empty)), "Did not identify string.Empty");
            Assert.That(false, Is.EqualTo(CheckIfLetter(" ")), "Did not identify whitespace");
            Assert.That(false, Is.EqualTo(CheckIfLetter("=A1")), "Did not identify ' '=A1");
        }

        /// <summary>
        /// This function will test if the ExpressionTree variables are cleared from the dictionary.
        /// </summary>
        [Test]
        public void TestClearVariables()
        {
            ExpressionTree testTree = new ExpressionTree("A1+2");
            testTree.SetVariable("A1", 32);
            testTree.SetVariable("B2", -3);
            testTree.SetVariable("C3", 2);
            Dictionary<string, double> variables = testTree.GetVariables();
            Assert.That(3, Is.EqualTo(variables.Count), "Did not set variables in the expressionTree.");
            testTree.ClearVariables();
            Assert.That(0, Is.EqualTo(variables.Count), "Did not clear variables in the expressionTree.");
        }

        /// <summary>
        /// Will test the CheckBadReference method.
        /// </summary>
        [Test]
        public void TestCheckBadReference()
        {
            string cellText1 = "=asdf";
            string cellText2 = "=A1+B2";
            string cellText3 = "=ASD";
            string cellText4 = "=A51";
            string cellText5 = "=Z50";
            string cellText6 = "=34+54566-554+A1+B2*C3+(45-A44)+B9-FF";
            string cellText7 = "=34+54566-554+A1+B2*C3+(45-A44)+B9";

            Assert.That(true, Is.EqualTo(CheckBadReference(cellText1)), "Did not pass asdf");
            Assert.That(false, Is.EqualTo(CheckBadReference(cellText2)), "Did not pass A1+B2");
            Assert.That(true, Is.EqualTo(CheckBadReference(cellText3)), "Did not pass ASD");
            Assert.That(true, Is.EqualTo(CheckBadReference(cellText4)), "Did not pass A51");
            Assert.That(false, Is.EqualTo(CheckBadReference(cellText5)), "Did not pass Z50");
            Assert.That(true, Is.EqualTo(CheckBadReference(cellText6)), "Did not pass (45-A44)+B9-FF");
            Assert.That(false, Is.EqualTo(CheckBadReference(cellText7)), "Did not pass (45-A44)+B9");
        }
    }
}
