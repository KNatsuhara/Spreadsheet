// <copyright file="UndoRedoCollection.cs" company="Koji Natsuhara (ID: 11666900)">
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
    /// Interface of Undo/Redo Commands.
    /// </summary>
    public interface IUndoRedoCollection
    {
        /// <summary>
        /// Execute method for a command.
        /// </summary>
        void Execute();

        /// <summary>
        /// Redo the command that was previously executed.
        /// </summary>
        void Undo();

        /// <summary>
        /// Returns text message of command.
        /// </summary>
        /// <returns>Text message.</returns>
        string TextMessage();
    }
}
