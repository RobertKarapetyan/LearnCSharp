using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.CharsStringsText
{
    [TestClass]
    public class CharTests
    {
        [TestMethod]
        public void ShouldGetUnicodeCategory()
        {
            var myChar = new char();
            myChar = 'a';
            
            var result = char.GetUnicodeCategory(myChar);
            Assert.AreEqual(UnicodeCategory.LowercaseLetter, result);
        }

        [TestMethod]
        public void ShouldChangeCase()
        {
            var myChar = new char();
            myChar = 'a';
            
            Assert.AreEqual('A', char.ToUpper(myChar));
            Assert.AreEqual('a', myChar);
        }

        [TestMethod]
        public void ShouldGetNumericValue()
        {
            var d = char.GetNumericValue('\u0033'); 
            Assert.AreEqual(3, d);
        }

        [TestMethod]
        public void ShouldCase()
        {
            var myChar = (char) 65;
            Assert.AreEqual('A', myChar);
        }
    }
}