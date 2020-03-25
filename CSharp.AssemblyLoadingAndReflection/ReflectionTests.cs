using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.AssemblyLoadingAndReflection
{
    [TestClass]
    public class ReflectionTests
    {
        [TestMethod]
        public void ShouldGetModuleCount()
        {
            var assembly = Assembly.Load("System.Data");
            var moduleCount = assembly.Modules.Count();
            Assert.AreEqual(1, moduleCount);
        }

        [TestMethod]
        public void ShouldGetPersonDetails()
        {
            var personType = typeof(Person);
            Assert.AreEqual("_firstName", personType.GetTypeInfo().DeclaredFields.ToList()[0].Name);
            Assert.AreEqual("_lastName", personType.GetTypeInfo().DeclaredFields.ToList()[1].Name);
            Assert.AreEqual("Void .ctor(System.String, System.String)", 
                personType.GetTypeInfo().DeclaredConstructors.ToList()[0].ToString());
            Assert.AreEqual("ToString", personType.GetTypeInfo().DeclaredMethods.ToList()[0].Name);
            Assert.AreEqual("Print", personType.GetTypeInfo().DeclaredMethods.ToList()[1].Name);
            Assert.AreEqual(typeof(MyPrintStandard),
                personType.GetTypeInfo().GetDeclaredMethod("Print").CustomAttributes.
                    ToList()[0].AttributeType);
        }

        [TestMethod]
        public void ShouldInvokeToString()
        {
            var personType = typeof(Person);
            var personInstance = personType.GetTypeInfo().DeclaredConstructors.FirstOrDefault()?.
                Invoke(new object[] {"Albert", "Cervantes"});
            var toStringMethod = personType.GetMethods().ToList().FirstOrDefault(_ => _.Name.Equals("ToString"));
            Debug.Assert(toStringMethod != null, nameof(toStringMethod) + " != null");
            Assert.AreEqual("Cervantes, Albert", 
                toStringMethod.Invoke(personInstance, null).ToString());
        }
    }

    internal class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public override string ToString()
        {
            var result = $"{_lastName}, {_firstName}";
            return result;
        }

        [MyPrintStandard]
        public void Print()
        {
            var result = $"{_firstName} {_lastName}";
            Console.WriteLine(result);
        }
    }

    internal class MyPrintStandard : Attribute
    {
        
    }
}