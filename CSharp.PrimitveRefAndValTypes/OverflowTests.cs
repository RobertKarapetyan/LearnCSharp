using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.PrimitveRefAndValTypes
{
    [TestClass]
    public class OverflowTests
    {
        [TestMethod]
        public void ShouldOverflowSilently()
        {
            Byte b = 100;
            b = (Byte) (b + 200);
            Assert.AreEqual(44, b);
        }

        [TestMethod]
        public void ShouldNotOverflowSilently()
        {
            Byte b = 100;

            Assert.ThrowsException<OverflowException>(() =>
            {
                b = checked((Byte) (b + 200));
            });
        }
    }
}