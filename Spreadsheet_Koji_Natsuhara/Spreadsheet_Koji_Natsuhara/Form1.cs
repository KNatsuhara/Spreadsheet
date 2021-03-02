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

namespace Spreadsheet_Koji_Natsuhara
{
    /// <summary>
    /// This class will intitalize the winform application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.SetupGridColumns();
            this.SetupGridRows();
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
    }
}
