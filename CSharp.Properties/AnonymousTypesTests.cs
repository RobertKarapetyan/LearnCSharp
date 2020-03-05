using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Properties
{
    [TestClass]
    public class AnonymousTypesTests
    {
        [TestMethod]
        public void ShouldInitializeAnonymousType()
        {
            const string Name = "Jeff";
            const int Year = 1964;
            
            var o1 = new { Name = Name, Year = Year };
            var o2 = new {Name, Year};

            Assert.AreEqual(Name, o1.Name);
            Assert.AreEqual(Name, o2.Name);
            Assert.IsTrue(o1.Equals(o2));
        }

        [TestMethod]
        public void ShouldHaveTheSameHashCode()
        {
            const string Name = "Jeff";
            const int Year = 1964;
            
            var o1 = new { Name = Name, Year = Year };
            var o2 = new {Name, Year};
            Assert.AreEqual(o1.GetHashCode(), o2.GetHashCode());
        }

        [TestMethod]
        public void ShouldNotHaveTheSameHashCode()
        {
            var person1 = new Person{Name = "Albert"};
            var person2 = new Person{Name = "Albert"};
            Assert.AreNotEqual(person1.GetHashCode(), person2.GetHashCode());
        }

        [TestMethod]
        public void ShouldCreateAnonymousArray()
        {
            var people = new[] {
                new { Name = "Kristin", Year = 1970 },
                new { Name = "Kristin", Year = 1970 },
                new { Name = "Aidan", Year = 2003 },
                new { Name = "Grant", Year = 2008 }
            };

            Assert.AreEqual(people[0].GetHashCode(), people[1].GetHashCode());
            Assert.AreNotEqual(people[0].GetHashCode(), people[2].GetHashCode());
        }

        [TestMethod]
        public void ShoudCreateAnonymousQueryresult()
        {
            var myFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var pathNames = Directory.GetFiles(myFolder);
            
            var query =
                from pathname in pathNames
                let lastWriteTime = File.GetLastWriteTime(pathname)
                orderby lastWriteTime
                select new { Path = pathname, LastWriteTime = lastWriteTime };
            
            Assert.IsTrue(query.Any());
        }
    }

    internal sealed class Person
    {
        public string Name { get; set; }
    }
}