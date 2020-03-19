using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.ExceptionsAndStateManagement
{
    [TestClass]
    public class ExceptionTests
    {
        [TestMethod]
        public void ShouldRethrowException()
        {
            Assert.ThrowsException<MyMathException>(() => { Utility<int>.Divide(5, 0); });
        }
        
        [TestMethod]
        public void ShouldNotDisplayUi()
        {
            var uiStuff = new UiStuff();
            Assert.AreEqual("WillNotDisplayUI", uiStuff.DisplayDivisionResults(5, 0));
        }

        [TestMethod]
        public void ShouldDisplayUi()
        {
            var uiStuff = new UiStuff();
            Assert.AreEqual("WillDisplayUI", uiStuff.DisplayDivisionResults(5, 5));
        }
    }
}