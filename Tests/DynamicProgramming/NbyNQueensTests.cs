using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.DynamicProgramming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DynamicProgramming
{
    [TestClass]
    public class NbyNQueensTests
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(true, NbyNQueens.PositionQueens(4));
            Assert.AreEqual(false, NbyNQueens.PositionQueens(3));
        }
    }
}
