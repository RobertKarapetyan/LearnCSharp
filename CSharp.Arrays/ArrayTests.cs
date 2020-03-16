using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Arrays
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void ShouldCreateAnonymousArray()
        {
            var kids = new[] {new { Name="Aidan" }, new { Name="Grant" }};

            Assert.AreEqual("Aidan", kids[0].Name);
            Assert.AreEqual("Grant", kids[1].Name);
        }

        [TestMethod]
        public void ShouldShallowCopyToAnotherArrayVal()
        {
            var numbers = new[] {1, 2, 3, 4, 5};
            var numbersCopy = new int[numbers.Length];
            Array.Copy(numbers, numbersCopy, numbers.Length);
            Assert.IsFalse(object.ReferenceEquals(numbers, numbersCopy));
        }

        [TestMethod]
        public void ShouldShallowCopyToAnotherArrayRef()
        {
            var persons = new Person[] {new Person("a"), new Person("b")};
            var personsCopy = new Person[2];
            Array.Copy(persons, personsCopy, 2);
            Assert.IsTrue(object.ReferenceEquals(persons[0], personsCopy[0]));
        }

        [TestMethod]
        public void ShouldCreateArrayType()
        {
            var persons = new Person[]
            {
                new Person("Albert"), new Person("Robert")
            };
            
            Assert.AreEqual("CSharp.Arrays.Person[]", persons.GetType().ToString());
        }

        [TestMethod]
        public void ShouldCreateUnsafeArray()
        {
            unsafe
            {
                var charArray = InlineArrayDemo();
                Assert.AreEqual("J", charArray.Characters[19].ToString());
            }
        }

        [TestMethod]
        public void ShouldAllocateArrayOnStack()
        {
            unsafe
            {
                var result = StackallocDemo();
                Assert.AreEqual("J", result[19].ToString());
            }
        }

        private static unsafe char* StackallocDemo() 
        {
            const int width = 20;
            var result = stackalloc char[width];
                
            const string s = "Jeffrey Richter"; 
            for (var i = 0; i < width; i++) 
            {
                result[width - i - 1] = (i < s.Length) ? s[i] : '.';
            }
                
            return result;
        }
        
        private static CharArray InlineArrayDemo() 
        {
            unsafe {
                CharArray ca; 
                var widthInBytes = sizeof(CharArray);
                var width = widthInBytes / 2;
                const string s = "Jeffrey Richter"; 
                for (var i = 0; i < width; i++) 
                {
                    ca.Characters[width - i - 1] = (i < s.Length) ? s[i] : '.';
                }

                return ca;
            }
        }
    }

    internal class Person
    {
        public string Name { get;}

        public Person(string name)
        {
            Name = name;
        }
    }
    
    internal unsafe struct CharArray 
    {
        public fixed char Characters[20];
    }
}