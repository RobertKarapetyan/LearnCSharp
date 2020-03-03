using CSharp.Methods.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Methods
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void ShouldGetName()
        {
            const string name = "Albert";
            var employee = new Employee(name);
            Assert.AreEqual(name, employee.Name());
        }

        [TestMethod]
        public void ShouldMemberwiseClone()
        {
            const string employeeId1 = "Employee1";
            const string employeeId2 = "Employee2";
            
            var employee1 = new Employee("Albert");
            var employee2 = employee1.CloneEmployeeByMembers();

            employee1.EmployeeId = employeeId1;
            employee2.EmployeeId = employeeId2;
            
            Assert.AreEqual(employeeId1, employee1.EmployeeId);
            Assert.AreEqual(employeeId2, employee2.EmployeeId);
        }
    }
}