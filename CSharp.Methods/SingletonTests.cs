using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Methods
{
    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void ShouldGetHoldOfSingleton()
        {
            var singleton = Singleton.GetInstance();
            Assert.AreEqual("Singleton", singleton.Name);
        }
    }
    
    internal class Singleton
    {
        public string Name;
        private static Singleton INSTANCE;
        
        static Singleton()
        {
            INSTANCE = new Singleton();
            INSTANCE.Name = "Singleton";
        }

        private Singleton() {}

        public static Singleton GetInstance() {
            return INSTANCE;
        }
    }
}