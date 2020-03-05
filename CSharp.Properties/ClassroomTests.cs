using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Properties
{
    [TestClass]
    public class ClassroomTests
    {
        [TestMethod]
        public void ShouldSetStudnets()
        {
            var classroom = new Classroom
            {
                Students = { "1", "2", "3"}
            };
            classroom.Students.Add("4");

            Assert.AreEqual(4, classroom.Students.Count);
        }
    }
    
    public sealed class Classroom {
        private List<string> _students = new List<string>();
        public List<string> Students { get { return _students; } }
        public Classroom() {}
    }
}