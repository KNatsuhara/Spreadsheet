// <copyright file="Program.cs" company="Koji Natsuhara">
// Copyright (c) Koji Natsuhara. All rights reserved.
// </copyright>

namespace BinarySearchTree
{
    /// <summary>
    /// This program will ask the user to input a string with spaced
    /// out integers and create a binary search tree with those integers.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Will ask the user to input a string with integers.
        /// Creates a binary search tree and output the height
        /// and theoretical height of the tree.
        /// </summary>
        /// <param name="args">args.</param>
        public static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            string integerList = GetStringFromUser();
            binaryTree.InsertIntegerList(integerList);
            System.Console.Write("Tree Contents: ");
            binaryTree.PrintInOrder(binaryTree.Root);
            binaryTree.PrintTreeStatistics();
            System.Console.WriteLine("Done");
        }

        /// <summary>
        /// Will ask the user to input a string with spaced integers (1-100).
        /// </summary>
        /// <returns>Returns a string with integers.</returns>
        public static string GetStringFromUser()
        {
            System.Console.WriteLine("Enter a collection of numbers in the range [0, 100], separated by spaces:");
            string integerList = System.Console.ReadLine();
            return integerList;
        }
    }
}
