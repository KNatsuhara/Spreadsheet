// <copyright file="Program.cs" company="Koji Natsuhara">
// Copyright (c) Koji Natsuhara. All rights reserved.
// </copyright>
using static HW2_Hashset.FindDistinctElements;

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

            temp = FindDistinctUsingHashSet(randomList);
            string hashSetResult = "HashSet Method: " + temp + " unique numbers.";
            temp = FindDistinctLimitStorage(randomList);
            string limitStorageResult = "O(1) storage complexity Method: " + temp + " unique numbers.";
            textForm.PrintResults(hashSetResult); // Prints finished result to textBoxResult in textForm.
            textForm.PrintResults(limitStorageResult); // Prints finished result to textBoxResult in textForm.
            System.Windows.Forms.Application.Run(textForm); // Runs updated textForm.

        }
    }
}
