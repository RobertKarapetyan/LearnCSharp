using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Generics
{
    [TestClass]
    public class GenericSingletonTests
    {
        [TestMethod]
        public void ShouldCreatePersonSingleton()
        {
            var personSingleton = Singleton<Person>.GetInstance();
            Assert.AreEqual("Albert", personSingleton.Composition.Name);
        }
    }

    internal class Singleton<T> where T : new() // constructor constraint
    {
        public T Composition;

        private static readonly Singleton<T> Instance;

        static Singleton()
        {
            Instance = new Singleton<T> {Composition = new T()};
        }

        private Singleton()
        {
        }

        public static Singleton<T> GetInstance() 
        {
            return Instance;
        }
    }
    
    public class Person
    {
        public string Name { get; set; }

        public Person()
        {
            Name = "Albert";
        }
    }
}
