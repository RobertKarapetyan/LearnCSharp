using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Properties
{
    [TestClass]
    public class IndexerTests
    {
        [TestMethod]
        public void ShouldAccessIndexers()
        {
            var bitArray = new BitArray(14);

            for (var i = 0; i < 14; i++) {
                bitArray[i] = (i % 2 == 0);
            }
            
            Assert.IsTrue(bitArray[2]);

            bitArray[0] = true;
            Assert.IsTrue(bitArray[0]);
        }
    }
    
    public sealed class BitArray 
    {
        private readonly byte[] _byteArray;
        private readonly int _numBits;
        
        public BitArray(int numBits) {
            _numBits = numBits;
            _byteArray = new byte[(numBits + 7) / 8];
        }
        
        public bool this[int bitPos] {
            get => (_byteArray[bitPos / 8] & (1 << (bitPos % 8))) != 0;
            set {
                if (value) {
                    _byteArray[bitPos / 8] = (byte) (_byteArray[bitPos / 8] | (1 << (bitPos % 8)));
                } else {
                    _byteArray[bitPos / 8] = (byte) (_byteArray[bitPos / 8] & ~(1 << (bitPos % 8)));
                }
            }
        }
    }
            
}