using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Collection of Undo/Redo Commands.
    /// </summary>
    public class UndoRedoCollection
    {
        /// <summary>
        /// Message of what Redo and Undo task triggered.
        /// </summary>
        private string mTask;

        /// <summary>
        /// This stack will keep track of all the changes in cell text that will be used for REDO.
        /// </summary>
        private Stack<string> mPrevCellText = new Stack<string>();

        /// <summary>
        /// This stack will keep track of the current cell text that will taken off and put on PrevCellText stack for UNDO.
        /// </summary>
        private Stack<string> mCurCellText = new Stack<string>();

        /// <summary>
        /// This stack will keep track of all the changes in cell color that will be used for REDO.
        /// </summary>
        private Stack<uint> mPrevCellColor = new Stack<uint>();

        /// <summary>
        /// This stack will keep track of the current cell color that will taken off and put on PrevCellColor stack for UNDO.
        /// </summary>
        private Stack<uint> mCurCellColor = new Stack<uint>();

        /// <summary>
        /// This stack will keep track of which cell that was changed that will be used for REDO.
        /// </summary>
        private Stack<SpreadsheetCell> mPrevCell = new Stack<SpreadsheetCell>();

        /// <summary>
        /// This stack will keep track of the current cells that will taken off and put on PrevCell stack for UNDO.
        /// </summary>
        private Stack<SpreadsheetCell> mCurCell = new Stack<SpreadsheetCell>();

        /// <summary>
        /// Gets the message on what Undo/Redo action will be performed.
        /// </summary>
        public string Task
        {
            get
            {
                return this.mTask;
            }
        }

        /// <summary>
        ///  Virtual Undo method that all UndoRedo child classes will override.
        /// </summary>
        public virtual void Undo() { }

        /// <summary>
        /// Virtual Redo method that all UndoRedo child classes will override.
        /// </summary>
        public virtual void Redo() { }
    }
}
