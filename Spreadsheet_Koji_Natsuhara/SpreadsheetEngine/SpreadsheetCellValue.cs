// <copyright file="SpreadsheetCellValue.cs" company="Koji Natsuhara (ID: 11666900)">
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
    /// This is an internal child class of SpreadsheetCell that allows access to the set the value of the cell.
    /// </summary>
    internal class SpreadsheetCellValue : SpreadsheetCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCellValue"/> class.
        /// </summary>
        /// <param name="rowIndex">RowIndex.</param>
        /// <param name="columnIndex">ColumnIndex.</param>
        public SpreadsheetCellValue(int rowIndex, int columnIndex)
            : base(rowIndex, columnIndex)
        {
        }

        /// <summary>
        /// Declares the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// Gets or Sets the text member in the cell class.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (value == this.text)
                {
                    return;
                }

                this.text = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }

        /// <summary>
        /// Gets or Sets the value member in the cell class.
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value == this.value)
                {
                    return;
                }

                this.value = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }

        /// <summary>
        /// Creates SpreadsheetCellValue based on the parameters rowIndex and ColumnIndex.
        /// </summary>
        /// <param name="rowIndex">Row Index.</param>
        /// <param name="columnIndex">Column Index.</param>
        /// <returns>A new SpreadsheetCellValue object.</returns>
        public static SpreadsheetCellValue CreateCell(int rowIndex, int columnIndex)
        {
            return new SpreadsheetCellValue(rowIndex, columnIndex);
        }
    }
}
