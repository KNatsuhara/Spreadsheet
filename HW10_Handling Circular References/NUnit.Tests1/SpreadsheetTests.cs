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
            string cellText8 = "=asd";
            string cellText9 = "=as";
            string cellText10 = "=a!";

            Assert.That(true, Is.EqualTo(CheckBadReference(cellText1)), "Did not pass asdf");
            Assert.That(false, Is.EqualTo(CheckBadReference(cellText2)), "Did not pass A1+B2");
            Assert.That(true, Is.EqualTo(CheckBadReference(cellText3)), "Did not pass ASD");
            Assert.That(true, Is.EqualTo(CheckBadReference(cellText4)), "Did not pass A51");
            Assert.That(false, Is.EqualTo(CheckBadReference(cellText5)), "Did not pass Z50");
            Assert.That(true, Is.EqualTo(CheckBadReference(cellText6)), "Did not pass (45-A44)+B9-FF");
            Assert.That(false, Is.EqualTo(CheckBadReference(cellText7)), "Did not pass (45-A44)+B9");
            Assert.That(true, Is.EqualTo(CheckBadReference(cellText8)), "Did not pass asd");
            Assert.That(true, Is.EqualTo(CheckBadReference(cellText9)), "Did not pass as");
            Assert.That(true, Is.EqualTo(CheckBadReference(cellText10)), "Did not pass a!");
        }

        /// <summary>
        /// Will test the CheckSelfReference method.
        /// </summary>
        [Test]
        public void TestCheckSelfReference()
        {
            string cellText1 = "=A1";
            string cellText2 = "=A1+C1*C3+(A5+C4)";
            string cellText3 = "=A1+D1+B1*67+R3";
            string cellText4 = "=A1+D1+B1*67+R3";

            Assert.That(true, Is.EqualTo(CheckSelfReference(cellText1, "A1")), "Did not pass A1");
            Assert.That(true, Is.EqualTo(CheckSelfReference(cellText2, "A5")), "Did not pass A5");
            Assert.That(true, Is.EqualTo(CheckSelfReference(cellText3, "R3")), "Did not pass R3");
            Assert.That(false, Is.EqualTo(CheckSelfReference(cellText4, "C2")), "Did not pass C2");
        }

        /// <summary>
        /// Will test the CreateCellVariableList.
        /// </summary>
        [Test]
        public void TestCreateCellVariableList()
        {
            string cellText1 = "=A1";
            string cellText2 = "=A1+C1*C3+(A5+C4)";
            string cellText3 = "=A1+D1+B1*67+R3";
            string cellText4 = "=34*45";

            List<string> cellList1 = CreateCellVariableList(cellText1);
            List<string> cellList2 = CreateCellVariableList(cellText2);
            List<string> cellList3 = CreateCellVariableList(cellText3);
            List<string> cellList4 = CreateCellVariableList(cellText4);

            List<string> expectedList1 = new List<string> { "A1" };
            List<string> expectedList2 = new List<string> { "A1", "C1", "C3", "A5", "C4" };
            List<string> expectedList3 = new List<string> { "A1", "D1", "B1", "R3" };
            List<string> expectedList4 = new List<string> { };

            CollectionAssert.AreEquivalent(expectedList1, cellList1);
            CollectionAssert.AreEquivalent(expectedList2, cellList2);
            CollectionAssert.AreEquivalent(expectedList3, cellList3);
            CollectionAssert.AreEquivalent(expectedList4, cellList4);
        }
    }
}
