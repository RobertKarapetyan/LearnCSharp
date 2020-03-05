using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Parameters
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void ShouldModifyPersonPointer()
        {
            var person = new Person
            {
                Name = "Albert"
            };

            ModifyPersonPointer(ref person);
            Assert.AreEqual("Robert", person.Name);
        }

        [TestMethod]
        public void ShouldNotModifyPersonPointer()
        {
            var person = new Person
            {
                Name = "Albert"
            };

            ModifyPersonPointer(person);
            Assert.AreEqual("Albert", person.Name);
        }

        private static void ModifyPersonPointer(ref Person personArg)
        {
            // PersonArg -> personRef [Thread Stack]
            personArg = new Person
            {
                Name = "Robert"
            };
        }
        
        private static void ModifyPersonPointer(Person personArg)
        {
            // PersonArg -> personObject [Heap]
            personArg = new Person
            {
                Name = "Robert"
            };
        }
    }

    internal class Person
    {
        public string Name { get; set; }
    }
}