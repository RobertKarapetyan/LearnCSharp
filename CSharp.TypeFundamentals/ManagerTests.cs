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
    }
}