using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Methods
{
    [TestClass]
    public class SomeTypeTests
    {
        [TestMethod]
        public void ShouldInitialize()
        {
            var someType = new SomeType(1);
            Assert.AreEqual(1, someType.B);
            Assert.AreEqual(11, someType.A);
            Assert.IsNull(someType.C);
            Assert.AreEqual(0, someType.D);
        }
    }
    
    internal sealed class SomeType {
        public int A = 11;
        public byte B;
        public string C;
        public int D;

        public SomeType() {}
        
        public SomeType(byte b)
        {
            B = b;
        }
        public SomeType(int a, byte mB) : this (mB)
        {
            A = a;
        }
        public SomeType(int a, byte mB, string c) : this(a, mB)
        {
            C = c;
        }
    }
}