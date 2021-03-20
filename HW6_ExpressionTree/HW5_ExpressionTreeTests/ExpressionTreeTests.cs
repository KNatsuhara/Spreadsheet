﻿// <copyright file="ExpressionTreeTests.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using CptS321;
using NUnit.Framework;
using static CptS321.ExpressionTree;

namespace HW5_ExpressionTreeTests
{
    /// <summary>
    /// This class will be responsible for testing the ExpressionTree class.
    /// </summary>
    [TestFixture]
    public class ExpressionTreeTests
    {
        /// <summary>
        /// Tests the constructor and evaluate method of the ConstantNode class.
        /// </summary>
        [Test]
        public void TestConstantNode()
        {
            ConstantNode constant1 = new ConstantNode(0.0);
            ConstantNode constant2 = new ConstantNode(1.0000001);
            ConstantNode constant3 = new ConstantNode(double.MaxValue);
            ConstantNode constant4 = new ConstantNode(double.MinValue);
            Assert.That(0, Is.EqualTo(constant1.Evaluate()), "Failed on constant1");
            Assert.That(1.0000001, Is.EqualTo(constant2.Evaluate()), "Failed on constant2");
            Assert.That(double.MaxValue, Is.EqualTo(constant3.Evaluate()), "Failed on constant3");
            Assert.That(double.MinValue, Is.EqualTo(constant4.Evaluate()), "Failed on constant4");
        }

        /// <summary>
        /// Tests the constructor and evaluate method of the VariableNode class.
        /// </summary>
        [Test]
        public void TestVariableNode()
        {
            Dictionary<string, double> reference = new Dictionary<string, double>();

            VariableNode variable1 = new VariableNode("test1", ref reference);
            VariableNode variable2 = new VariableNode("test2", ref reference);
            VariableNode variable3 = new VariableNode("notFound", ref reference);
            VariableNode variable4 = new VariableNode("max", ref reference);
            VariableNode variable5 = new VariableNode("min", ref reference);

            // Confirming that the VariableNodes are using the Dictionary as a reference and not a value type.
            reference.Add("test1", 3.4);
            reference.Add("test2", -1.2);
            reference.Add("max", double.MaxValue);
            reference.Add("min", double.MinValue);

            Assert.That(3.4, Is.EqualTo(variable1.Evaluate()), "Failed on variable1");
            Assert.That(-1.2, Is.EqualTo(variable2.Evaluate()), "Failed on variable2");
            Assert.That(0, Is.EqualTo(variable3.Evaluate()), "Failed on variable3");
            Assert.That(double.MaxValue, Is.EqualTo(variable4.Evaluate()), "Failed on variable4");
            Assert.That(double.MinValue, Is.EqualTo(variable5.Evaluate()), "Failed on variable5");
        }

        /// <summary>
        /// Tests the get, set and evaluate methods in the PlusOperatorNode.
        /// </summary>
        [Test]
        public void TestPlusOperatorNode()
        {
            Dictionary<string, double> reference = new Dictionary<string, double>();
            VariableNode variable1 = new VariableNode("test1", ref reference);
            VariableNode variable2 = new VariableNode("test2", ref reference);
            ConstantNode constant1 = new ConstantNode(4);
            ConstantNode constant2 = new ConstantNode(1);
            reference.Add("test1", 3.4);
            reference.Add("test2", 5);
            PlusOperatorNode add1 = new PlusOperatorNode();
            add1.Left = variable1;
            add1.Right = variable2; // This should evaluate to 8.4
            PlusOperatorNode add2 = new PlusOperatorNode();
            add2.Left = variable1;
            add2.Right = constant1; // This should evaluate to 7.4
            PlusOperatorNode add3 = new PlusOperatorNode();
            add3.Left = constant2;
            add3.Right = variable2; // This should evaluate to 6
            PlusOperatorNode add4 = new PlusOperatorNode();
            Assert.That(8.4, Is.EqualTo(add1.Evaluate()), "Failed on add1");
            Assert.That(7.4, Is.EqualTo(add2.Evaluate()), "Failed on add2");
            Assert.That(6, Is.EqualTo(add3.Evaluate()), "Failed on add3");
            Assert.That(() => add4.Evaluate(), Throws.TypeOf<System.NullReferenceException>());
        }

