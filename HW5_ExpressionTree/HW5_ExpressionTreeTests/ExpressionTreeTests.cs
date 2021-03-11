// <copyright file="ExpressionTreeTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW5_ExpressionTreeTests
{
    using System.Collections.Generic;
    using CptS321;
    using NUnit.Framework;

    /// <summary>
    /// This class will be responsible for testing the ExpressionTree class.
    /// </summary>
    [TestFixture]
    public class ExpressionTreeTests
    {
        /// <summary>
        /// Tests the constructor and evaluate method of the ConstantNode class.
        /// </summary>
        [Test]
        public void TestConstantNode()
        {
            ConstantNode constant1 = new ConstantNode(0.0);
            ConstantNode constant2 = new ConstantNode(1.0000001);
            ConstantNode constant3 = new ConstantNode(double.MaxValue);
            ConstantNode constant4 = new ConstantNode(double.MinValue);
            Assert.That(0, Is.EqualTo(constant1.Evaluate()), "Failed on constant1");
            Assert.That(1.0000001, Is.EqualTo(constant2.Evaluate()), "Failed on constant2");
            Assert.That(double.MaxValue, Is.EqualTo(constant3.Evaluate()), "Failed on constant3");
            Assert.That(double.MinValue, Is.EqualTo(constant4.Evaluate()), "Failed on constant4");
        }

        /// <summary>
        /// Tests the constructor and evaluate method of the VariableNode class.
        /// </summary>
        [Test]
        public void TestVariableNode()
        {
            Dictionary<string, double> reference = new Dictionary<string, double>();

            VariableNode variable1 = new VariableNode("test1", ref reference);
            VariableNode variable2 = new VariableNode("test2", ref reference);
            VariableNode variable3 = new VariableNode("notFound", ref reference);
            VariableNode variable4 = new VariableNode("max", ref reference);
            VariableNode variable5 = new VariableNode("min", ref reference);

            // Confirming that the VariableNodes are using the Dictionary as a reference and not a value type.
            reference.Add("test1", 3.4);
            reference.Add("test2", -1.2);
            reference.Add("max", double.MaxValue);
            reference.Add("min", double.MinValue);

            Assert.That(3.4, Is.EqualTo(variable1.Evaluate()), "Failed on variable1");
            Assert.That(-1.2, Is.EqualTo(variable2.Evaluate()), "Failed on variable2");
            Assert.That(0, Is.EqualTo(variable3.Evaluate()), "Failed on variable3");
            Assert.That(double.MaxValue, Is.EqualTo(variable4.Evaluate()), "Failed on variable4");
            Assert.That(double.MinValue, Is.EqualTo(variable5.Evaluate()), "Failed on variable5");
        }

        /// <summary>
        /// Tests the get, set and evaluate methods in the PlusOperatorNode.
        /// </summary>
        [Test]
        public void TestPlusOperatorNode()
        {
            Dictionary<string, double> reference = new Dictionary<string, double>();
            VariableNode variable1 = new VariableNode("test1", ref reference);
            VariableNode variable2 = new VariableNode("test2", ref reference);
            ConstantNode constant1 = new ConstantNode(4);
            ConstantNode constant2 = new ConstantNode(1);
            reference.Add("test1", 3.4);
            reference.Add("test2", 5);
            PlusOperatorNode add1 = new PlusOperatorNode();
            add1.Left = variable1;
            add1.Right = variable2; // This should evaluate to 8.4
            PlusOperatorNode add2 = new PlusOperatorNode();
            add2.Left = variable1;
            add2.Right = constant1; // This should evaluate to 7.4
            PlusOperatorNode add3 = new PlusOperatorNode();
            add3.Left = constant2;
            add3.Right = variable2; // This should evaluate to 6
            PlusOperatorNode add4 = new PlusOperatorNode();
            Assert.That(8.4, Is.EqualTo(add1.Evaluate()), "Failed on add1");
            Assert.That(7.4, Is.EqualTo(add2.Evaluate()), "Failed on add2");
            Assert.That(6, Is.EqualTo(add3.Evaluate()), "Failed on add3");
            Assert.That(() => add4.Evaluate(), Throws.TypeOf<System.NullReferenceException>());
        }
    }
}
