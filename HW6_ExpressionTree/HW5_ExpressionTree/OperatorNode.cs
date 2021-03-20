// <copyright file="OperatorNode.cs" company="Koji Natsuhara (ID: 11666900)">
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
    /// Each sub node will have 2 properties:
    /// Operator: String corresponding to the operator.
    /// Precedence: Number corresponding to the Law of Operation.
    /// </summary>
    public abstract class OperatorNode : ExpressionTreeNode
    {
        /// <summary>
        /// Right = 0, and Left = 1.
        /// </summary>
        public enum Associative
        {
            /// <summary>
            /// Will identify if the operator is right associative.
            /// </summary>
            Right,

            /// <summary>
            /// Will identify if the operator is left associative.
            /// </summary>
            Left,
        }

        /// <summary>
        /// Gets or Sets the ExpressionTreeNode for the left child.
        /// </summary>
        public ExpressionTreeNode Left { get; set; }

        /// <summary>
        /// Gets or Sets the ExpressionTreeNode for the right child.
        /// </summary>
        public ExpressionTreeNode Right { get; set; }
    }
}
