using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Events
{
    internal delegate string MyFunction<in Tin>(Tin input);
    
    internal static class MyClass
    {
        public static readonly MyFunction<int> myFunction;

        static MyClass()
        {
            myFunction = input => input.ToString();         
        }
    }
    
    [TestClass]
    public class MyClassTests
    {
        [TestMethod]
        public void ShouldCallDelegate()
        {
            Assert.AreEqual("151", MyClass.myFunction(151));
        }
    }
}