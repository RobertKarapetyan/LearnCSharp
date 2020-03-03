using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Methods
{
    [TestClass]
    public class SomeValueTypeTests
    {
        [TestMethod]
        public void ShouldPartiallyInitializeValueType()
        {
            var someValueType = new SomeValueType(1);
            Assert.AreEqual(1, someValueType.X);
            Assert.AreEqual(0, someValueType.Y);
        }
    }

    internal struct SomeValueType
    {
        public int X, Y;

        public SomeValueType(int x)
        {
            this = new SomeValueType();
            X = x;
        }
    }
}