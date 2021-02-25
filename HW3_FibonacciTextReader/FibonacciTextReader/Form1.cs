// <copyright file="Form1.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FibonacciTextReader
{
    /// <summary>
    /// This class creates the UI elements in the WinForm application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This function is if the Load from file button is clicked. This will read a text file a put the contents
        /// into the text box interface.
        /// </summary>
        /// <param name="sender">Load from file button.</param>
        /// <param name="e">Read file contents and put in text box.</param>
        private void MenuItem2_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            // Call the ShowDialog method to show the dialog box.
            // Process input if the user clicked OK.
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                // Set filter options and filter index.
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.Multiselect = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Create an instance of StreamReader to read from a file.
                        // The using statement also closes the StreamReader.
                        string filePath = openFileDialog1.FileName;
                        using (StreamReader reader = File.OpenText(filePath))
                        {
                            this.LoadText(reader);
                        }
                    }
                    catch (Exception f)
                    {
                        // Let the user know what went wrong.
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(f.Message);
                    }
                }
            }
        }

        private void MenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This function will read from the text box and save the text into a text file.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">e.</param>
        private void MenuItem5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // saveFileDialog1.InitialDirectory = "c:\\";

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string streamFileName = saveFileDialog1.FileName;
                StreamWriter myStream = new StreamWriter(streamFileName);
                myStream.WriteLine(this.textBox1.Text);
                myStream.Close();
            }
        }

        /// <summary>
        /// This function will take a System.IO.TextReader object and but it in the text box in the interface.
        /// </summary>
        /// <param name="sr">System.IO.TextReader object.</param>
        private void LoadText(TextReader sr)
        {
            string line = sr.ReadToEnd();
            this.textBox1.AppendText(line);
        }
    }
}
