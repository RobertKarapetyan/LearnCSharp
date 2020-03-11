using System;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.CharsStringsText
{
    [TestClass]
    public class CustomFormatterTests
    {
        [TestMethod]
        public void TestBoldFormat()
        {
            var sb = new StringBuilder();
            sb.AppendFormat(new BoldInt(), "{0}", 123);
            Assert.AreEqual("<B>123</B>", sb.ToString());
        }
    }

    internal sealed class BoldInt : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            var result = formatType == typeof(ICustomFormatter) ? 
                this : Thread.CurrentThread.CurrentCulture.GetFormat(formatType);

            return result;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string result;

            if (arg is int)
            {
                result = "<B>" + arg + "</B>";
            }
            else
            {
                result = NonIntFormat(arg, format, formatProvider);
            }

            return result;
        }

        private static string NonIntFormat(object arg, string format, IFormatProvider formatProvider)
        {
            var result = !(arg is IFormattable) ? 
                arg.ToString() : ((IFormattable) arg).ToString(format, formatProvider);

            return result;
        }
    }
}