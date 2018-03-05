using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DynamicProgramming;

namespace Tests.DynamicProgramming
{
    [TestClass]
    public class MaxSumOfSubSetTests
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(2, MaxSumOfSubSet.GetResult(new int[] { -2, 1, 1 }));
            Assert.AreEqual(-2, MaxSumOfSubSet.GetResult(new int[] { -2, -3, -4 }));
            Assert.AreEqual(6, MaxSumOfSubSet.GetResult(new int[] { 1, 2, 3 }));
            Assert.AreEqual(2, MaxSumOfSubSet.GetResult(new int[] { 1, 0, 1 }));
        }
    }
}
