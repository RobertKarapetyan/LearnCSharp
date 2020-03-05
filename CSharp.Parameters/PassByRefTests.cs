using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Parameters
{
    [TestClass]
    public class PassByRefTests
    {
        [TestMethod]
        public void ShouldPassIntByRef()
        {
            var number = 10;
            AddVal(ref number);
            Assert.AreEqual(20, number);
        }

        [TestMethod]
        public void ShouldPassIntByOut()
        {
            var number = 5;
            GetVal(out number);
            Assert.AreEqual(10, number);
        }

        [TestMethod]
        public void ShouldCreateNewValue()
        {
            GetVal(out var number);
            Assert.AreEqual(10, number);
        }

        private static void GetVal(out int v) {
            v = 10; 
        }
        
        private static void AddVal(ref int v)
        {
            if (v <= 0) throw new ArgumentOutOfRangeException(nameof(v));
            v += 10;
        }
    }
}