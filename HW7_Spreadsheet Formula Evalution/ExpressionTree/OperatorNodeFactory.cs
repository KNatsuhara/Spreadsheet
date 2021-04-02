// <copyright file="OperatorNodeFactory.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CptS321
{
    /// <summary>
    /// This class will return the corresonding operator Node based on the string inputted.
    /// </summary>
    public class OperatorNodeFactory
    {
        /// <summary>
        /// Contains all the operators node types in a dictionary.
        /// </summary>
        private Dictionary<char, Type> operators = new Dictionary<char, Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNodeFactory"/> class.
        /// </summary>
        public OperatorNodeFactory()
        {
            // Instantiate the delegate with a lambda expression
            this.TraverseAvailableOperators((op, type) => this.operators.Add(op, type));
        }

        /// <summary>
        /// OnOperator delegate.
        /// </summary>
        /// <param name="op">operator character.</param>
        /// <param name="type">operator type.</param>
        private delegate void OnOperator(char op, Type type);

        /// <summary>
        /// Returns a list of all supported operators.
        /// </summary>
        /// <returns>List of all supported operators.</returns>
        public List<char> GetOperators()
        {
            return new List<char>(this.operators.Keys);
        }

        /// <summary>
        /// Will create an instance of the operator node class based on the inputted character.
        /// </summary>
        /// <param name="op">Operator character.</param>
        /// <returns>OperatorNode instance of specified operator.</returns>
        public OperatorNode CreateOperatorNode(char op)
        {
            if (this.operators.ContainsKey(op))
            {
                object operatorNodeObject = System.Activator
                    .CreateInstance(this.operators[op]);
                if (operatorNodeObject is OperatorNode)
                {
                    return (OperatorNode)operatorNodeObject;
                }
            }

            throw new Exception("Unhandled operator");
        }

        /// <summary>
        /// Gets the precedence value of a specified operator.
        /// </summary>
        /// <param name="op">Operator character.</param>
        /// <returns>ushort precedence value.</returns>
        public ushort GetPrecedence(char op)
        {
            ushort precedenceValue = 0;
            if (this.operators.ContainsKey(op))
            {
                Type type = this.operators[op];
                PropertyInfo propertyInfo = type.GetProperty("Precedence");
                if (propertyInfo != null)
                {
                    object propertyValue = propertyInfo.GetValue(type);
                    if (propertyValue is ushort)
                    {
                        precedenceValue = (ushort)propertyValue;
                    }
                }
            }

            return precedenceValue;
        }

        /// <summary>
        /// Returns the associativity of an operator.
        /// </summary>
        /// <param name="op">character operator.</param>
        /// <returns>operator associativity.</returns>
        public OperatorNode.Associative GetAssociative(char op)
        {
            OperatorNode.Associative associative = OperatorNode.Associative.Right;
            if (this.operators.ContainsKey(op))
            {
                Type type = this.operators[op];
                PropertyInfo propertyInfo = type.GetProperty("Associativity");
                if (propertyInfo != null)
                {
                    object propertyValue = propertyInfo.GetValue(type);
                    if (propertyValue is OperatorNode.Associative)
                    {
                        associative = (OperatorNode.Associative)propertyValue;
                    }
                }
            }

            return associative;
        }

        /// <summary>
        /// Returns if a char is an operator or not.
        /// </summary>
        /// <param name="c">Character being checked if it is an operator.</param>
        /// <returns>True if char is operator, otherwise false.</returns>
        public bool IsOperator(char c)
        {
            return this.operators.ContainsKey(c);
        }

        /// <summary>
        /// This function will search for all instances of the classes that inherit from the OperatorNode
        /// class and add the types to the dictionary with the specified operator character key.
        /// </summary>
        /// <param name="onOperator">OnOperator.</param>
        private void TraverseAvailableOperators(OnOperator onOperator)
        {
            // get the type declaration of OperatorNode
            Type operatorNodeType = typeof(OperatorNode);

            // Iterate over all loaded assemblies:
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Get all types that inherit from our operatorNode class using LINQ
                IEnumerable<Type> operatorTypes = assembly.GetTypes()
                    .Where(type => type.IsSubclassOf(operatorNodeType));

                // Iterate over those subclasses of OperatorNode
                foreach (var type in operatorTypes)
                {
                    // for each subclass, retrieve the Operator property
                    PropertyInfo operatorField = type.GetProperty("Operator");
                    if (operatorField != null)
                    {
                        // Get the character of the Operator
                        object value = operatorField.GetValue(type);

                        // If the property is not static, use the following code instead:
                        // object value = operatorField.GetValue(Activator.CreateInstance(type, new ConstantNode("0"), new ConstantNode("0")));
                        if (value is char)
                        {
                            char operatorSymbol = (char)value;

                            // And invoke the function passed as parameter
                            // With the operator symbol and the operator class
                            onOperator(operatorSymbol, type);
                        }
                    }
                }
            }
        }
    }
}
