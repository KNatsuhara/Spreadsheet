// <copyright file="ExpressionTreeTests.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System.Collections;
using System.Collections.Generic;
using CptS321;
using System.Reflection;
using NUnit.Framework;

namespace OperatorNodeTests
{
    [TestFixture()]
    public class OperatorNodeTests
    {
        [Test, Order(1)]
        public void AddingNewOperatorInDifferentAssembly()
        {
            Assembly.Load("SpreadsheetEngine");

            OperatorNodeFactory factory = new OperatorNodeFactory();
            List<char> expectedOperators = new List<char> { '+', '-', '*', '/' };
            CollectionAssert.AreEquivalent(expectedOperators, factory.GetOperators());
        }

        [Test, Order(2)]
        public void CheckPrecedenceValues()
        {
            OperatorNodeFactory factory = new OperatorNodeFactory();
            Assert.AreEqual(12, factory.GetPrecedence('/'));
            Assert.AreEqual(12, factory.GetPrecedence('*'));
            Assert.AreEqual(14, factory.GetPrecedence('-'));
            Assert.AreEqual(14, factory.GetPrecedence('+'));
        }

        [Test, Order(3)]
        public void CheckAssociativeValues()
        {
            OperatorNodeFactory factory = new OperatorNodeFactory();
            Assert.AreEqual(OperatorNode.Associative.Left, factory.GetAssociative('/'));
            Assert.AreEqual(OperatorNode.Associative.Left, factory.GetAssociative('*'));
            Assert.AreEqual(OperatorNode.Associative.Left, factory.GetAssociative('+'));
            Assert.AreEqual(OperatorNode.Associative.Left, factory.GetAssociative('-'));
        }
    }
}

