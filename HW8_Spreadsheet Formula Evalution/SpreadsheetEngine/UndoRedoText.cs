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

        /// <summary>
        /// Will Undo the most recent Cell text change and and add it to the PrevCellText stack.
        /// </summary>
        public override void Undo()
        {
            Stack<SpreadsheetCell> tempCell = new Stack<SpreadsheetCell>(this.PrevCell); // create copy of previous cells
            Stack<string> tempText = new Stack<string>(this.PrevCellText); // create copy of old text

            while (this.PrevCell.Count > 0)
            {
                this.PrevCell.Pop().Text = this.PrevCellText.Pop(); // set cell text back to previous text
            }

            this.PrevCellText = tempText; // save for redos
            this.PrevCell = tempCell;
        }

        /// <summary>
        /// Will Redo the latest Cell text change and and add it to the CurCellText stack.
        /// </summary>
        public override void Redo()
        {
            Stack<SpreadsheetCell> tempCell = new Stack<SpreadsheetCell>(this.CurCell); // create copy of previous cells
            Stack<string> tempText = new Stack<string>(this.CurCellText); // create copy of old text

            while (this.CurCell.Count > 0)
            {
                this.CurCell.Pop().Text = this.CurCellText.Pop(); // set cell text back to previous text
            }

            this.CurCellText = tempText; // save for undos
            this.CurCell = tempCell;
        }
    }
}
