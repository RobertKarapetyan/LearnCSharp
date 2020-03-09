using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Generics
{
    [TestClass]
    public class ConstraintTests
    {
        [TestMethod]
        public void ShouldConvertIList()
        {
            var numbers = new List<int>{1, 2, 3};
            IList<int> list = numbers;
            var result = ConvertIList<int, object>(list);        
            Assert.AreEqual(3, result.Count);
        }
        
        private static List<TBase> ConvertIList<T, TBase>(IList<T> list) where T : TBase 
        {
            var result = new List<TBase>(list.Count);
            result.AddRange(list.Cast<TBase>());
            return result;
        }
    }
}