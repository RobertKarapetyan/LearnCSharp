using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Properties
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void ShouldSetAge()
        {
            var employee = new Employee();
            employee.Age = 9;
            Assert.AreEqual(9, employee.Age);
        }

        [TestMethod]
        public void ShouldNotSetAge()
        {
            var employee = new Employee();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { employee.Age = -9; });
        }

        [TestMethod]
        public void ShouldInitialize()
        {
            
        }
        
        public sealed class Employee
        {
            private string _name;
            private int _age;
            
            public string Name {
                get => (_name);
                set => _name = value;  
            }
            
            public int Age {
                get => (_age);
                set {
                    if (value < 0) 
                        throw new ArgumentOutOfRangeException(nameof(value), value.ToString(),
                            "The value must be greater than or equal to 0");
                    _age = value;
                }
            }
        }
    }
}