using CSharp.TypeAndMemberBasics.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.TypeAndMemberBasics
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void ShouldGreetFromPerson()
        {
            var employee = new Employee();
            Person person = employee;
            Assert.AreEqual("Employee Greeting", person.Greeting());
        }

        [TestMethod]
        public void ShouldFarewellFromPerson()
        {
            var employee = new Employee();
            Assert.AreEqual("Employee Goodbye", employee.Goodbye());
            
            Person person = employee;
            Assert.AreEqual("Person Goodbye", person.Goodbye());
        }
    }
}