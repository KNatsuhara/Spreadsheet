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
            int hashResult = 0, storageResult = 0, sortResult = 0, temp = 0;
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Form1 textForm = new Form1(); // Creating Form1 object called textForm.
            var rand = new System.Random(); // Instantiate random number generator.
            System.Collections.Generic.List<int> randomList = new System.Collections.Generic.List<int>(); // Creates an empty generic list.
            for (int i = 0; i < 10000; i++)
            {
                temp = rand.Next(0, 20001); // Creating random integers from 0 to 20,000.
                randomList.Add(temp); // Adding random integers to randomList.
            }

            hashResult = FindDistinctUsingHashSet(randomList); // Sets hashResult using Hash Method.
            storageResult = FindDistinctLimitStorage(randomList); // Sets storageResult using Storage Method.
            sortResult = FindDistinctUsingSort(randomList); // Sets sortResult using Sorted Method.
            PrintToForm(hashResult, storageResult, sortResult, textForm); // Outputs all method results to form application.

            System.Windows.Forms.Application.Run(textForm); // Runs updated textForm.
        }

        /// <summary>
        /// Will print out 3 lines of text to the form application that on how many distinct numbers there are in the list.
        /// </summary>
        /// <param name="hashResult">Distinct numbers in throught the hash method.</param>
        /// <param name="storageResult">Distinct numbers in throught the storage method.</param>
        /// <param name="sortResult">Distinct numbers in throught the sorted method.</param>
        /// <param name="textForm">Name of the form1 object.</param>
        public static void PrintToForm(int hashResult, int storageResult, int sortResult, Form1 textForm)
        {
            string hashSetResult = "1. HashSet method: " + hashResult + " unique numbers.";
            string limitStorageResult = "2. O(1) storage method: " + storageResult + " unique numbers.";
            string sortListResult = "3. Sorted method: " + sortResult + " unique numbers.";
            textForm.PrintResults(hashSetResult); // Prints finished result to textBoxResult in textForm.
            textForm.PrintResults(limitStorageResult); // Prints finished result to textBoxResult in textForm.
            textForm.PrintResults(sortListResult); // Prints finished result to textBoxResult in textForm.
        }
    }
}
