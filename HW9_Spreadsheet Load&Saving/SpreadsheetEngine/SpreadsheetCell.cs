// <copyright file="SpreadsheetCell.cs" company="Koji Natsuhara (ID: 11666900)">
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
    /// This class will represent one cell in the spreadsheet.
    /// </summary>
    public abstract class SpreadsheetCell : INotifyPropertyChanged
    {
        /// <summary>
        /// Text that can be typed into the cell.
        /// </summary>
        protected string text;

        /// <summary>
        /// A value that can be entered into the cell.
        /// </summary>
        protected string value;

        /// <summary>
        /// The value containing the background color of the cell.
        /// </summary>
        protected uint bgColor;

        /// <summary>
        /// Contains the row index of the cell.
        /// </summary>
        private readonly int rowIndex;

        /// <summary>
        /// Contains the column index of the cell.
        /// </summary>
        private readonly int columnIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// </summary>
        /// <param name="rowIndex">RowIndex.</param>
        /// <param name="columnIndex">ColumnIndex.</param>
        public SpreadsheetCell(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
            this.bgColor = 0xFFFFFFFF; // Default background color of the cell is white
            this.text = string.Empty;
            this.value = string.Empty;
        }

        /// <summary>
        /// Declares the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// Gets the rowIndex of the cell.
        /// </summary>
        public int RowIndex
        {
            get { return this.rowIndex; }
        }

        /// <summary>
        /// Gets the columnIndex of the cell.
        /// </summary>
        public int ColumnIndex
        {
            get { return this.columnIndex; }
        }

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
        /// Gets the value member in the cell class.
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }
        }
    }
}
