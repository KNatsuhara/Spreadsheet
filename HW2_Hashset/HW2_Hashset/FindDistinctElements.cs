// <copyright file="FindDistinctElements.cs" company="Koji Natsuhara">
// Copyright (c) Koji Natsuhara. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_Hashset
{
    /// <summary>
    /// This class will find the total number of distinct elements in a list in 3 different ways.
    /// </summary>
    public class FindDistinctElements
    {
        /// <summary>
        /// Returns the number of distinct numbers in the list using a Hash Set.
        /// </summary>
        /// <param name="list">Reads through the random list of integers.</param>
        /// <returns>The total distinct numbers in the list.</returns>
        public static int FindDistinctUsingHashSet(System.Collections.Generic.List<int> list)
        {
            System.Collections.Generic.HashSet<int> intHashSet = new System.Collections.Generic.HashSet<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (!intHashSet.Contains(list[i]))
                {
                    intHashSet.Add(list[i]); // If the value is distinct in the hash set, then add that element to the set.
                }
            }

            return intHashSet.Count; // Returns size of the distinct integer hash set.
        }
    }
}
