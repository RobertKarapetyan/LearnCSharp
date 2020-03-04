using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Methods
{
    [TestClass]
    public class ConversionOperatorTests
    {
        [TestMethod]
        public void ShouldImplicitlyConvert()
        {
            var rational = new Rational();
            rational = 15;
            
            Assert.AreEqual(15, rational.Number);
        }

        [TestMethod]
        public void ShouldExplicitlyConvert()
        {
            var rational = new Rational(15);
            var number = (int) rational;
            
            Assert.AreEqual(15, number);
        }
    }
    
    public sealed class Rational
    {
        public dynamic Number { get; set; }
        
        public Rational() {}
        
        // Constructs a Rational from an Int32
        public Rational(Int32 num)
        {
            Number = num;
        }

        // Constructs a Rational from a Single
        public Rational(float num)
        {
            Number = num;
        }

        // Converts a Rational to an Int32
        public Int32 ToInt32()
        {
            var result = (int) Number;
            return result;
        }

        // Converts a Rational to a Single
        public Single ToSingle()
        {
            var result = (Single) Number;
            return result;
        }

        // Implicitly constructs and returns a Rational from an Int32
        public static implicit operator Rational(Int32 num)
        {
            return new Rational(num);
        }

        // Implicitly constructs and returns a Rational from a Single
        public static implicit operator Rational(Single num)
        {
            return new Rational(num);
        }

        // Explicitly returns an Int32 from a Rational
        public static explicit operator Int32(Rational r)
        {
            return r.ToInt32();
        }

        // Explicitly returns a Single from a Rational
        public static explicit operator Single(Rational r)
        {
            return r.ToSingle();
        }
    }
}