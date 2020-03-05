using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Parameters
{
    [TestClass]
    public class InferTypeTests
    {
        [TestMethod]
        public void ShouldInferType()
        {
            var name = "Albert";
            var typeName = ShowVariableType(name);
            Assert.AreEqual("System.String", typeName);
        }

        [TestMethod]
        public void ShouldInferTypeForCollection()
        {
            var collection = new Dictionary<String, Single>() { { "Grant", 4.0f } };
            var typeName = ShowVariableType(collection);
            Assert.AreEqual("System.Collections.Generic.Dictionary`2[System.String,System.Single]", typeName);
        }

        private static string ShowVariableType<T>(T t)
        {
            var result = typeof(T).ToString();
            return result;
        }
    }
}