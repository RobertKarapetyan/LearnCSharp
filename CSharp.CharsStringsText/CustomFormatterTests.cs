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
            
            if (!(arg is IFormattable formattable))
            {
                result = arg.ToString();
            }
            else
            {
                result = formattable.ToString(format, formatProvider);
            }

            if (arg is int)
            {
                result = "<B>" + result + "</B>";
            }

            return result;
        }
    }
}