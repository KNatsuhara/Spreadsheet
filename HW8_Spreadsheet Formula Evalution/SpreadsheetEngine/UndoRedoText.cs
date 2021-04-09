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
    public class UndoRedoText : UndoRedoCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoText"/> class.
        /// </summary>
        /// <param name="task">Message of task performed.</param>
        /// <param name="prevText">Stack containing all the Text popped off the curText stack.</param>
        /// <param name="curText">Stack containing all the current cell text.</param>
        /// <param name="prevCell">Stack with all the changed cells.</param>
        /// <param name="curCell">Stack with all the current cells.</param>
        public UndoRedoText(string task, Stack<string> prevText, Stack<string> curText, Stack<SpreadsheetCell> prevCell, Stack<SpreadsheetCell> curCell)
        {
            this.Task = task;
            this.PrevCellText = prevText;
            this.CurCellText = curText;
            this.PrevCell = prevCell;
            this.CurCell = curCell;
        }
    }
}