        /// <summary>
        /// Tests the get, set and evaluate methods in the MinusOperatorNode.
        /// </summary>
        [Test]
        public void TestMinusOperatorNode()
        {
            Dictionary<string, double> reference = new Dictionary<string, double>();
            VariableNode variable1 = new VariableNode("test1", ref reference);
            VariableNode variable2 = new VariableNode("test2", ref reference);
            ConstantNode constant1 = new ConstantNode(4);
            ConstantNode constant2 = new ConstantNode(10);
            reference.Add("test1", 3.4);
            reference.Add("test2", 5);
            MinusOperatorNode sub1 = new MinusOperatorNode();
            sub1.Left = variable1;
            sub1.Right = variable2; // This should evaluate to -1.6
            MinusOperatorNode sub2 = new MinusOperatorNode();
            sub2.Left = variable1;
            sub2.Right = constant1; // This should evaluate to -0.6
            MinusOperatorNode sub3 = new MinusOperatorNode();
            sub3.Left = constant2;
            sub3.Right = variable2; // This should evaluate to 5
            MinusOperatorNode sub4 = new MinusOperatorNode();
            Assert.That(-1.6, Is.EqualTo(sub1.Evaluate()), "Failed on sub1");
            Assert.That(3.4 - 4, Is.EqualTo(sub2.Evaluate()), "Failed on sub2");
            Assert.That(5, Is.EqualTo(sub3.Evaluate()), "Failed on sub3");
            Assert.That(() => sub4.Evaluate(), Throws.TypeOf<System.NullReferenceException>());
        }

        /// <summary>
        /// Tests the get, set and evaluate methods in the DivideOperatorNode.
        /// </summary>
        [Test]
        public void TestDivideOperatorNode()
        {
            Dictionary<string, double> reference = new Dictionary<string, double>();
            VariableNode variable1 = new VariableNode("test1", ref reference);
            VariableNode variable2 = new VariableNode("test2", ref reference);
            ConstantNode constant1 = new ConstantNode(12);
            ConstantNode constant2 = new ConstantNode(10);
            reference.Add("test1", 3);
            reference.Add("test2", 5);
            DivideOperatorNode div1 = new DivideOperatorNode();
            div1.Left = variable1;
            div1.Right = variable2; // This should evaluate to 0.6
            DivideOperatorNode div2 = new DivideOperatorNode();
            div2.Left = variable1;
            div2.Right = constant1; // This should evaluate to 0.25
            DivideOperatorNode div3 = new DivideOperatorNode();
            div3.Left = constant2;
            div3.Right = variable2; // This should evaluate to 2
            DivideOperatorNode div4 = new DivideOperatorNode();
            Assert.That(0.6, Is.EqualTo(div1.Evaluate()), "Failed on div1");
            Assert.That(0.25, Is.EqualTo(div2.Evaluate()), "Failed on div2");
            Assert.That(2, Is.EqualTo(div3.Evaluate()), "Failed on div3");
            Assert.That(() => div4.Evaluate(), Throws.TypeOf<System.NullReferenceException>());
        }

        /// <summary>
        /// Tests the get, set and evaluate methods in the MultiplyOperatorNode.
        /// </summary>
        [Test]
        public void TestMultiplyOperatorNode()
        {
            Dictionary<string, double> reference = new Dictionary<string, double>();
            VariableNode variable1 = new VariableNode("test1", ref reference);
            VariableNode variable2 = new VariableNode("test2", ref reference);
            ConstantNode constant1 = new ConstantNode(12);
            ConstantNode constant2 = new ConstantNode(-2);
            reference.Add("test1", 3.5);
            reference.Add("test2", 5.1);
            MultiplyOperatorNode mul1 = new MultiplyOperatorNode();
            mul1.Left = variable1;
            mul1.Right = variable2; // This should evaluate to 17.85
            MultiplyOperatorNode mul2 = new MultiplyOperatorNode();
            mul2.Left = variable1;
            mul2.Right = constant1; // This should evaluate to 42
            MultiplyOperatorNode mul3 = new MultiplyOperatorNode();
            mul3.Left = constant2;
            mul3.Right = variable2; // This should evaluate to -10.2
            MultiplyOperatorNode mul4 = new MultiplyOperatorNode();
            Assert.That(3.5 * 5.1, Is.EqualTo(mul1.Evaluate()), "Failed on mul1");
            Assert.That(42, Is.EqualTo(mul2.Evaluate()), "Failed on mul2");
            Assert.That(-10.2, Is.EqualTo(mul3.Evaluate()), "Failed on mul3");
            Assert.That(() => mul4.Evaluate(), Throws.TypeOf<System.NullReferenceException>());
        }

