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
