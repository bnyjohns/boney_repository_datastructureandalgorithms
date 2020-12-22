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
    public class NumberOfEditsToConvertStringAToBTests
    {
        [TestMethod]
        public void Test()
        {
            var a = NumberOfEditsToConvertStringAToB.GetMinimumNumberOfEdits("ab", "cd");
        }
    }
}
