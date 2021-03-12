// <copyright file="ExpressionTree.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// This class will be take in a user inputted string and evaluate the expression that the user inputted.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// Contains the root node of the expression tree.
        /// </summary>
        private ExpressionTreeNode root;

        /// <summary>
        /// Contains all the variable names and values.
        /// </summary>
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// User inputted string that will be evaluated by the tree.
        /// </summary>
        private string expression;

        /// <summary>
        /// Creates all the operator nodes for the expression tree.
        /// </summary>
        private OperatorNodeFactory factory = new OperatorNodeFactory();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">Expression string.</param>
        public ExpressionTree(string expression)
        {
            this.expression = expression;
        }

        /// <summary>
        /// Returns true if the string is an operator.
        /// </summary>
        /// <param name="op">Operator of the string.</param>
        /// <returns>True if the string is an operator and false otherwise.</returns>
        public static bool IsOperator(string op)
        {
            if (op == string.Empty)
            {
                return false;
            }

            if (op == "+" || op == "/" ||
                op == "*" || op == "-")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true if the string is variable name.
        /// </summary>
        /// <param name="var">String that will be checked if it is a variable.</param>
        /// <returns>True if the string is a variable name or false otherwise.</returns>
        public static bool IsVariable(string var)
        {
            if (var == string.Empty)
            {
                return false;
            }

            char c = var[0];
            int ascii = (int)c;

            if ((ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Converts an expression string into postfix format.
        /// </summary>
        /// /// <param name="expression">Expression the user inputted.</param>
        /// <returns>Postfix string list.</returns>
        public static List<string> ConvertExpressionToPostfix(string expression)
        {
            List<string> postfix = new List<string>();
            string[] words = expression.Split('+', '-', '/', '*'); // Separates the operators from the string and adds them to an array
            Queue operators = new Queue(); // Inputs operators into this queue in order
            List<string> infix = new List<string>(); // Will convert the expression into a list string.
            Stack<string> stack = new Stack<string>(); // Will hold the operators during the infix to postfix process

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '+' || expression[i] == '/' ||
                    expression[i] == '*' || expression[i] == '-')
                {
                    operators.Enqueue(expression[i]); // Adds operators to the queue FIFO
                }
            }

            // Converts string to infix string list.
            int length = words.Length + operators.Count;
            int j = 0;
            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                {
                    infix.Insert(i, words[j]); // Inserts string then operator every other time.
                    j++;
                }
                else
                {
                    infix.Insert(i, operators.Dequeue().ToString());
                }
            }

            // Converts infix to postfix.
            for (int i = 0; i < infix.Count; i++)
            {
                if (infix[i] == "+" || infix[i] == "/" ||
                    infix[i] == "*" || infix[i] == "-")
                {
                    if (stack.Count > 0)
                    {
                        postfix.Add(stack.Pop()); // Pops out operator if stack already contains an operator
                        stack.Push(infix[i]); // Will change this for precedence, for future HW.
                    }
                    else
                    {
                        stack.Push(infix[i]);
                    }
                }
                else
                {
                    postfix.Add(infix[i]); // If not an operator, add to postfix list
                }
            }

            j = stack.Count;

            for (int i = 0; i < j; i++)
            {
                postfix.Add(stack.Pop()); // Empty the rest of the stack to the postfix list
            }

            return postfix; // Return postfix string list
        }

        /// <summary>
        /// Will go through the postfix expression and create the ExpressionTree.
        /// </summary>
        /// <param name="expression">Expression string the user inputs.</param>
        public void CreateExpressionTree()
        {
            List<string> postfix = ConvertExpressionToPostfix(this.expression);
            Stack<ExpressionTreeNode> stack = new Stack<ExpressionTreeNode>();
            string temp = string.Empty;
            OperatorNode current;

            for (int i = 0; i < postfix.Count; i++)
            {
                if (!IsOperator(postfix[i]))
                {
                    if (IsVariable(postfix[i]))
                    {
                        stack.Push(new VariableNode(postfix[i], ref this.variables)); // If variable node, push to stack
                    }
                    else
                    {
                        stack.Push(new ConstantNode(Convert.ToDouble(postfix[i]))); // Else is a constant node, push to stack
                    }
                }
                else
                {
                    current = this.factory.CreateOperatorNode(postfix[i]); // Create a new operator node based on the string operator

                    current.Right = stack.Pop(); // Pop out the first node and set it to the right of the operator node
                    current.Left = stack.Pop(); // Pop out the second node and set it to the left of the operator node
                    stack.Push(current); // Push the subexpression to the stack
                }
            }

            // Only element left in the stack will be the root of the expression tree
            this.root = stack.Pop(); // Set the root to the last element in the stack
        }

        /// <summary>
        /// Sets the specified varibale within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName">Name of the variable.</param>
        /// <param name="variableValue">Value of the variable.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            if (this.variables.ContainsKey(variableName))
            {
                this.variables[variableName] = variableValue; // Change the current value of preexisting key
            }
            else
            {
                this.variables.Add(variableName, variableValue); // Create new variable
            }
        }

        /// <summary>
        /// Evaluates the expression to a double value.
        /// </summary>
        /// <returns>Value of the evaluated expression.</returns>
        public double Evaluate()
        {
            return this.root.Evaluate();
        }
    }
}
