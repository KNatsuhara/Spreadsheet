// <copyright file="FibonacciTextReader.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HW3_FibonacciTextReader
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
        /// Integer that holds what current line index the Fibonacci Class is at.
        /// </summary>
        private int currentNumLine = 1;

        /// <summary>
        /// The previous number in the Fibonacci sequence.
        /// </summary>
        private BigInteger position0 = 0;

        /// <summary>
        /// The current number in the Fibonacci sequence.
        /// </summary>
        private BigInteger position1 = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="maxNumLines">The maxNumLines that the fibonacci sequence will produce.</param>
        public FibonacciTextReader(int maxNumLines)
        {
            if (maxNumLines < 0)
            {
                this.maxNumLines = 0; // If maxNumLines is negative, maxNumLines will be automatically set to 0;
            }

            this.maxNumLines = maxNumLines;
        }

        /// <summary>
        /// This function for returning the maxNumLines in this class object. FOR TESTING PURPOSES.
        /// </summary>
        /// <returns>maxNumLines.</returns>
        public int GetMaxNumLines()
        {
            return this.maxNumLines;
        }

        /// <summary>
        /// This function will return the next number in the Fibonacci Sequence based on what current line number the class is
        /// set at.
        /// </summary>
        /// <returns>The next number in the Fibonacci Sequence as a string.</returns>
        public override string ReadLine()
        {
            if (this.currentNumLine == 1)
            {
                this.currentNumLine++; // Increment the next line in the fibonacci sequence.
                return "0" + System.Environment.NewLine;
            }

            if (this.currentNumLine == 2)
            {
                this.currentNumLine++; // Increment the next line in the fibonacci sequence.
                return "1" + System.Environment.NewLine;
            }

            BigInteger temp = this.position0;
            this.position0 = this.position1;
            this.position1 = this.position1 + temp;
            this.currentNumLine++; // Increment the next line in the fibonacci sequence.
            return this.position1.ToString() + System.Environment.NewLine;
        }

        /// <summary>
        /// This function will ReadLine() repeatedly to append all the strings in the fibonacci sequence to one string.
        /// </summary>
        /// <returns>A single string containing the fibonacci sequence up to maxNumLines.</returns>
        public override string ReadToEnd()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.maxNumLines; i++)
            {
                sb.Append(this.currentNumLine.ToString() + ": " );
                sb.Append(this.ReadLine());
            }

            return sb.ToString(); // Returns fully appeneded string.
        }
    }
}
