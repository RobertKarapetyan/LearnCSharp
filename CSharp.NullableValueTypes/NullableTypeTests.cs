using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.NullableValueTypes
{
    [TestClass]
    public class NullableTypeTests
    {
        [TestMethod]
        public void ShouldReturnNullForValueType()
        {
           var myInt = new MyNullable<int>();
           Assert.IsNull(Utility.Box(myInt));
        }

        [TestMethod]
        public void ShouldNotReturnNullForValueType()
        {
            var myInt = new MyNullable<int>(15);
            Assert.IsNotNull(Utility.Box(myInt));
            Assert.AreEqual(15, Utility.Box(myInt));
        }

        [MyNullableAttribute]
        private struct MyNullable<T>
        {
            public T Value;
            public bool HasValue;

            public MyNullable(T value)
            {
                Value = value;
                HasValue = true;
            }
        }

        private class Utility
        {
            public static object Box(object o)
            {
                if (!o.GetType().IsDefined(typeof(MyNullableAttribute), false)) return o.ToString();

                dynamic result = null;
                
                if (o is MyNullable<int> myNullable && myNullable.HasValue)
                {
                    result = myNullable.Value;
                }

                return result;
            }
        }
        
        [AttributeUsage(AttributeTargets.Struct)]
        public class MyNullableAttribute : Attribute
        {
            public MyNullableAttribute()
            {
            
            }
        }
    }
}