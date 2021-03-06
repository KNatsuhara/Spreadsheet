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
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the value member in the cell class.
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }
        }

        /// <summary>
        /// Sets the value member in cell class.
        /// </summary>
        /// <param name="value">Value.</param>
        protected void SetValue(string value)
        {
            if (value == this.value)
            {
                return;
            }

            this.value = value;
            this.PropertyChanged(this, new PropertyChangedEventArgs("Value"));
        }
    }
}
