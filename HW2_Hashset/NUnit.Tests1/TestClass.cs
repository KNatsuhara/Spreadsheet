// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using static HW2_Hashset.FindDistinctElements;

namespace HW2_Hashset
{
    using NUnit.Framework;
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestFindDistinctHashSet()
        {
            List<int> numberList = new List<int>(); //There will be 11 distinct integers in this list.
            for (int i = 0; i < 10; i++)
            {
                numberList.Add(i);
            }
            numberList.Add(1);
            numberList.Add(2);
            numberList.Add(3);
            numberList.Add(4);
            numberList.Add(11);
            var answer = 11;
            //Assert.That(answer,FindDistinctHashSet(numberList), "Some useful error message");
            int guess = FindDistinctUsingHashSet(numberList);
            Assert.That(answer, Is.EqualTo(guess), "Did not find the correct number of distinct numbers");
        }
    }
}
