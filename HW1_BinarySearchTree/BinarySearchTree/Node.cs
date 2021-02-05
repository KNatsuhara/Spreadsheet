// <copyright file="Node.cs" company="Koji Natsuhara">
// Copyright (c) Koji Natsuhara. All rights reserved.
// </copyright>

namespace BinarySearchTree
{
    /// <summary>
    /// Creates a Node that holds an integer variable type
    /// and can contain two other nodes.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets or Sets the left node.
        /// </summary>
        public Node LeftNode { get; set; }

        /// <summary>
        /// Gets or Sets the right node.
        /// </summary>
        public Node RightNode { get; set; }

        /// <summary>
        /// Gets or Sets the Data in the node.
        /// </summary>
        public int Data { get; set; } // Node holds data of integer data type
    }
}
