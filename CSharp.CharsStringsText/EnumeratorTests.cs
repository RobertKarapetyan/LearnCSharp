using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.CharsStringsText
{
    [TestClass]
    public class EnumeratorTests
    {
        [TestMethod]
        public void ShouldDisplayDetails()
        {
            var s = string.Intern("abc");
            string result;
            result = SubstringByTextElements(s);
            result = EnumTextElements(s);
            result = EnumTextElementIndexes(s);
        }

        private static string SubstringByTextElements(string s) {
            var output = string.Empty;
            var si = new StringInfo(s);
            for (var element = 0; element < si.LengthInTextElements; element++) {
                output += $"Text element " +
                          $"{element} is " +
                          $"'{si.SubstringByTextElements(element, 1)}'" +
                          $"{Environment.NewLine}";
            }

            return output;
        }
        
        private static string EnumTextElements(string s) {
            var output = string.Empty;
            var charEnum = StringInfo.GetTextElementEnumerator(s);
            while (charEnum.MoveNext()) {
                output +=
                    $"Character at index " +
                    $"{charEnum.ElementIndex} is '" +
                    $"{charEnum.GetTextElement()}'" +
                    $"{Environment.NewLine}";
            }

            return output;
        }
        
        private static string EnumTextElementIndexes(string s) {
            var output = string.Empty;
            var textElemIndex = StringInfo.ParseCombiningCharacters(s);
            for (var i = 0; i < textElemIndex.Length; i++) {
                output += 
                    $"Character {i} starts at index {textElemIndex[i]}{Environment.NewLine}";
            }

            return output;
        }
    }
}