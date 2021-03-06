﻿using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.CharsStringsText
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void ShouldCreateString()
        {
            var myString = new string("abc");
            Assert.AreEqual("abc", myString);
            Assert.AreEqual("ABC", myString.ToUpperInvariant());
            Assert.AreEqual("abc", myString);
        }

        [TestMethod]
        [CompilationRelaxations(CompilationRelaxations.NoStringInterning)]
        public void ShouldNotHonorNoStringInterningAttribute()
        {
            var s1 = string.Intern("abc");
            var s2 = string.Intern("abc");
            var s3 = "abc";
            
            Assert.IsTrue(object.ReferenceEquals(s1, s2));
            Assert.IsTrue(object.ReferenceEquals(s2, s3));
        }

        [TestMethod]
        public void ShouldFindWordInList()
        {
            var wordList = new []
            {
                string.Intern("a"), 
                string.Intern("a"), 
                string.Intern("b"), 
                string.Intern("c"),
                string.Intern("a")
            };
            
            Assert.AreEqual(3, NumTimesWordAppearsIntern("a", wordList));
        }

        [TestMethod]
        public void ShouldFormatGuid()
        {
            var guid = Guid.NewGuid();
            Assert.AreEqual($"({guid.ToString()})", guid.ToString("P"));
        }

        [TestMethod]
        public void ShouldFormatDecimal()
        {
            var price = 123.54M;
            var s = price.ToString("C", new CultureInfo("vi-VN"));
            Assert.AreEqual("123,54 ₫", s);
        }
        
        private static int NumTimesWordAppearsIntern(string word, string[] wordlist) 
        {
            word = string.Intern(word);
            return wordlist.Count(_ => object.ReferenceEquals(word, _));
        }
    }
}