using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.PrimitveRefAndValTypes
{
    [TestClass]
    public class DynamicPrimitveTypeTests
    {
        [TestMethod]
        public void ShouldAddDynamicTypes()
        {
            dynamic value;

            value = 5;
            M(value + value);

            value = "Albert";
            M(value + " Cervantes");
        }

        private static void M(int n)
        {
            Assert.AreEqual(typeof(int), n.GetType());
        }

        private static void M(string s)
        {
            Assert.AreEqual(typeof(string), s.GetType());
        }

        [TestMethod]
        public void TestSquare()
        {
            var mathOp = new MathOp<Object>();
            var result = mathOp.Square(5);
            Assert.AreEqual(25, result);
        }
    }

    class MathOp <T>
    {
        public T Square(dynamic n)
        {
            var result = n * n;
            return result;
        }
    }
    
}