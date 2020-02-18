using System;
using CSharp.PrimitveRefAndValTypes.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.PrimitveRefAndValTypes
{
    [TestClass]
    public class RefAndValTests
    {
        private SomeRef _someRef;
        private SomeVal _someVal;

        [TestInitialize]
        public void TestInitialize()
        {
            _someRef = new SomeRef();
            _someVal = new SomeVal();
        }

        [TestMethod]
        public void ShouldAssignValues()
        {
            _someRef.x = 5;
            _someVal.x = 5;
            
            Assert.AreEqual(5, _someRef.x);
            Assert.AreEqual(5, _someVal.x);
        }

        [TestMethod]
        public void ShouldCopyreferenceButNotVal()
        {
            var r1 = new SomeRef(); 
            var v1 = new SomeVal(); 
            r1.x = 5; 
            v1.x = 5; 
            
            var r2 = r1; 
            var v2 = v1; 
            r1.x = 8; 
            v1.x = 9; 
            
            Assert.AreEqual(r1.x, r2.x);
            Assert.AreNotEqual(v1.x, v2.x);
        }
    }
}