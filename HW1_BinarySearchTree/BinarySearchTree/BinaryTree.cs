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
    }
}
