// <copyright file="VariableNode.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// This VariableNode will contain a dictionary of string keys and double values that all the variable
    /// nodes will share, if the variable node is set to a specific name that is within the dictionary of strings
    /// that name will be associatied with that value.
    /// </summary>
    public class VariableNode : ExpressionTreeNode
    {
        /// <summary>
        /// The name of the variable.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The dictionary of keys that all the variable nodes will share.
        /// </summary>
        private Dictionary<string, double> variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        /// <param name="variables">Reference to the dictionary of variables that will be changed
        /// when the user changes/inputs new values.</param>
        public VariableNode(string name, ref Dictionary<string, double> variables)
        {
            this.name = name;
            this.variables = variables;
        }

        /// <summary>
        /// If a VariableNode name is not found in the dictionary, return 0.0, otherwise return the value
        /// associated with the varible name in the dictionary.
        /// </summary>
        /// <returns>Value of the Variable.</returns>
        public override double Evaluate()
        {
            double value = 0.0;

            if (this.variables.ContainsKey(this.name))
            {
                value = this.variables[this.name];
            }

            return value;
        }
    }
}
