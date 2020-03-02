using System;
using System.Reflection.Emit;
using CSharp.TypeFundamentals.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.TypeFundamentals
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void ShouldCallVirtualMethod()
        {
            Employee employee = new Manager("Albert");
            Assert.AreEqual("manager progress report", employee.GetProgressReport());
            employee = Employee.Lookup("Joe");
            var progressReport = employee.GetProgressReport();
            Assert.AreEqual("manager progress report", progressReport);
        }

        [TestMethod]
        public void ShouldCallNonVirtualMethod()
        {
            Employee employee = new Manager("Albert");
            Assert.AreEqual(5, employee.GetYearsEmployed());
            var manager = (Manager) employee;
            Assert.AreEqual(2, manager.GetYearsEmployed());
        }

        [TestMethod]
        public void ManagerShouldBeObject()
        {
            var manager = new Manager("Albert");
            Assert.IsTrue(manager is Object);
            Assert.IsTrue(manager is Employee);

            object o = manager;
            var employee = o as Employee; 
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public void ObjectVsOtherTypes()
        {
            var employee = new Employee("Albert");
            var obj = new Object();

            var objType = obj.GetType();
        }

        [TestMethod]
        public void ShouldPassArgByVal()
        {
            const string name = "Albert";
            
            var employee = new Employee(name);
            SomeMethod(employee);
            Assert.AreEqual(name, employee.Name);
        }

        public void SomeMethod(Employee employee)
        {
            employee = new Employee("George");
        }
    }
}