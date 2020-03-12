using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.CharsStringsText
{
    [TestClass]
    public class EncodingTests
    {
        [TestMethod]
        public void ShouldEncode()
        {
            const string s = "Albert is there.";
           
            var encodedBytes = Encoding.UTF8.GetBytes(s);
            Assert.AreEqual(65, encodedBytes[0]);
            
            var decodedString = Encoding.UTF8.GetString(encodedBytes);
            Assert.AreEqual(s, decodedString);
        }
    }
}