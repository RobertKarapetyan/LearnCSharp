using System;
using System.Collections;
using CSharp.PrimitveRefAndValTypes.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.PrimitveRefAndValTypes
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void ShouldBox()
        {
            var a = new ArrayList();
            Point p;

            for (var i = 0; i < 10; i++) {
                p.m_x = p.m_y = i; 
                a.Add(p);
            }
            
            Assert.AreEqual(2, ((Point) a[2]).m_x);
        }

        [TestMethod]
        public void ShouldBoxAndUnbox()
        {
            Int32  v = 5;            // Create an unboxed value type variable.
            Object o = v;            // o refers to a boxed Int32 containing 5.
            v = 123;                 // Changes the unboxed value to 123
            
            Assert.AreEqual(5, (Int32) o);
            Assert.AreEqual(123, v);
        }


        [TestMethod]
        public void ShouldNotchangeStructState()
        {
            var p1 = new Point(1, 1);
            p1.Change(2, 2);
            Object o = p1;
            var p2 = (Point) o;
            p2.Change(3, 3);
           
            Assert.AreNotEqual(p1, p2);
            Assert.AreEqual(o, p1);
        }

        [TestMethod]
        public void ShouldChangeStructstate()
        {
            var p = new ChangeablePoint(1, 1);
            p.Change(2, 2);
            IChangable o = p;
            o.Change(3, 3);
            
            Assert.AreNotEqual(o, p);
        }

        [TestMethod]
        public void ShouldBoxAndChange()
        {
            var p = new ChangeablePoint(1, 1);

            p.Change(2, 2);
            Object o = p;
            ((ChangeablePoint) o).Change(3, 3);
            var p2 = ((IChangable) p);
            p2.Change(4, 4);
            Assert.AreEqual(o, p);
            Assert.AreNotEqual(p2, o);
        }
    }
}