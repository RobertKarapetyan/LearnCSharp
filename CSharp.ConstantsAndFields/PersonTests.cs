using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.ConstantsAndFields
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void ShouldAccessCosntantStatically()
        {
            var entityName = Person.EntityName;
            Assert.AreEqual("Person", entityName);
        }

        [TestMethod]
        public void ShouldPassCosntantAsValue()
        {
            var result = M(Person.EntityName);
            Assert.AreEqual("PersonPerson", result);
        }

        private string M(string input)
        {
            input += input;
            var result = input;
            return result;
        }
    }
}