// <copyright file="UndoRedoBGColor.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Will perform all the Undo/Redo actions for the Cell Text property.
    /// </summary>
    internal class UndoRedoBGColor : IUndoRedoCollection
    {
        /// <summary>
        /// Previous color of the cell.
        /// </summary>
        private uint prevColor;

        /// <summary>
        /// New color of the cell.
        /// </summary>
        private uint newColor;

        /// <summary>
        /// Reference to the spreadsheetcell.
        /// </summary>
        private SpreadsheetCellValue refCell;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoBGColor"/> class.
        /// </summary>
        /// <param name="prevColor">Prev Color.</param>
        /// <param name="newColor">Cur Color.</param>
        /// <param name="refCell">Reference Cell.</param>
        public UndoRedoBGColor(uint prevColor, uint newColor, ref SpreadsheetCellValue refCell)
        {
            this.prevColor = prevColor;
            this.newColor = newColor;
            this.refCell = refCell;
        }

        /// <summary>
        /// Execute Undo text cell.
        /// </summary>
        public void Execute()
        {
            this.refCell.BGColor = this.newColor;
        }

        /// <summary>
        /// Execute Redo text cell.
        /// </summary>
        public void Undo()
        {
            this.refCell.BGColor = this.prevColor;
        }

        /// <summary>
        /// Text message of command performed.
        /// </summary>
        /// <returns>Text Change.</returns>
        public string TextMessage()
        {
            return "Cell Background Color";
        }
    }
}
