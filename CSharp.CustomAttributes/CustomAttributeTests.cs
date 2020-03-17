using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.CustomAttributes
{
    [TestClass]
    public class CustomAttributeTests
    {
        [TestMethod]
        public void ShouldPrintFancily()
        {
            const string personName = "Albert";
            var person = new Person { Name = personName };
            Assert.AreEqual($"*** {personName}", Utility.Print(person));
        }

        [TestMethod]
        public void ShouldNotPrintFancily()
        {
            const string animalName = "Boxy";
            var animal = new Animal { Name = animalName };
            Assert.AreEqual(animalName, Utility.Print(animal));
        }
    }

    internal interface INameable
    {
        string Name { get; set; }
    }

    [Fancy]
    internal class Person : INameable
    {
        public string Name { get; set; }
    }
    
    internal class Animal : INameable
    {
        public string Name { get; set; }
    }

    internal class Utility
    {
        public static string Print(INameable nameable)
        {
            string result = nameable.Name;

            if (nameable.GetType().IsDefined(typeof(FancyAttribute), false))
            {
                result = $"*** {nameable.Name}";
            }

            return result;
        }
    }
    
    [AttributeUsage(AttributeTargets.Class)]
    public class FancyAttribute : Attribute
    {
        public FancyAttribute()
        {
            
        }
    }
}