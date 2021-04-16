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
        /// Sets the dependency of the cell.
        /// </summary>
        public event PropertyChangedEventHandler DependencyChanged = delegate { };

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
        /// Gets or Sets the BGcolor value and invokes a property changeed event if the value is changed.
        /// </summary>
        public uint BGColor
        {
            get
            {
                return this.bgColor;
            }

            set
            {
                if (value == this.bgColor)
                {
                    return;
                }

                this.bgColor = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("BGColor"));
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
                this.DependencyChanged(this, new PropertyChangedEventArgs("ReEvalutate"));
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

        /// <summary>
        /// This function will allow the cell to subscribe to a referenced cell dependency.
        /// </summary>
        /// <param name="cell">Refereneced cell that this.cell will subscribe to.</param>
        public void SubscribeToCell(ref SpreadsheetCellValue cell)
        {
            cell.DependencyChanged += this.SpreadsheetCellValue_DependencyChanged;
        }

        /// <summary>
        /// This will fire the property changed event.
        /// </summary>
        /// <param name="sender">Spreadsheet Cell.</param>
        /// <param name="e">Dependency Changed Event.</param>
        private void SpreadsheetCellValue_DependencyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
        }
    }
}