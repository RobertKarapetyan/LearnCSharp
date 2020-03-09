using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Generics
{
    [TestClass]
    public class VarienceTests
    {
        private delegate TResult MyFunction<
            in T, // Contra-variant
            out TResult>(T arg); // Covariant

        [TestMethod]
        public void ShouldProperlyCastDelegate()
        {
            MyFunction<object, Child> _ = null;
            MyFunction<string, Parent> myFunction = _;
            
            myFunction = s => new Parent{ParentName = s};
            Assert.AreEqual("Albert", myFunction("Albert").ParentName);
        }
    }

    internal class Parent
    {
        public string ParentName { get; set; }
    }

    internal class Child : Parent
    {
        public string ChildName { get; set; }
    }
}