        /// <summary>
        /// Will test the ExpressionToInfix method.
        /// </summary>
        [Test]
        public void TestExpressionToInfix()
        {
            ExpressionTree tree1 = new ExpressionTree("A1+B1");
            string expression1 = "(A1+B1)+C2+D2";
            string expression2 = "(4+2-(4-A))";
            string expression3 = "(Alpha+4)";
            string expression4 = "Bravo";
            string expression5 = string.Empty;
            List<string> infix1 = new List<string> { "(", "A1", "+", "B1", ")", "+", "C2", "+", "D2" };
            List<string> infix2 = new List<string> { "(", "4", "+", "2", "-", "(", "4", "-", "A", ")", ")" };
            List<string> infix3 = new List<string> { "(", "Alpha", "+", "4", ")" };
            List<string> infix4 = new List<string> { "Bravo" };
            List<string> infix5 = new List<string> { string.Empty };

            Assert.That(infix1, Is.EqualTo(tree1.ConvertExpressionToInfix(expression1)), "Failed on infix1");
            Assert.That(infix2, Is.EqualTo(tree1.ConvertExpressionToInfix(expression2)), "Failed on infix2");
            Assert.That(infix3, Is.EqualTo(tree1.ConvertExpressionToInfix(expression3)), "Failed on infix3");
            Assert.That(infix4, Is.EqualTo(tree1.ConvertExpressionToInfix(expression4)), "Failed on infix4");
            Assert.That(infix5, Is.EqualTo(tree1.ConvertExpressionToInfix(expression5)), "Failed on infix5");
        }

        /// <summary>
        /// Will test the InfixToPostfix method.
        /// </summary>
        [Test]
        public void TestInfixToPostfix()
        {
            ExpressionTree tree1 = new ExpressionTree("A1+B1");
            List<string> infix1 = new List<string> { "(", "A", "+", "B", ")", "+", "C", "+", "D" };
            List<string> infix2 = new List<string> { "4", "+", "2", "-", "(", "4", "-", "A", ")" };
            List<string> infix3 = new List<string> { "(", "A", "+", "4", ")" };
            List<string> infix4 = new List<string> { "(", "A", ")" };
            List<string> infix5 = new List<string> { "A", "+", "B", "*", "C", "/", "(", "E", "-", "F", ")" };
            List<string> infix6 = new List<string> { "(", "A", "+", "B", ")", "*", "(", "C", "/", "(", "E", "-", "F", ")", ")" };
            List<string> infix7 = new List<string> { "7", "*", "(", "8", "*", "4", ")", "/", "(", "1", "-", "2", "-", "34", ")" };
            List<string> postfix1 = new List<string> { "A", "B", "+", "C", "+", "D", "+" };
            List<string> postfix2 = new List<string> { "4", "2", "+", "4", "A", "-", "-" };
            List<string> postfix3 = new List<string> { "A", "4", "+" };
            List<string> postfix4 = new List<string> { "A" };
            List<string> postfix5 = new List<string> { "A", "B", "C", "*", "E", "F", "-", "/", "+" };
            List<string> postfix6 = new List<string> { "A", "B", "+", "C", "E", "F", "-", "/", "*" };
            List<string> postfix7 = new List<string> { "7", "8", "4", "*", "*", "1", "2", "-", "34", "-", "/" };

            Assert.That(postfix1, Is.EqualTo(tree1.ConvertInfixToPostfix(infix1)), "Failed on postfix1");
            Assert.That(postfix2, Is.EqualTo(tree1.ConvertInfixToPostfix(infix2)), "Failed on postfix2");
            Assert.That(postfix3, Is.EqualTo(tree1.ConvertInfixToPostfix(infix3)), "Failed on postfix3");
            Assert.That(postfix4, Is.EqualTo(tree1.ConvertInfixToPostfix(infix4)), "Failed on postfix4");
            Assert.That(postfix5, Is.EqualTo(tree1.ConvertInfixToPostfix(infix5)), "Failed on postfix5");
            Assert.That(postfix6, Is.EqualTo(tree1.ConvertInfixToPostfix(infix6)), "Failed on postfix6");
            Assert.That(postfix7, Is.EqualTo(tree1.ConvertInfixToPostfix(infix7)), "Failed on postfix7");
        }

