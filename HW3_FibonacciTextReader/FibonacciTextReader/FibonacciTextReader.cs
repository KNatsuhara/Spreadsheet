// <copyright file="FibonacciTextReader.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciTextReader
{
    /// <summary>
    /// This class will inherit System.IO.TextReader and create the Fibonacci Sequence.
    /// </summary>
    public class FibonacciTextReader : System.IO.TextReader
    {
        /// <summary>
        /// Integer that holds how many sequence of Fibonacci the class will output.
        /// </summary>
        private int maxNumLines;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="maxNumLines">The maxNumLines that the fibonacci sequence will produce.</param>
        public FibonacciTextReader(int maxNumLines)
        {
            this.maxNumLines = maxNumLines;
        }
    }
}
