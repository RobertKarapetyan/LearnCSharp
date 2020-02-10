using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.TypeFundamentals
{
    [TestClass]
    public class EmployeeTests
    {
        private const string Name = "Albert";
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
            Assert.AreEqual("CSharp.TypeFundamentals.Employee", _employee.GetType().ToString());
        }

        [TestMethod]
        public void ShoulGetObjectType()
        {
            Assert.AreEqual("CSharp.TypeFundamentals.Employee", _obj.GetType().ToString());
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
            Assert.AreEqual("CSharp.TypeFundamentals.Employee", employeeParent.GetType().ToString());
        }
    }
}