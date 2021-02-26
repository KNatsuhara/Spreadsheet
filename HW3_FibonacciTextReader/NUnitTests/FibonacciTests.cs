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

            Assert.That(0, Is.EqualTo(test1.GetMaxNumLines()), "Test1: Did not set the correct number of maxNumLines!");
            Assert.That(-5, Is.EqualTo(test2.GetMaxNumLines()), "Test2: Did not set the correct number of maxNumLines!");
            Assert.That(-10, Is.EqualTo(test3.GetMaxNumLines()), "Test3: Did not set the correct number of maxNumLines!");
            Assert.That(50, Is.EqualTo(test4.GetMaxNumLines()), "Test4: Did not set the correct number of maxNumLines!");
            Assert.That(101, Is.EqualTo(test5.GetMaxNumLines()), "Test5: Did not set the correct number of maxNumLines!");
        }

        /// <summary>
        /// This will test if the FibonacciTextReader class will return the correct number in the Fibonnaci sequence.
        /// </summary>
        [Test]
        public void TestReadToLine()
        {
            FibonacciTextReader test1 = new FibonacciTextReader(0);
            FibonacciTextReader test2 = new FibonacciTextReader(3);
            FibonacciTextReader test3 = new FibonacciTextReader(-3);

            Assert.That("0" + System.Environment.NewLine, Is.EqualTo(test1.ReadLine()), "Test1: Did not return the correct number in the Fibonacci Sequence!");
            Assert.That("0" + System.Environment.NewLine, Is.EqualTo(test2.ReadLine()), "Test2: Did not return the correct number in the Fibonacci Sequence!");
            Assert.That("0" + System.Environment.NewLine, Is.EqualTo(test3.ReadLine()), "Test3: Did not return the correct number in the Fibonacci Sequence!");
            Assert.That("1" + System.Environment.NewLine, Is.EqualTo(test2.ReadLine()), "Test2 (CL = 1): Did not return the correct number in the Fibonacci Sequence!");
            Assert.That("1" + System.Environment.NewLine, Is.EqualTo(test2.ReadLine()), "Test2 (CL = 2): Did not return the correct number in the Fibonacci Sequence!");
            Assert.That("2" + System.Environment.NewLine, Is.EqualTo(test2.ReadLine()), "Test2 (CL = 3): Did not return the correct number in the Fibonacci Sequence!");
        }

        /// <summary>
        /// This will check if the FibonacciTextReader correcly appends the numbers in the Fibonacci sequence.
        /// </summary>
        [Test]
        public void TestReadToEnd()
        {

        }
    }
}
