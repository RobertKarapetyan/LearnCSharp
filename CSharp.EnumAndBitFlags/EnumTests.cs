using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.EnumAndBitFlags
{
    [TestClass]
    public class EnumTests
    {
        [TestMethod]
        public void ShouldGetyUnderlyingType()
        {
            var result = Enum.GetUnderlyingType(typeof(Color));
            Assert.AreEqual(typeof(byte), result);
        }

        [TestMethod]
        public void ShouldToString()
        {
            const Color white = Color.White;
            Assert.AreEqual("White", white.ToString());
        }

        [TestMethod]
        public void ShouldGetEnumConstFromNumber()
        {
            Assert.AreEqual("Blue", Enum.Format(typeof(Color), (byte) 3, "G"));
        }

        [TestMethod]
        public void ShouldGetEnumValues()
        {
            var result = GetEnumValues<Color>();
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void ShouldVerifyIfDefined()
        {
            Assert.IsTrue(Enum.IsDefined(typeof(Color), "White"));
        }

        [TestMethod]
        public void ShouldTryToGetColor()
        {
            Enum.TryParse<Color>("White", false, out var color);
            Assert.AreEqual("White", color.ToString());
        }

        [TestMethod]
        public void ShouldHaveMultipleActions()
        {
            var actions = Actions.Read | Actions.Write;
            
            var isReadWrite = (actions & Actions.Read) != 0 && (actions & Actions.Write) != 0;
            Assert.IsTrue(isReadWrite);
        }

        private static TEnum[] GetEnumValues<TEnum>() where TEnum : struct 
        {
            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }
    }
    
    internal enum Color : byte {
        White,
        Red,
        Green,
        Blue,
        Orange
    }
    
    [Flags]
    internal enum Actions {
        None      = 0,
        Read      = 0x0001,
        Write     = 0x0002,
        ReadWrite = Actions.Read | Actions.Write,
        Delete    = 0x0004,
        Query     = 0x0008,
        Sync      = 0x0010
    }
    
}