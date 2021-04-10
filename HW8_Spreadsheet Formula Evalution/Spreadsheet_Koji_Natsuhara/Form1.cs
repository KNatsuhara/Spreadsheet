// <copyright file="Form1.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CptS321;
using SpreadsheetEngine;

namespace CptS321
{
    /// <summary>
    /// This class will intitalize the winform application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Spreadsheet object as a member variable.
        /// </summary>
        private Spreadsheet mainSpreadSheet;

        private string cellValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.mainSpreadSheet = new Spreadsheet(50, 26);

            this.mainSpreadSheet.PropertyChangedValue += this.MainSpreadSheet_PropertyChangedValue;

            this.dataGridView1.CellBeginEdit += this.DataGridView1_CellBeginEdit;
            this.dataGridView1.CellEndEdit += this.DataGridView1_CellEndEdit;

            this.SetupGridColumns();
            this.SetupGridRows();
        }

        /// <summary>
        /// Cells in UI grid values are set to the values of the logic engine cell.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">e.</param>
        private void MainSpreadSheet_PropertyChangedValue(object sender, PropertyChangedEventArgs e)
        {
            SpreadsheetCell temp = sender as SpreadsheetCell;

            if (e.PropertyName == "Value")
            {
                SpreadsheetCell cell = (SpreadsheetCell)sender;
                this.dataGridView1[cell.ColumnIndex, cell.RowIndex].Value = cell.Value;
            }

            if (e.PropertyName == "BGColor")
            {
                this.dataGridView1.Rows[temp.RowIndex].Cells[temp.ColumnIndex].Style.BackColor = Color.FromArgb((int)temp.BGColor);
            }
        }

        /// <summary>
        /// Handles an event to reflect that the current DataGridViewCell is being editied. When the user starts to edit the cell,
        /// the cell value should change to the Text property of the cell.
        /// </summary>
        /// <param name="sender">Data Grid View.</param>
        /// <param name="e">Event Argument.</param>
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewCell cell = this.dataGridView1[col, row];
            cell.Value = this.mainSpreadSheet.GetCell(row, col).Text;
            if (cell.Value == null)
            {
                this.cellValue = string.Empty;
            }
            else
            {
                this.cellValue = cell.Value.ToString();
            }
        }

        /// <summary>
        /// CellEndEdit event occurs only when the user finishes editing the cell, it must go back to the Value.
        /// </summary>
        /// <param name="sender">The Data Grid View.</param>
        /// <param name="e">The event args holding the cell information.</param>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewCell dataGridCell = this.dataGridView1[col, row];
            if (dataGridCell.Value.ToString() != this.cellValue.ToString())
            {
                this.mainSpreadSheet.SetCellText(row, col, dataGridCell.Value.ToString());
            }

            dataGridCell.Value = this.mainSpreadSheet.GetCell(row, col).Value;
        }

        /// <summary>
        /// This function will setup the columns of the dataGridView1 object from A to Z.
        /// </summary>
        private void SetupGridColumns()
        {
            int alpha = 65; // ASCII VALUE 65 == A

            for (int i = 0; i < 26; i++)
            {
                char c = Convert.ToChar(alpha); // CONVERT INT TO CHAR
                this.dataGridView1.Columns.Add(c.ToString(), c.ToString()); // Setting header text and name to c.
                alpha++; // INCREMENT alpha
            }
        }

        /// <summary>
        /// This function will setup the rows of the dataGridView1 object from 1 to 50.
        /// </summary>
        private void SetupGridRows()
        {
            int j = 1;
            for (int i = 0; i < 50; i++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[i].HeaderCell.Value = j.ToString(); // Names the header cell values.
                j++;
            }
        }

        /// <summary>
        /// Form1_Load Function.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">e.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This button if clicked will perform a demo test.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void DemoButton_Click(object sender, EventArgs e)
        {
            this.mainSpreadSheet.Demo();
        }

        /// <summary>
        /// Will show the color dialog and allow change the background color of a cell.
        /// </summary>
        /// <param name="sender">Spreadsheet.</param>
        /// <param name="e">Background Color Notification.</param>
        private void ChangeBackgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog myDialog = new ColorDialog();

            // Keeps the user from selecting a custom color.
            myDialog.AllowFullOpen = true;

            // Allows the user to get help. (The default is false.)
            myDialog.ShowHelp = true;

            // If OK was not pressed, then set the cd color to white
            if (myDialog.ShowDialog() != DialogResult.OK)
            {
                myDialog.Color = Color.FromArgb(-1);
            }

            // For all selected cells, change the background color in the spreadsheet.
            foreach (DataGridViewCell gridCell in this.dataGridView1.SelectedCells)
            {
                SpreadsheetCell dataCell = this.mainSpreadSheet.GetCell(gridCell.RowIndex, gridCell.ColumnIndex);
                this.mainSpreadSheet.SetCellColor(gridCell.RowIndex, gridCell.ColumnIndex, (uint)myDialog.Color.ToArgb());
            }

            this.dataGridView1.ClearSelection(); // Clears off user highlighted cells.
        }

        /// <summary>
        /// Turns on or off the Undo and Redo button depending if the there are any Undo or Redo tasks in the stack.
        /// </summary>
        /// <param name="sender">DataGridCells.</param>
        /// <param name="e">Event argument.</param>
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mainSpreadSheet.CanUndo() == false)
            {
                this.undoToolStripMenuItem.Enabled = false; // Disable button if there are no undos.
            }
            else
            {
                this.undoToolStripMenuItem.Enabled = true; // turn on button
                this.undoToolStripMenuItem.Text = "Undo";
                this.undoToolStripMenuItem.Text += " " + this.mainSpreadSheet.GetUndoTask(); // show user what the undo task is
            }

            if (this.mainSpreadSheet.CanRedo() == false)
            {
                this.redoToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.redoToolStripMenuItem.Enabled = true;
                this.redoToolStripMenuItem.Text = "Redo";
                this.redoToolStripMenuItem.Text += " " + this.mainSpreadSheet.GetRedoTask(); // show user redo task
            }
        }

        /// <summary>
        /// Will undo the most recent change in the UI.
        /// </summary>
        /// <param name="sender">SpreadsheetCell.</param>
        /// <param name="e">Undo Button press.</param>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mainSpreadSheet.CanUndo() == true)
            {
                this.mainSpreadSheet.Undo(); // Run Undo command.
            }
            else
            {
                return; // If no undo command available then return.
            }
        }

        /// <summary>
        /// Will redo the most latest change in the UI.
        /// </summary>
        /// <param name="sender">SpreadsheetCell.</param>
        /// <param name="e">Redo Button press.</param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mainSpreadSheet.CanRedo() == true)
            {
                this.mainSpreadSheet.Redo(); // Run Redo Command.
            }
            else
            {
                return; // If no redo command available then return.
            }
        }
    }
}
