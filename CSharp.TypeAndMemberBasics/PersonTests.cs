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

        [TestMethod]
        public void ShouldGetAge()
        {
            const int age = 17;
            
            var employee = new Employee();
            Person person = employee;
            person.SetAge(age);

            var e = (Employee) person;
            Assert.AreEqual(age, e.AgeOfThePerson());
        }

        [TestMethod]
        public void ShouldGetName()
        {
            const string name = "Albert";
            
            var employee = new Employee();
            Person person = employee;

            person.SetName(name);

            var e = (Employee) person;
            Assert.AreEqual(name, e.GetPersonName());
        }
    }
}