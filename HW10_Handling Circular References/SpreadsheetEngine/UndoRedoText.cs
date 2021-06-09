// <copyright file="UndoRedoText.cs" company="Koji Natsuhara (ID: 11666900)">
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
    internal class UndoRedoText : IUndoRedoCollection
    {
        /// <summary>
        /// Previous Text of the cell.
        /// </summary>
        private string prevText;

        /// <summary>
        /// Current text of the cell.
        /// </summary>
        private string newText;

        /// <summary>
        /// Reference to the spreadsheetcell.
        /// </summary>
        private SpreadsheetCellValue refCell;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoText"/> class.
        /// </summary>
        /// <param name="prevText">Prev Text.</param>
        /// <param name="newText">Cur Text.</param>
        /// <param name="refCell">Reference Cell.</param>
        public UndoRedoText(string prevText, string newText, ref SpreadsheetCellValue refCell)
        {
            this.prevText = prevText;
            this.newText = newText;
            this.refCell = refCell;
        }

        /// <summary>
        /// Execute Undo text cell.
        /// </summary>
        public void Execute()
        {
            this.refCell.Text = this.newText;
        }

        /// <summary>
        /// Execute Redo text cell.
        /// </summary>
        public void Undo()
        {
            this.refCell.Text = this.prevText;
        }

        /// <summary>
        /// Text message of command performed.
        /// </summary>
        /// <returns>Text Change.</returns>
        public string TextMessage()
        {
            return "Text Change";
        }
    }
}
