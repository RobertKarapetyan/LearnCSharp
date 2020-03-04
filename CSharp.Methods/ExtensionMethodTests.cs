using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Methods
{
    [TestClass]
    public class ExtensionMethodTests
    {
        [TestMethod]
        public void ShouldCallExtensionMethod()
        {
            var apple = new Apple();
            var cutResult = apple.Cut(3);
            Assert.AreEqual("Cut in 3 pieaces", cutResult);
        }
    }

    internal class Apple
    {
        
    }

    internal static class AppleExtensions
    {
        public static string Cut(this Apple apple, byte pieaceCount)
        {
            var result = $"Cut in {pieaceCount} pieaces";
            return result;
        }
    }
}