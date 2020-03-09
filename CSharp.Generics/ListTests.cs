using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Generics
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void ShouldCreateDateList()
        {
            var dtList = new List<DateTime>();
            dtList.Add(DateTime.Now);
            dtList.Add(DateTime.MinValue);
            Assert.AreEqual(DateTime.MinValue, dtList[1]);
        }

        [TestMethod]
        public void ShouldFilter()
        {
            var myArray = new[] {1, 2, 3, 4, 1};
            var result = Array.FindAll(myArray, ( i => i != 1));
            Assert.AreEqual(3, result.Length);
        }
    }
}