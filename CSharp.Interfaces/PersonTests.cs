using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Interfaces
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void ShouldCallVirtualInterfaceMethod()
        {
            var person = new Person();
            IPerson p = person;
            Assert.AreEqual("person is walking!", p.Walk());
        }
        
        [TestMethod]
        public void ShouldHaveParentAndChildWalk()
        {
            var employee = new Employee();
            Assert.AreEqual("employee is walking!", employee.Walk());
            
            Person person = employee;
            Assert.AreEqual("person is walking!", person.Walk());

            IPerson p = employee;
            Assert.AreEqual("person is walking!", p.Walk());
        }

        [TestMethod]
        public void ShouldHaveChildDance()
        {
            var student = new Student();
            Assert.AreEqual("student is dancing!", student.Dance());

            Person person = student;
            Assert.AreEqual("student is dancing!", person.Dance());

            IPerson iPerson = student;
            Assert.AreEqual("student is dancing!", iPerson.Dance());
        }
    }

    internal interface IPerson
    {
        public string Walk();
        public string Dance();
    }
    
    internal class Person : IPerson
    {
        public string Walk()
        {
            var result = "person is walking!";
            return result;
        }

        public virtual string Dance()
        {
            var result = "person is dancing!";
            return result;
        }
        
        public void Breathe() {}
    }

    internal class Employee : Person
    {
        public new string Walk()
        {
            var result = "employee is walking!";
            return result;
        }
    }

    internal class Student : Person
    {
        public override string Dance()
        {
            var result = "student is dancing!";
            return result;
        }
    }
}