using CSharp.PrimitveRefAndValTypes.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.PrimitveRefAndValTypes
{
    [TestClass]
    public class HashCodesTests
    {
        [TestMethod]
        public void ShouldHaveTheSameHashCodes()
        {
            var ref1 = new SomeRef();
            var ref2 = ref1;
            
            Assert.AreEqual(ref1.GetHashCode(), ref2.GetHashCode());
        }

        [TestMethod]
        public void ShouldNotHaveTheSameHashCodes()
        {
            var ref1 = new SomeRef();
            var ref2 = new SomeRef();
            
            Assert.AreNotEqual(ref1.GetHashCode(), ref2.GetHashCode());
        }
    }
}