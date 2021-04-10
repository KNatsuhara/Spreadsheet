// <copyright file="ExpressionTreeNode.cs" company="Koji Natsuhara (ID: 11666900)">
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
    /// This node will be the base node class for the constant, variable, and binary operator node classes.
    /// </summary>
    public abstract class ExpressionTreeNode
    {
        /// <summary>
        /// This will allow all ExpressionNodes to evaluate themselves.
        /// </summary>
        /// <returns>Value of the Node.</returns>
        public abstract double Evaluate();
    }
}
