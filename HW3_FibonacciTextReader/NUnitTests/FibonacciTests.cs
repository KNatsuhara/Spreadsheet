// <copyright file="FibonacciTests.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

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
        /// Basic Test method sample.
        /// </summary>
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }
    }
}
