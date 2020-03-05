using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Properties
{
    [TestClass]
    public class TuplesTests
    {
        [TestMethod]
        public void ShouldCreateExpandoObject()
        {
            dynamic e = new System.Dynamic.ExpandoObject();
            e.x = 6; 
            e.y = "Jeff";     
           
            Assert.AreEqual("Jeff", e.y);
        }

        [TestMethod]
        public void ShouldCreateTuple()
        {
            var myTuple = (Student: "Robert", Teacher: "Albert");
            Assert.AreEqual("Albert", myTuple.Teacher);
            Assert.AreEqual("Albert", myTuple.Item2);
        }
    }
}