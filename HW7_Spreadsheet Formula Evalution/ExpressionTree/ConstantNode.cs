// <copyright file="ConstantNode.cs" company="Koji Natsuhara (ID: 11666900)">
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
    /// This node represents a constant numerical value.
    /// </summary>
    public class ConstantNode : ExpressionTreeNode
    {
        /// <summary>
        /// The numerical value the node contains.
        /// </summary>
        private readonly double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        /// <param name="value">Value of the node.</param>
        public ConstantNode(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Returns the numerical value of the node.
        /// </summary>
        /// <returns>Value as a double.</returns>
        public override double Evaluate()
        {
            return this.value;
        }
    }
}
