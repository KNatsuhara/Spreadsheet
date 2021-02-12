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
        /// <param name="list">Accepts random list of integers.</param>
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

        /// <summary>
        /// Returns the number of distinct numbers in a list while keeping the storage complexity O(1).
        /// </summary>
        /// <param name="list">Accepts random list of integers.</param>
        /// <returns>The int containing the total number of distinct integers in the list.</returns>
        public static int FindDistinctLimitStorage(System.Collections.Generic.List<int> list)
        {
            int totalDistinct = 0;
            bool isDistinct = true;

            for (int i = 0; i < list.Count; i++)
            {
                isDistinct = true; // Resets isDistinct value to true.
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        isDistinct = false;
                        break; // The element is not distinct, and isDistinct to False.
                    }
                }

                if (isDistinct)
                {
                    totalDistinct++; // The element is distinct and we increment totalDistinct count;
                }
            }

            return totalDistinct;
        }

        /// <summary>
        /// Returns the number of distinct numbers in the list by sorting the list before hand in O(n) time complexity.
        /// </summary>
        /// <param name="list">Accepts random list of integers.</param>
        /// <returns>Returns the total number of distinct elements in the list.</returns>
        public static int FindDistinctUsingSort(System.Collections.Generic.List<int> list)
        {
            if (list.Count == 0)
            {
                return 0;
            }

            int totalDistinct = 1;
            list.Sort(); // Sorting the list.
            int currentElement = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (currentElement != list[i])
                {
                    totalDistinct++;
                    currentElement = list[i];
                }
            }

            return totalDistinct;
        }
    }
}