        /// <summary>
        /// Will test the IsOperator method.
        /// </summary>
        [Test]
        public void TestIsOperator()
        {
            ExpressionTree tree1 = new ExpressionTree("A1+B1");
            string op1 = "+";
            string op2 = "-";
            string op3 = "*";
            string op4 = "/";
            string op5 = "1";
            string op6 = string.Empty;

            Assert.That(true, Is.EqualTo(tree1.IsOperator(op1)), "Failed at op1");
            Assert.That(true, Is.EqualTo(tree1.IsOperator(op2)), "Failed at op2");
            Assert.That(true, Is.EqualTo(tree1.IsOperator(op3)), "Failed at op3");
            Assert.That(true, Is.EqualTo(tree1.IsOperator(op4)), "Failed at op4");
            Assert.That(false, Is.EqualTo(tree1.IsOperator(op5)), "Failed at op5");
            Assert.That(() => tree1.IsOperator(op6), Throws.TypeOf<System.IndexOutOfRangeException>());
        }

        /// <summary>
        /// Will test the IsVariable method.
        /// </summary>
        [Test]
        public void TestIsVariable()
        {
            string var1 = "A1";
            string var2 = "B1";
            string var3 = "World";
            string var4 = "Z";
            string var5 = "abcde";
            string var6 = "z";
            string var7 = string.Empty;
            string var8 = "@";
            string var9 = "[";
            string var10 = "`";
            string var11 = "{";

            Assert.That(true, Is.EqualTo(IsVariable(var1)), "Failed at var1");
            Assert.That(true, Is.EqualTo(IsVariable(var2)), "Failed at var2");
            Assert.That(true, Is.EqualTo(IsVariable(var3)), "Failed at var3");
            Assert.That(true, Is.EqualTo(IsVariable(var4)), "Failed at var4");
            Assert.That(true, Is.EqualTo(IsVariable(var5)), "Failed at var5");
            Assert.That(true, Is.EqualTo(IsVariable(var6)), "Failed at var6");
            Assert.That(false, Is.EqualTo(IsVariable(var7)), "Failed at var7");
            Assert.That(false, Is.EqualTo(IsVariable(var8)), "Failed at var8");
            Assert.That(false, Is.EqualTo(IsVariable(var9)), "Failed at var9");
            Assert.That(false, Is.EqualTo(IsVariable(var10)), "Failed at var10");
            Assert.That(false, Is.EqualTo(IsVariable(var11)), "Failed at var11");
        }

        /// <summary>
        /// Will test the IsHigherPrecedence method.
        /// </summary>
        [Test]
        public void TestIsHigherPrecedence()
        {
            ExpressionTree test1 = new ExpressionTree("A1+B1");
            Assert.That(true, Is.EqualTo(test1.IsHigherPrecedence("*", "+")), "Failed at * and +");
            Assert.That(false, Is.EqualTo(test1.IsHigherPrecedence("+", "+")), "Failed at + and +");
            Assert.That(false, Is.EqualTo(test1.IsHigherPrecedence("-", "*")), "Failed at - and *");
            Assert.That(true, Is.EqualTo(test1.IsHigherPrecedence("/", "-")), "Failed at / and -");
            Assert.That(true, Is.EqualTo(test1.IsHigherPrecedence("/", "+")), "Failed at / and +");
        }

