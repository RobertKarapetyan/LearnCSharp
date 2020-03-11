using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Generics
{
    [TestClass]
    public class AdderTests
    {
        [TestMethod]
        public void ShouldAddInts()
        {
            var adder = new Adder<int>();
            
            Assert.AreEqual(2, adder.Add(1, 1));
            AdderParent<int> adderParent = adder;
            Assert.AreEqual(2, adderParent.Add(1, 1));
        }

        [TestMethod]
        public void ShouldAddDoubles()
        {
            var adder = new Adder<double>();
            Assert.AreEqual(2.2, adder.Add(1.1, 1.1));
        }

        [TestMethod]
        public void ShouldFindMaxValue()
        {
            const int n1 = 200;
            const int n2 = 20;
            var adder = new Adder<int>();

            Assert.AreEqual(adder.Max(n1, n2), n1);
        }
    }

    internal class Adder<T> : AdderParent<T> where T : IComparable 
     {
         public T Max(T n1, T n2)
         {
             T result;
             var comparision = n1.CompareTo(n2);
 
             if (comparision < 0)
             {
                 result = n2;
             }
             else if (comparision > 0)
             {
                 result = n1;
             }
             else
             {
                 result = default(T);
             }
 
             return result;
         }
     }

    internal class AdderParent<T>
    {
        public T Add(dynamic n1, dynamic n2)
        {
            var result = (T) (n1 + n2);
            return result;
        }
    }
}