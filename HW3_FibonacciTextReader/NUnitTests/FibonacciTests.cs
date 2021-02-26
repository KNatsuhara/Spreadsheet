// <copyright file="FibonacciTests.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using HW3_FibonacciTextReader;
using NUnit.Framework;

namespace NUnitTests
{
    /// <summary>
    /// This class will test all the Fibonacci Methods.
    /// </summary>
    [TestFixture]
    public class FibonacciTests
    {
        /// <summary>
        /// Will test the FibonacciTextReader constructor function.
        /// </summary>
        [Test]
        public void TestFibonacciConstructor()
        {
            FibonacciTextReader test1 = new FibonacciTextReader(0);
            FibonacciTextReader test2 = new FibonacciTextReader(-5);
            FibonacciTextReader test3 = new FibonacciTextReader(-10);
            FibonacciTextReader test4 = new FibonacciTextReader(50);
            FibonacciTextReader test5 = new FibonacciTextReader(101);

            Assert.That(0, Is.EqualTo(test1.GetMaxNumLines()), "Did not set the correct number of maxNumLines!");
            Assert.That(-5, Is.EqualTo(test2.GetMaxNumLines()), "Did not set the correct number of maxNumLines!");
            Assert.That(-10, Is.EqualTo(test3.GetMaxNumLines()), "Did not set the correct number of maxNumLines!");
            Assert.That(50, Is.EqualTo(test4.GetMaxNumLines()), "Did not set the correct number of maxNumLines!");
            Assert.That(101, Is.EqualTo(test5.GetMaxNumLines()), "Did not set the correct number of maxNumLines!");
        }
    }
}
