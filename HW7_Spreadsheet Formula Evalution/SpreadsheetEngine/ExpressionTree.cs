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
        /// This function will identify if the string/char is a left parenthesis.
        /// </summary>
        /// <param name="c">c.</param>
        /// <returns>True if left parenthesis.</returns>
        public static bool IsLeftParenthesis(string c)
        {
            if (c == "(")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This fucntion will identify if the string/char is a right parenthesis.
        /// </summary>
        /// <param name="c">c.</param>
        /// <returns>True if right parenthesis.</returns>
        public static bool IsRightParenthesis(string c)
        {
            if (c == ")")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Converts an expression string into infix string list.
        /// </summary>
        /// /// <param name="expression">Expression the user inputted.</param>
        /// <returns>Infix string list.</returns>
        public List<string> ConvertExpressionToInfix(string expression)
        {
            List<string> infix = new List<string>(); // List that return the infix expression
            Queue operators = new Queue(); // Queue for operators

            string[] words = expression.Split('+', '-', '/', '*'); // Splits all the variables and constants.

            for (int i = 0; i < expression.Length; i++)
            {
                if (this.IsOperator(expression[i].ToString()))
                {
                    operators.Enqueue(expression[i]); // Adds operators to the queue FIFO
                }
            }

            // Converts string to infix string list
            int lengthLoop = words.Length + operators.Count;
            int j = 0; // Index for the string array of words/constants
            int k = 0; // Index for reading the amount of parenthesis in each word
            int l = 0; // Used for the right parenthesis substring length
            for (int i = 0; i < lengthLoop; i++)
            {
                if (i % 2 == 0)
                {
                    if (words[j].StartsWith("("))
                    {
                        k = 0;
                        string leftParenthesis = words[j];
                        while (leftParenthesis[k] == '(')
                        {
                            infix.Add("("); // For every left parenthesis read, add to the list.
                            k++;
                        }

                        string operand = words[j].Substring(k, words[j].Length - k); // Removes left parenthesis from the word/constant
                        infix.Add(operand); // Adds word/constant to the infix list
                    }
                    else if (words[j].EndsWith(")"))
                    {
                        l = 0;
                        k = words[j].Length - 1;
                        string rightParenthesis = words[j];
                        while (rightParenthesis[k] == ')')
                        {
                            k--;
                            l++;
                        }

                        string rightOperand = words[j].Substring(0, words[j].Length - l); // Removes the right parenthesis from the word/constant
                        infix.Add(rightOperand); // Adds word/constant to the infix list
                        for (int x = 0; x < l; x++)
                        {
                            infix.Add(")"); // For every right parenthesis read, add to the list.
                        }
                    }
                    else
                    {
                        infix.Add(words[j]); // If the word does not contain any parenthesis, add to the infix list
                    }

                    j++;
                }
                else
                {
                    infix.Add(operators.Dequeue().ToString()); // Add operator to the list
                }
            }

            return infix;
        }

        /// <summary>
        /// Converts an infix string list into postfix format.
        /// </summary>
        /// /// <param name="infix">Infix string list.</param>
        /// <returns>Postfix string list.</returns>
        public List<string> ConvertInfixToPostfix(List<string> infix)
        {
            List<string> postfix = new List<string>();
            Stack<string> stack = new Stack<string>(); // Will hold the operators during the infix to postfix process
            string trash = string.Empty; // This will be a temporary string variable that will get rid of the "("
            string op = string.Empty;

            // Converts infix to postfix.
            for (int i = 0; i < infix.Count; i++)
            {
                if (infix[i] == "(")
                {
                    stack.Push(infix[i]); // If incoming symbol is "(" push to stack
                }
                else if (infix[i] == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        postfix.Add(stack.Pop()); // if incoming symbol is ")" pop stack symbols until encountering "("
                    }

                    trash = stack.Pop(); // Discard "("
                }
                else if (this.IsOperator(infix[i]))
                {
                    if (stack.Count == 0 || stack.Peek() == "(")
                    {
                        stack.Push(infix[i]); // If the stack is empty or has "(" at the top of the stack
                    }
                    else if (this.IsHigherPrecedence(infix[i], stack.Peek()) ||
                        (this.IsSamePrecedence(infix[i], stack.Peek()) && this.IsRightAssociative(infix[i])))
                    {
                        // If the incoming operator has a higher precendence, OR same precedence and right associative
                        stack.Push(infix[i]); // Push operator to stack
                    }
                    else if (this.IsLowerPrecedence(infix[i], stack.Peek()) ||
                        (this.IsSamePrecedence(infix[i], stack.Peek()) && this.IsLeftAssociative(infix[i])))
                    {
                        do
                        {
                            op = stack.Pop(); // Pop the stack until the incoming operator does not have a lower precedence
                            postfix.Add(op); // Or the same precedence and is left associative.
                        }
                        while (stack.Count > 0 && !IsLeftParenthesis(stack.Peek()) && (this.IsLowerPrecedence(op, stack.Peek()) ||
                        (this.IsSamePrecedence(op, stack.Peek()) && this.IsLeftAssociative(op))));

                        stack.Push(infix[i]); // Push operator to the stack
                    }
                }
                else
                {
                    postfix.Add(infix[i]); // If incoming symbol is an operand, output it
                }
            }

            int j = stack.Count; // Stack Count

            for (int i = 0; i < j; i++)
            {
                if (stack.Peek() != "(")
                {
                    postfix.Add(stack.Pop()); // Empty the rest of the stack to the postfix list
                }
            }

            return postfix; // Return postfix string list
        }

        /// <summary>
        /// Returns true if op has a higher precedence than op2.
        /// </summary>
        /// <param name="ops">Operator.</param>
        /// <param name="ops2">Operator2.</param>
        /// <returns>True if the op has higher precedence than op2.</returns>
        public bool IsHigherPrecedence(string ops, string ops2)
        {
            char op = ops.ToCharArray()[0];
            char op2 = ops2.ToCharArray()[0];
            if (this.factory.GetPrecedence(op) < this.factory.GetPrecedence(op2))
            {
                return true; // op > op2 (Precedence)
            }
            else
            {
                return false; // op > op2 (Precedence)
            }
        }

        /// <summary>
        /// Returns true if op has a lower precedence than op2.
        /// </summary>
        /// <param name="ops">Operator.</param>
        /// <param name="ops2">Operator2.</param>
        /// <returns>True if the op has lower precedence than op2.</returns>
        public bool IsLowerPrecedence(string ops, string ops2)
        {
            char op = ops.ToCharArray()[0];
            char op2 = ops2.ToCharArray()[0];
            if (this.factory.GetPrecedence(op) > this.factory.GetPrecedence(op2))
            {
                return true; // op < op2 (Precedence)
            }
            else
            {
                return false; // op < op2 (Precedence)
            }
        }

        /// <summary>
        /// Returns true if op has the same precedence as op2.
        /// </summary>
        /// <param name="ops">Operator.</param>
        /// <param name="ops2">Operator2.</param>
        /// <returns>True if the op has the same precedence as op2.</returns>
        public bool IsSamePrecedence(string ops, string ops2)
        {
            char op = ops.ToCharArray()[0];
            char op2 = ops2.ToCharArray()[0];
            if (this.factory.GetPrecedence(op) == this.factory.GetPrecedence(op2))
            {
                return true; // op == op2 (Precedence)
            }
            else
            {
                return false; // op != op2 (Precedence)
            }
        }

        /// <summary>
        /// Checks if the operator is right associative.
        /// </summary>
        /// <param name="ops">Operator.</param>
        /// <returns>True if operator is right associative.</returns>
        public bool IsRightAssociative(string ops)
        {
            char op = ops.ToCharArray()[0];
            if (this.factory.GetAssociative(op) == OperatorNode.Associative.Right)
            {
                return true; // op is right associative
            }
            else
            {
                return false; // op is not right associative
            }
        }

        /// <summary>
        /// Checks if the operator is left associative.
        /// </summary>
        /// <param name="ops">Operator.</param>
        /// <returns>True if operator is left associative.</returns>
        public bool IsLeftAssociative(string ops)
        {
            char op = ops.ToCharArray()[0];
            if (this.factory.GetAssociative(op) == OperatorNode.Associative.Left)
            {
                return true; // op is left associative
            }
            else
            {
                return false; // op is not left associative
            }
        }

        /// <summary>
        /// Returns true if the string is an operator.
        /// </summary>
        /// <param name="ops">Operator of the string.</param>
        /// <returns>True if the string is an operator and false otherwise.</returns>
        public bool IsOperator(string ops)
        {
            char op = ops.ToCharArray()[0];
            return this.factory.IsOperator(op);
        }

        /// <summary>
        /// Will go through the postfix expression and create the ExpressionTree.
        /// </summary>
        /// <param name="expression">Expression string the user inputs.</param>
        public void CreateExpressionTree(string expression)
        {
            List<string> infix = this.ConvertExpressionToInfix(expression);
            List<string> postfix = this.ConvertInfixToPostfix(infix);
            Stack<ExpressionTreeNode> stack = new Stack<ExpressionTreeNode>();
            string temp = string.Empty;
            OperatorNode current;
            this.variables.Clear(); // Variables are stored per expression, Clear out if the expression is CHANGED.

            for (int i = 0; i < postfix.Count; i++)
            {
                if (!this.IsOperator(postfix[i]))
                {
                    if (IsVariable(postfix[i]))
                    {
                        if (!this.variables.ContainsKey(postfix[i]))
                        {
                            this.SetVariable(postfix[i], 0); // If a new variable, add it to dictionary and set value to 0.
                        }

                        stack.Push(new VariableNode(postfix[i], ref this.variables)); // If variable node, push to stack
                    }
                    else
                    {
                        stack.Push(new ConstantNode(Convert.ToDouble(postfix[i]))); // Else is a constant node, push to stack
                    }
                }
                else
                {
                    char op = postfix[i].ToCharArray()[0];
                    current = this.factory.CreateOperatorNode(op); // Create a new operator node based on the string operator

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
        /// Returns a dictionary of variables and their values.
        /// </summary>
        /// <returns>The dictionary of variables.</returns>
        public Dictionary<string, double> GetVariables()
        {
            return this.variables;
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
