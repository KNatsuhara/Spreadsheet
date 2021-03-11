// <copyright file="ExpressionTreeTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW5_ExpressionTreeTests
{
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
    }
}
