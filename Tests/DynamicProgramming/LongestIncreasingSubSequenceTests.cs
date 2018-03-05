using Algorithms.DynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DynamicProgramming
{
    [TestClass]
    public class LongestIncreasingSubSequenceTests
    {
        [TestMethod]
        public void Test1()
        {
            var result = LongestIncreasingSubSequence.GetResult(new int[] { 1, 8, 3, 2, 5 });
            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 3, 5 }, result);

        }

        [TestMethod]
        public void Test2()
        {            
            var result = LongestIncreasingSubSequence.GetResult(new int[] { 4, 0, 3, 2, 3 });
            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new List<int> { 0, 2, 3 }, result);
        }

        [TestMethod]
        public void Test3()
        {
            var result = LongestIncreasingSubSequence.GetResult(new int[] { 3, 10, 2, 1, 20 });            
            CollectionAssert.AreEqual(new List<int> { 3, 10, 20 }, result);
        }

        [TestMethod]
        public void Test4()
        {
            var result = LongestIncreasingSubSequence.GetResult(new int[] { 3, 2 });
            CollectionAssert.AreEqual(new List<int> { 3 }, result);
        }

        [TestMethod]
        public void Test5()
        {
            var result = LongestIncreasingSubSequence.GetResult(new int[] { 50, 3, 10, 7, 40, 80 });
            CollectionAssert.AreEqual(new List<int> { 3, 10, 40, 80 }, result);
        }
    }
}
