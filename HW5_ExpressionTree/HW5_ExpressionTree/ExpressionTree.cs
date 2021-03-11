// <copyright file="ExpressionTree.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    // private Node root;

    // private Dictionary<string, Node> variables = new Dictionary<string, Node>();

    /// <summary>
    /// This class will be take in a user inputted string and evaluate the expression that the user inputted.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// User inputted string that will be evaluated by the tree.
        /// </summary>
        private string expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">Expression string.</param>
        public ExpressionTree(string expression)
        {
            this.expression = expression;
        }

        /// <summary>
        /// Sets the specified varibale within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName">Name of the variable.</param>
        /// <param name="variableValue">Value of the variable.</param>
        public void SetVariable(string variableName, double variableValue)
        {
        }

        /// <summary>
        /// Evaluates the expression to a double value.
        /// </summary>
        /// <returns>Value of the evaluated expression.</returns>
        public double Evaluate()
        {
            return 0;
        }
    }
}
