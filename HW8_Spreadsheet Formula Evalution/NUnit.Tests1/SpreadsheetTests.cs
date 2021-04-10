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
        /// Will test the add UndoRedoText constructor.
        /// </summary>
        [Test]
        public void TestUndoRedoText()
        {
            Stack<SpreadsheetCell> currentCells = new Stack<SpreadsheetCell>();
            Stack<SpreadsheetCell> prevCells = new Stack<SpreadsheetCell>();
            Stack<string> currText = new Stack<string>();
            Stack<string> prevText = new Stack<string>();

            UndoRedoText testCommandText = new UndoRedoText("Text Change", prevText, currText, prevCells, currentCells);
            Assert.That("Text Change", Is.EqualTo(testCommandText.Task), "Task Message are not the same!");
        }

        /// <summary>
        /// Will test the add Undo/Redo command and check if Undo/Redo stack is empty.
        /// </summary>
        [Test]
        public void TestUndoRedoEmpty()
        {
            Stack<SpreadsheetCell> currentCells = new Stack<SpreadsheetCell>();
            Stack<SpreadsheetCell> prevCells = new Stack<SpreadsheetCell>();
            Stack<string> currText = new Stack<string>();
            Stack<string> prevText = new Stack<string>();

            UndoRedoText testCommandText = new UndoRedoText("Text Change", prevText, currText, prevCells, currentCells);

            UndoRedo testUndoRedo = new UndoRedo();

            Assert.That(true, Is.EqualTo(testUndoRedo.IsUndoEmpty()), "The Undo Stack is not empty!");
            Assert.That(true, Is.EqualTo(testUndoRedo.IsRedoEmpty()), "The Redo Stack is not empty!");

            testUndoRedo.AddUndo(testCommandText);

            Assert.That(false, Is.EqualTo(testUndoRedo.IsUndoEmpty()), "The Undo Stack is empty!");
            Assert.That(true, Is.EqualTo(testUndoRedo.IsRedoEmpty()), "The Redo Stack is not empty!");

            UndoRedoCollection testUndoRedoCollect = testUndoRedo.PerformUndo();
            Assert.That(false, Is.EqualTo(testUndoRedo.IsRedoEmpty()), "The Redo Stack is empty!");
        }
    }
}
