// <copyright file="OperatorNodeFactory.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

namespace CptS321
{
    /// <summary>
    /// This class will return the corresonding operator Node based on the string inputted.
    /// </summary>
    public class OperatorNodeFactory
    {
        /// <summary>
        /// Will return the corresponding operator node based on the string input.
        /// </summary>
        /// <param name="op">String operator.</param>
        /// <returns>Operator Node.</returns>
        public OperatorNode CreateOperatorNode(string op)
        {
            if (op == "+")
            {
                return new PlusOperatorNode();
            }
            else if (op == "-")
            {
                return new MinusOperatorNode();
            }
            else if (op == "*")
            {
                return new MultiplyOperatorNode();
            }
            else
            {
                return new DivideOperatorNode();
            }
        }

        /// <summary>
        /// This function will return the precedence value of an operator.
        /// </summary>
        /// <param name="op">The operator needed to get the precedence.</param>
        /// <returns>The precedence value of the operator.</returns>
        public int GetPrecedence(string op)
        {
            if (op == "+")
            {
                return PlusOperatorNode.Precedence;
            }
            else if (op == "-")
            {
                return MinusOperatorNode.Precedence;
            }
            else if (op == "*")
            {
                return MultiplyOperatorNode.Precedence;
            }
            else
            {
                return DivideOperatorNode.Precedence;
            }
        }

        /// <summary>
        /// This function will return the associativity of an operator.
        /// </summary>
        /// <param name="op">The operator needed to get the associativity.</param>
        /// <returns>The associativity of the operator.</returns>
        public int GetAssociativity(string op)
        {
            if (op == "+")
            {
                return (int)PlusOperatorNode.Associativity;
            }
            else if (op == "-")
            {
                return (int)MinusOperatorNode.Associativity;
            }
            else if (op == "*")
            {
                return (int)MultiplyOperatorNode.Associativity;
            }
            else
            {
                return (int)DivideOperatorNode.Associativity;
            }
        }
    }
}
