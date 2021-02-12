// <copyright file="Form1.cs" company="Koji Natsuhara">
// Copyright (c) Koji Natsuhara. All rights reserved.
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

namespace HW2_Hashset
{
    /// <summary>
    /// This class will create a form object.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// This function will initialize a form.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Prints out string to text box.
        /// </summary>
        /// <param name="str">Prints out string parameter.</param>
        public void PrintResults(string str)
        {
            this.textBoxResults.AppendText(str);
            this.textBoxResults.AppendText(Environment.NewLine);
        }
    }
}
