using CSharp.TypeFundamentals.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheParent = CSharp.TypeFundamentals.Entities.EmployeeParent;

namespace CSharp.TypeFundamentals
{
    [TestClass]
    public class EmployeeTests
    {
        private const string Name = "Albert";
        private const string EmployeeTypeName = "CSharp.TypeFundamentals.Entities.Employee";
        private Employee _employee;
        private object _obj;

        [TestInitialize]
        public void TestInitialize()
        {
            _employee = new Employee(Name);
            _obj = _employee;
        }

        [TestMethod]
        public void ShouldGetEmployeeType()
        {
            Assert.AreEqual(EmployeeTypeName, _employee.GetType().ToString());
        }

        [TestMethod]
        public void ShoulGetObjectType()
        {
            Assert.AreEqual(EmployeeTypeName, _obj.GetType().ToString());
            Assert.IsTrue(_obj is Employee);
        }

        [TestMethod]
        public void ShouldCastObjectToEmployee()
        {
            var employee = (Employee) _obj;
            Assert.AreEqual(Name, employee.Name);
        }

        [TestMethod]
        public void ShouldCastEmployeeToEmployeeParent()
        {
            EmployeeParent employeeParent = _employee;
            Assert.AreEqual(EmployeeTypeName, employeeParent.GetType().ToString());
        }

        [TestMethod]
        public void ShouldCastUsingAsOperator()
        {
            var employee = _obj as Employee;
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public void ShouldNotCastObject()
        {
            var customer = _obj as Customer;
            Assert.IsNull(customer);
        }

        [TestMethod]
        public void ShouldAliasClassName()
        {
            var theParent = new TheParent();
            Assert.AreEqual(0, theParent.EmployeeParentId);
        }
    }
}