// <copyright file="Spreadsheet.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadsheetEngine;

namespace CptS321
{
    /// <summary>
    /// This is the Spreadsheet class that will set up the cell.
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// This is the 2D array that will contain all the cells in the spreadsheet.
        /// </summary>
        private SpreadsheetCellValue[,] cellGrid;

        /// <summary>
        /// Contains the number of rows intialized when creating the spreadsheet grid.
        /// </summary>
        private int rowCount;

        /// <summary>
        /// Contains the number of columns intialized when creating the spreadsheet grid.
        /// </summary>
        private int columnCount;

        /// <summary>
        /// Expression tree which evaluates the cells text.
        /// </summary>
        private ExpressionTree expressionTree = new ExpressionTree(string.Empty);

        /// <summary>
        /// Stack that holds all the undo commands.
        /// </summary>
        private Stack<IUndoRedoCollection> undo = new Stack<IUndoRedoCollection>();

        /// <summary>
        /// Stack that holds all the redo commands.
        /// </summary>
        private Stack<IUndoRedoCollection> redo = new Stack<IUndoRedoCollection>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="numRows">Set number of rows in spreadsheet.</param>
        /// <param name="numColumns">Set number of columns in spreadsheet.</param>
        public Spreadsheet(int numRows, int numColumns)
        {
            this.rowCount = numRows;
            this.columnCount = numColumns;

            this.cellGrid = new SpreadsheetCellValue[numRows, numColumns];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    SpreadsheetCellValue newCell = SpreadsheetCellValue.CreateCell(i, j);
                    this.cellGrid[i, j] = newCell;
                    this.cellGrid[i, j].PropertyChanged += this.SpreadsheetCellValue_PropertyChanged;
                }
            }
        }

        /// <summary>
        /// Declares the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChangedValue = (sender, e) => { };

        /// <summary>
        /// This method will evaluate the text of the string and decide if it is a value or not.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <returns>True if the text starts with "=" or false otherwise.</returns>
        public static bool CheckText(string text)
        {
            if (text == string.Empty)
            {
                return false; // Returns false if the string is empty.
            }

            char eq = text[0]; // Will check the first character in the string.

            if (eq == '=' && text.Length > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This function will evaluate the text in the cell and return the value of the cell. This is assuming
        /// that the text starts with and "=".
        /// </summary>
        /// <param name="cellText">Cell text.</param>
        /// <returns>String of the evaluated text.</returns>
        public string EvaluateText(string cellText)
        {
            string text = cellText.Substring(1, cellText.Length - 1);
            this.expressionTree.CreateExpressionTree(text);
            return this.expressionTree.Evaluate().ToString();
        }

        /// <summary>
        /// Gets the cell at a specific location or returns null if there is no such cell.
        /// </summary>
        /// <param name="row">Row Index.</param>
        /// <param name="col">Column Index.</param>
        /// <returns>Abstract SpreadsheetCell class.</returns>
        public SpreadsheetCell GetCell(int row, int col)
        {
            if (this.cellGrid[row, col] == null)
            {
                return null;
            }
            else
            {
                return this.cellGrid[row, col];
            }
        }

        /// <summary>
        /// Sets the cell text in the cell grid.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="col">Column.</param>
        /// <param name="text">Text.</param>
        public void SetCellText(int row, int col, string text)
        {
            string newText;
            if (text == null)
            {
                newText = string.Empty;
            }
            else
            {
                newText = text;
            }

            string oldText;
            if (this.cellGrid[row, col].Text == null)
            {
                oldText = string.Empty;
            }
            else
            {
                oldText = this.cellGrid[row, col].Text;
            }

            UndoRedoText newCmd = new UndoRedoText(oldText, newText, ref this.cellGrid[row, col]);
            this.undo.Push(newCmd);
            this.cellGrid[row, col].Text = text;
        }

        /// <summary>
        /// Sets the cell color in the cell grid.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
        /// <param name="bgColor">Uint.</param>
        public void SetCellColor(int row, int col, uint bgColor)
        {
            this.cellGrid[row, col].BGColor = bgColor;
        }

        /// <summary>
        /// Gets the rowCount.
        /// </summary>
        /// <returns>Integer.</returns>
        public int GetRowCount()
        {
            return this.rowCount;
        }

        /// <summary>
        /// Gets the columnCount.
        /// </summary>
        /// <returns>Integer.</returns>
        public int GetColumnCount()
        {
            return this.columnCount;
        }

        /// <summary>
        /// Demo for the button.
        /// </summary>
        public void Demo()
        {
            Random rnd = new Random();
            int row = 0;
            int col = 0;

            for (int i = 0; i < 50; i++)
            {
                col = rnd.Next(0, 26);
                row = rnd.Next(0, 50);

                this.cellGrid[row, col].Text = "Yay! It worked!";
            }

            row = 1;
            for (int i = 0; i < 50; i++)
            {
                this.cellGrid[i, 1].Text = "This is cell B " + row; // Setting cells in column B to "This is cell B #
                row++;
            }

            row = 1;
            for (int i = 0; i < 50; i++)
            {
                this.cellGrid[i, 0].Text = "=B" + row; // Setting the column A = to adjacent B cells.
                row++;
            }
        }

        /// <summary>
        /// This method is for testing the get and setting function for value.
        /// </summary>
        public void TestForSetValue()
        {
            this.cellGrid[0, 0].Value = "test";
            this.cellGrid[1, 1].Value = "=Test";
            this.cellGrid[3, 3].Value = "=A1";
            this.cellGrid[10, 10].Value = "=B33";
        }

        /// <summary>
        /// Performs an Undo command off the Undo stack.
        /// </summary>
        public void Undo()
        {
            IUndoRedoCollection command = this.undo.Pop();
            command.Undo();
            this.redo.Push(command);
        }

        /// <summary>
        /// Performs a Redo command off the Redo stack.
        /// </summary>
        public void Redo()
        {
            IUndoRedoCollection command = this.redo.Pop();
            command.Execute();
            this.undo.Push(command);
        }

        /// <summary>
        /// Checks if the undo stack is empty.
        /// </summary>
        /// <returns>Return true if undo stack is not empty.</returns>
        public bool CanUndo()
        {
            if (this.undo.Count == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the redo stack is empty.
        /// </summary>
        /// <returns>Return true if redo stack is not empty.</returns>
        public bool CanRedo()
        {
            if (this.redo.Count == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns string of which task was performed from Undo stack.
        /// </summary>
        /// <returns>Return true if redo stack is not empty.</returns>
        public string GetUndoTask()
        {
            return this.undo.Peek().TextMessage();
        }

        /// <summary>
        /// Returns string of which command was performed from Redo stack.
        /// </summary>
        /// <returns>Return true if redo stack is not empty.</returns>
        public string GetRedoTask()
        {
            return this.redo.Peek().TextMessage();
        }

        /// <summary>
        /// This will identify the text of a cell and depending if the text string starts with "=" will update the value of the cell.
        /// If the string starts with "=" this will set the value of the cell to equal another cell's value. Otherwise, the value
        /// will be set equal to the text.
        /// </summary>
        /// <param name="sender.">Spreadsheet.</param>
        /// <param name="e">Cell argument.</param>
        private void SpreadsheetCellValue_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
            {
                SpreadsheetCellValue cell = (SpreadsheetCellValue)sender;
                string evalutedText = cell.Text;
                char columnCharacter = Convert.ToChar(cell.ColumnIndex + 65);
                string cellName = columnCharacter.ToString().ToUpper() + (cell.RowIndex + 1).ToString(); // Converts cell location to a cellName

                if (CheckText(evalutedText))
                {
                    // string sub = evalutedText.Substring(2, evalutedText.Length - 2);
                    // char colSymbol = evalutedText[1];
                    // int row = int.Parse(sub) - 1;
                    // int col = (int)colSymbol - 'A';
                    // cell.Value = this.cellGrid[row, col].Value; // If the string has 3 characters, this assumes it is in the format "=A#"
                    string newValue = this.EvaluateText(cell.Text);
                    // this.SetCellText(cell.RowIndex, cell.ColumnIndex, evalutedText);
                    cell.Value = newValue; // Evaluates the cell text if it starts with "=" and returns the double as a string
                    this.expressionTree.SetVariable(cellName, Convert.ToDouble(newValue)); // This is assuming that the user inputs the formula without errors and adds the cell value to the dictionary
                }
                else
                {
                    // this.SetCellText(cell.RowIndex, cell.ColumnIndex, cell.Text);
                    cell.Value = cell.Text; // If the string does not start with "=" then the string value will be set to the text of the cell.

                    double number;
                    if (double.TryParse(cell.Value, out number))
                    {
                        this.expressionTree.SetVariable(cellName, number); // If cell value can be parsed to double, set cellName, double
                    }
                    else
                    {
                      this.expressionTree.SetVariable(cellName, 0); // If cell value cannot be parsed to double, set cellName, 0 (default)
                    }
                }
                this.PropertyChangedValue(sender, new PropertyChangedEventArgs("Value"));
            }
            else if (e.PropertyName == "BGColor")
            {
                this.PropertyChangedValue(sender, new PropertyChangedEventArgs("BGColor")); // Fire off property changed event for color.
            }
        }
    }
}
