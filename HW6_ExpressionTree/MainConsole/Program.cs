// <copyright file="Program.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using CptS321;

namespace MainConsole
{
    /// <summary>
    /// This program will run application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">args.</param>
        public static void Main(string[] args)
        {
            RunApplication();
        }

        /// <summary>
        /// This will print out the main menu along with the existing expression the user has inputted.
        /// </summary>
        /// <param name="expression">Previous expression.</param>
        public static void PrintMainMenu(string expression)
        {
            System.Console.WriteLine("Menu (current expression = \"" + expression + "\")");
            System.Console.WriteLine("\t1 = Enter a new expression");
            System.Console.WriteLine("\t2 = Set a variable value");
            System.Console.WriteLine("\t3 = Evaluate tree");
            System.Console.WriteLine("\t4 = Quit");
        }

        /// <summary>
        /// This method will ask the user to input an integer between 1 and 4.
        /// </summary>
        /// <returns>A number between 1 and 4.</returns>
        public static int GetOptionForMainMenu()
        {
            int option = 0;
            do
            {
                System.Console.Write("Enter your option: ");
                option = System.Convert.ToInt32(System.Console.ReadLine());
            }
            while (option > 4 || option < 1);
            return option;
        }

        /// <summary>
        /// This will print out the main menu and ask the user to input an expression and evaluate the expression
        /// using the ExpressionTree class.
        /// </summary>
        public static void RunApplication()
        {
            int option = 0, exit = -1;
            string expression = "A1-12-C1"; // Default expression
            string name = string.Empty;
            double value = 0;
            ExpressionTree expTree = new ExpressionTree(expression); // Create main expression tree class
            expTree.CreateExpressionTree(expression); // Create expression tree from default expression

            while (exit == -1)
            {
                PrintMainMenu(expression); // Print main menu
                option = GetOptionForMainMenu(); // Get option for main menu

                switch (option)
                {
                    case 1:
                        System.Console.Write("Enter a new expression: ");
                        expression = System.Console.ReadLine();
                        expTree.CreateExpressionTree(expression); // Build a tree from new expression, this will clear the variables dictionary
                        break;
                    case 2:
                        System.Console.Write("Enter variable name: ");
                        name = System.Console.ReadLine(); // Get variable name
                        System.Console.Write("Enter variable value: ");
                        value = Convert.ToDouble(System.Console.ReadLine()); // Get variable value
                        expTree.SetVariable(name, value); // Set variable in the dictionary for the expression tree
                        break;
                    case 3:
                        System.Console.Write("Evaluation of Tree: ");
                        System.Console.WriteLine(expTree.Evaluate()); // Evaluates the expression tree
                        break;
                    case 4:
                        System.Console.WriteLine("Quit.");
                        exit = 1; // Leaves loop and ends application
                        break;
                }
            }
        }
    }
}