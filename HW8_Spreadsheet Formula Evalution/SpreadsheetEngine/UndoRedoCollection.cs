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
        /// Gets or Sets the message on what Undo/Redo action will be performed.
        /// </summary>
        public string Task
        {
            get
            {
                return this.mTask;
            }

            set
            {
                if (this.mTask == value)
                {
                    return;
                }

                this.mTask = value;
            }
        }

        /// <summary>
        /// Gets or Sets the PrevCellText stack.
        /// </summary>
        public Stack<string> PrevCellText
        {
            get
            {
                return this.mPrevCellText;
            }

            set
            {
                if (this.mPrevCellText == value)
                {
                    return;
                }

                this.mPrevCellText = value;
            }
        }

        /// <summary>
        /// Gets or Sets the CurCellText stack.
        /// </summary>
        public Stack<string> CurCellText
        {
            get
            {
                return this.mCurCellText;
            }

            set
            {
                if (this.mCurCellText == value)
                {
                    return;
                }

                this.mCurCellText = value;
            }
        }

        /// <summary>
        /// Gets or Sets the PrevCellColor stack.
        /// </summary>
        public Stack<uint> PrevCellColor
        {
            get
            {
                return this.mPrevCellColor;
            }

            set
            {
                if (this.mPrevCellColor == value)
                {
                    return;
                }

                this.mPrevCellColor = value;
            }
        }

        /// <summary>
        /// Gets or Sets the CurCellColor stack.
        /// </summary>
        public Stack<uint> CurCellColor
        {
            get
            {
                return this.mCurCellColor;
            }

            set
            {
                if (this.mCurCellColor == value)
                {
                    return;
                }

                this.mCurCellColor = value;
            }
        }

        /// <summary>
        /// Gets or Sets the PrevCell stack.
        /// </summary>
        public Stack<SpreadsheetCell> PrevCell
        {
            get
            {
                return this.mPrevCell;
            }

            set
            {
                if (this.mPrevCell == value)
                {
                    return;
                }

                this.mPrevCell = value;
            }
        }

        /// <summary>
        /// Gets or Sets the CurCell stack.
        /// </summary>
        public Stack<SpreadsheetCell> CurCell
        {
            get
            {
                return this.mCurCell;
            }

            set
            {
                if (this.mCurCell == value)
                {
                    return;
                }

                this.mCurCell = value;
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