        /// <summary>
        /// Will test the IsLowerPrecedence method.
        /// </summary>
        [Test]
        public void TestIsLowerPrecedence()
        {
            ExpressionTree test1 = new ExpressionTree("A1+B1");
            Assert.That(false, Is.EqualTo(test1.IsLowerPrecedence("*", "+")), "Failed at * and +");
            Assert.That(false, Is.EqualTo(test1.IsLowerPrecedence("+", "+")), "Failed at + and +");
            Assert.That(true, Is.EqualTo(test1.IsLowerPrecedence("-", "*")), "Failed at - and *");
            Assert.That(false, Is.EqualTo(test1.IsLowerPrecedence("/", "-")), "Failed at / and -");
            Assert.That(false, Is.EqualTo(test1.IsLowerPrecedence("/", "+")), "Failed at / and +");
        }

        /// <summary>
        /// Will test the IsSamePrecedence method.
        /// </summary>
        [Test]
        public void TestIsSamePrecedence()
        {
            ExpressionTree test1 = new ExpressionTree("A1+B1");
            Assert.That(false, Is.EqualTo(test1.IsSamePrecedence("*", "+")), "Failed at * and +");
            Assert.That(true, Is.EqualTo(test1.IsSamePrecedence("+", "+")), "Failed at + and +");
            Assert.That(false, Is.EqualTo(test1.IsSamePrecedence("-", "*")), "Failed at - and *");
            Assert.That(false, Is.EqualTo(test1.IsSamePrecedence("/", "-")), "Failed at / and -");
            Assert.That(true, Is.EqualTo(test1.IsSamePrecedence("/", "/")), "Failed at / and +");
            Assert.That(true, Is.EqualTo(test1.IsSamePrecedence("-", "-")), "Failed at - and -");
            Assert.That(true, Is.EqualTo(test1.IsSamePrecedence("*", "*")), "Failed at * and *");
        }

        /// <summary>
        /// Will test the IsRightAssociative method.
        /// </summary>
        [Test]
        public void TestIsRightAssociative()
        {
            ExpressionTree test1 = new ExpressionTree("A1+B1");
            Assert.That(false, Is.EqualTo(test1.IsRightAssociative("+")), "Failed at +");
            Assert.That(false, Is.EqualTo(test1.IsRightAssociative("-")), "Failed at -");
            Assert.That(false, Is.EqualTo(test1.IsRightAssociative("*")), "Failed at *");
            Assert.That(false, Is.EqualTo(test1.IsRightAssociative("/")), "Failed at /");
        }

        /// <summary>
        /// Will test the IsLeftAssociative method.
        /// </summary>
        [Test]
        public void TestIsLeftAssociative()
        {
            ExpressionTree test1 = new ExpressionTree("A1+B1");
            Assert.That(true, Is.EqualTo(test1.IsLeftAssociative("+")), "Failed at +");
            Assert.That(true, Is.EqualTo(test1.IsLeftAssociative("-")), "Failed at -");
            Assert.That(true, Is.EqualTo(test1.IsLeftAssociative("*")), "Failed at *");
            Assert.That(true, Is.EqualTo(test1.IsLeftAssociative("/")), "Failed at /");
        }

        /// <summary>
        /// Will test the creation of the tree and evaluation of the tree.
        /// </summary>
        [Test]
        public void TestEvaluateTree()
        {
            string expression1 = "A1+B1+12+12";
            ExpressionTree test1 = new ExpressionTree(expression1);
            test1.CreateExpressionTree(expression1);
            Assert.That(24, Is.EqualTo(test1.Evaluate()), "Failed at test1 (24)");
            test1.SetVariable("A1", 12);
            Assert.That(36, Is.EqualTo(test1.Evaluate()), "Failed at test1 (36)");
            test1.SetVariable("B1", 12);
            Assert.That(48, Is.EqualTo(test1.Evaluate()), "Failed at test1 (48)");
            string expression2 = "World-7+8+8";
            ExpressionTree test2 = new ExpressionTree(expression2);
            test2.CreateExpressionTree(expression2);
            Assert.That(9, Is.EqualTo(test2.Evaluate()), "Failed at test2 (9)");
            test2.SetVariable("World", 12);
            Assert.That(21, Is.EqualTo(test2.Evaluate()), "Failed at test2 (21)");
            string expression3 = "7*(8*4)/(1-2-34)";
            ExpressionTree test3 = new ExpressionTree(expression3);
            test3.CreateExpressionTree(expression3);
            Assert.That(-6.4, Is.EqualTo(test3.Evaluate()), "Failed at test3 (-6.4)");
        }
    }
}
