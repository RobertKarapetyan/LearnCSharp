using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.RuntimeSerialization
{
    [TestClass]
    public class SerializeTests
    {
        [TestMethod]
        public void ShouldSerializeAndDeserializeObjectToMemory()
        {
            var objectGraph = new List<string> {"Jeff", "Kristin", "Aidan", "Grant"};
            var serialized = SerializeToMemory(objectGraph);
            var deserialized = (List<string>) DeserializeFromMemory(serialized);
            Assert.AreEqual(4, deserialized.Count);
        }

        [TestMethod]
        public void ShouldClone()
        {
            var originalPerson = new Person("Albert");
            var clonedPerson = (Person) Clone(originalPerson);
            Assert.IsFalse(object.ReferenceEquals(originalPerson, clonedPerson));
        }

        private static MemoryStream SerializeToMemory(object original)
        {
            var result = new MemoryStream();
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(result, original);
            return result;
        }

        private static object DeserializeFromMemory(Stream stream)
        {
            stream.Position = 0;
            var binaryFormatter = new BinaryFormatter();
            var result = binaryFormatter.Deserialize(stream);
            return result;
        }

        private static object Clone(object original)
        {
            var serialized = SerializeToMemory(original);
            var result = DeserializeFromMemory(serialized);
            return result;
        }
    }

    [Serializable]
    internal class Person
    {
        private readonly string _name;

        public Person(string name)
        {
            _name = name;
        }

        public string GetName() => _name;
    }
}