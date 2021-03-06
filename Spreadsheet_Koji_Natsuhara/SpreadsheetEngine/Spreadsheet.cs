// <copyright file="Spreadsheet.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="numRows">Set number of rows in spreadsheet.</param>
        /// <param name="numColumns">Set number of columns in spreadsheet.</param>
        public Spreadsheet(int numRows, int numColumns)
        {
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
        /// This method will evaluate the text of the string and decide if it is a value or not.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <returns>True if the text starts with "=" or false otherwise.</returns>
        public static bool EvaluateText(string text)
        {
            if (text == string.Empty)
            {
                return false; // Returns false if the string is empty.
            }

            char eq = text[0]; // Will check the first character in the string.

            if (eq == '=')
            {
                return true;
            }
            else
            {
                return false;
            }
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
        /// This will identify the text of a cell and depending if the text string starts with "=" will update the value of the cell.
        /// If the string starts with "=" this will set the value of the cell to equal another cell's value. Otherwise, the value
        /// will be set equal to the text.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void SpreadsheetCellValue_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
            {
                SpreadsheetCellValue cell = (SpreadsheetCellValue)sender;
                string evalutedText = cell.Text;

                if (EvaluateText(evalutedText))
                {
                    if (evalutedText.Length == 3)
                    {
                        char rowSymbol = evalutedText[1];
                        char colSymbol = evalutedText[2];
                        int row = (int)rowSymbol - 65;
                        int col = (int)colSymbol;
                        cell.Value = this.cellGrid[row, col].Value; // If the string has 3 characters, this assumes it is in the format "=A#"
                    }
                    else
                    {
                        cell.Value = cell.Text; // When the string is greater than 3 characters.
                    }
                }
                else
                {
                    cell.Value = cell.Text; // If the string does not start with "=" then the string value will be set to the text of the cell.
                }
            }
        }
    }
}
