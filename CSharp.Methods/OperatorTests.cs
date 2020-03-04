using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Methods
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        public void ShouldOverloadOperator()
        {
            var c1 = new Complex {Name = "c1"};
            var c2 = new Complex {Name = "c2"};
            var c1C2 = c1 + c2;
            Assert.AreEqual("c1c2", c1C2.Name);

            Decimal x;
        }
    }
    
    public sealed class Complex 
    {
        public string Name { get; set; }
        
        public static Complex operator +(Complex c1, Complex c2)
        {
            var name = string.Concat(c1.Name, c2.Name);
            var result = new Complex
            {
                Name = name
            };
            
            return result;
        }
    }
}