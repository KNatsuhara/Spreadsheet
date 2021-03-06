// <copyright file="TestClass.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnit.Tests1
{
    /// <summary>
    /// This class will test functions in a class.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        /// <summary>
        /// Temporary test method.
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
