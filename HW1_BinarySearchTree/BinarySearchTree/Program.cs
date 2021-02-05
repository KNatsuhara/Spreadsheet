// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
            binaryTree.PrintInOrder(binaryTree.Root);
            System.Console.WriteLine("\nNumber of items in the tree: " + binaryTree.GetCount());
            System.Console.WriteLine("Level of Tree: " + binaryTree.GetTreeLevel());
            System.Console.WriteLine("Theoretical Level of Tree: " + binaryTree.GetTheoreticalLevel());
        }

        /// <summary>
        /// Will ask the user to input a string with spaced integers (1-100).
        /// </summary>
        /// <returns>Returns a string with integers.</returns>
        public static string GetStringFromUser()
        {
            System.Console.WriteLine("Input a list of integers (1-100)");
            string integerList = System.Console.ReadLine();
            return integerList;
        }
    }
}
