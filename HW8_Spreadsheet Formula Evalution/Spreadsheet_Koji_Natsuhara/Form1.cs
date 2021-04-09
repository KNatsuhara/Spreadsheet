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

namespace Spreadsheet_Koji_Natsuhara
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
            if (e.PropertyName == "Value")
            {
                SpreadsheetCell cell = (SpreadsheetCell)sender;
                this.dataGridView1[cell.ColumnIndex, cell.RowIndex].Value = cell.Value;
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
            DataGridViewCell cell = this.dataGridView1[col, row];

            this.mainSpreadSheet.SetCellText(row, col, cell.Value.ToString());
            cell.Value = this.mainSpreadSheet.GetCell(row, col).Value;
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
    }
}
