// <copyright file="Program.cs" company="Koji Natsuhara">
// Copyright (c) Koji Natsuhara. All rights reserved.
// </copyright>

namespace HW2_Hashset
{
    /// <summary>
    /// This program will run the main method.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        public static void Main()
        {
            int temp = 0;
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Form1 textForm = new Form1(); // Creating Form1 object called textForm.
            var rand = new System.Random(); // Instantiate random number generator.
            System.Collections.Generic.List<int> randomList = new System.Collections.Generic.List<int>(); // Creates an empty generic list.
            for (int i = 0; i < 10; i++)
            {
                temp = rand.Next(0, 10); // Creating random integers from 0 to 20,000.
                randomList.Add(temp); // Adding random integers to randomList.
                textForm.PrintResults(temp.ToString());
            }

            temp = FindDistinctHashSet(randomList);
            string hashSetResult = "HashSet Method: " + temp + " unique numbers.";
            textForm.PrintResults(hashSetResult); // Prints finished result to textBoxResult in textForm.


            System.Windows.Forms.Application.Run(textForm); // Runs updated textForm.
        }

        /// <summary>
        /// Returns the number of distinct numbers in the list using a Hash Set.
        /// </summary>
        /// <param name="list">Reads through the random list of integers.</param>
        /// <returns>The total distinct numbers in the list.</returns>
        private static int FindDistinctHashSet(System.Collections.Generic.List<int> list)
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
