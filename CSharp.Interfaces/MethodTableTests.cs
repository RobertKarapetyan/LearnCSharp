using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Interfaces
{
    [TestClass]
    public class MethodTableTests
    {
        [TestMethod]
        public void ShouldCallInterfaceMethodSelectively()
        {
            var myEntity = new MyEntity();
            Assert.AreEqual("MyEntity moves!", myEntity.Move());

            IEntity iEntity = myEntity;
            Assert.AreEqual("MyEntity gets to move!", iEntity.Move());
        }
        
    }

    internal interface IEntity
    {
        string Move();
    }

    internal class MyEntity : IEntity
    {
        public string Move()
        {
            var result = "MyEntity moves!";
            return result;
        }
        
        string IEntity.Move()
        {
            var result = "MyEntity gets to move!";
            return result;
        }
    }
}