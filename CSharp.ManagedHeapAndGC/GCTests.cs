using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.ManagedHeapAndGC
{
    [TestClass]
    public class GcTests
    {
        [TestMethod]
        public void ShouldBreatheOnce()
        {
            var person = new Person(isGcCollected:true);
            Thread.Sleep(10000);
            Assert.AreEqual(1, person.BreatheCount);
        }

        [TestMethod]
        public void ShouldBreatheFiveTimes()
        {
            var person = new Person(false);
            Thread.Sleep(10000);
            Assert.AreEqual(5, person.BreatheCount);
        }
    }

    public class Person
    {
        public int BreatheCount { get; private set; }
        private readonly bool _isGcCollected;
        private readonly Timer _interval;

        public Person(bool isGcCollected)
        {
            _isGcCollected = isGcCollected;
            BreatheCount = 0;
            _interval = new Timer(Breathe, null, 0, 2000);
        }

        private void Breathe(object o)
        {
            BreatheCount++;

            if (_isGcCollected)
            {
                GC.Collect();
            }
        }

        private void Dispose()
        {
            _interval.Dispose();
        }
    }
}