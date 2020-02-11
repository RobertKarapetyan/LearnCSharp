using CSharp.TypeFundamentals.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.TypeFundamentals
{
    [TestClass]
    public class EmployeeParentTests
    {
        private const string Name = "Albert";
        private Employee _employee;
        private EmployeeParent _employeeParent;
        private object _obj;

        [TestInitialize]
        public void TestInitialize()
        {
            _employeeParent = new EmployeeParent();
            _employee = new Employee(Name);
            _obj = _employee;
        }

        [TestMethod]
        public void ShouldCastObjectToEmployeeParent()
        {
            var employeeParent = _obj as EmployeeParent;
            Assert.IsNotNull(employeeParent);
        }
    }
}