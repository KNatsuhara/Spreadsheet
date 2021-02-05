// <copyright file="BinaryTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace BinarySearchTree
{
    /// <summary>
    /// Will create a root node and attaching nodes based
    /// on whether or not the appending node is less than or greater.
    /// This tree will not accept duplicates.
    /// </summary>
    public class BinaryTree
    {
        private int count = 0;

        /// <summary>
        /// Gets or Sets the root Node.
        /// </summary>
        public Node Root { get; set; }

        /// <summary>
        /// Will create a Node and check if the node value already exists
        /// and if not, then it will insert the node left or right in the tree.
        /// </summary>
        /// <param name="value">Value of the node that will be inserted.</param>
        public void Insert(int value)
        {
            Node current = this.Root;
            Node next = null;

            while (current != null)
            {
                next = current;
                if (value < current.Data)
                {
                    current = current.LeftNode;
                }
                else if (value > current.Data)
                {
                    current = current.RightNode;
                }
                else
                {
                    System.Console.WriteLine(value + " already exists in the tree!");
                    return;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;
            this.count++;

            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                if (value < next.Data)
                {
                    next.LeftNode = newNode;
                }
                else
                {
                    next.RightNode = newNode;
                }
            }
        }

        /// <summary>
        /// Takes in a string with spaced out integers and inserts them into the tree.
        /// </summary>
        /// <param name="list">String of spaced out integers.</param>
        public void InsertIntegerList(string list)
        {
            string[] numList = list.Split(' ');
            foreach (var num in numList)
            {
                int result = int.Parse(num);
                this.Insert(result);
            }
        }

        /// <summary>
        /// Prints out the entire Binary Search Tree from least to greatest.
        /// </summary>
        /// <param name="current">Accepts the root of the tree.</param>
        public void PrintInOrder(Node current)
        {
            if (current != null)
            {
                this.PrintInOrder(current.LeftNode);
                System.Console.Write(current.Data + " ");
                this.PrintInOrder(current.RightNode);
            }
        }

        /// <summary>
        /// Returns the number of items in the tree.
        /// </summary>
        /// <returns>Count variable.</returns>
        public int GetCount()
        {
            return this.count;
        }

        /// <summary>
        /// Returns the number of levels in the tree.
        /// </summary>
        /// <returns>Number of levels in the tree.</returns>
        public int GetTreeLevel()
        {
            return this.GetTreeLevel(this.Root);
        }

        /// <summary>
        /// Returns the theoretical level of the tree.
        /// </summary>
        /// <returns>Integer of the theoretical level of the tree.</returns>
        public int GetTheoreticalLevel()
        {
            double tempCount = System.Math.Log2(this.count);
            return (int)tempCount + 1;
        }

        /// <summary>
        /// Prints out the number of nodes in tree, number of levels, and minimum number of levels the tree could have.
        /// </summary>
        public void PrintTreeStatistics()
        {
            System.Console.WriteLine("\nTree statistics:\n\tNumber of nodes: " + this.GetCount());
            System.Console.WriteLine("\tNumber of levels: " + this.GetTreeLevel());
            System.Console.WriteLine("\tMinimum number of levels that a tree with " + this.GetCount() + " nodes could have = " + this.GetTheoreticalLevel());
        }

        /// <summary>
        /// Helper function to calculate the number of levels in the tree.
        /// </summary>
        /// <param name="current">Current Node.</param>
        /// <returns>Number of levels in tree.</returns>
        private int GetTreeLevel(Node current)
        {
            if (current == null)
            {
                return 0;
            }
            else
            {
                return System.Math.Max(this.GetTreeLevel(current.LeftNode), this.GetTreeLevel(current.RightNode)) + 1;
            }
        }
    }
}
