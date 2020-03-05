using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Parameters
{
    [TestClass]
    public class VariableArgumentsTests
    {
        [TestMethod]
        public void ShouldAdd()
        {
            var result = Add(1, 2, 3, 4, 5);
            Assert.AreEqual(15, result);
        }

        static int Add(params int[] numbers)
        {
            return numbers.Sum();
        }
    }
}