using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Methods
{
    [TestClass]
    public class RectanbleTests
    {
        [TestMethod]
        public void ShouldInitializeValueTypeByDefault()
        {
            var rectangle = new Rectangle();
            var topLeft = rectangle.TopLeft;
            var bottomRight = rectangle.BottomRight;
            
            Assert.AreEqual(0, topLeft.X);
            Assert.AreEqual(0, topLeft.Y);
            Assert.AreEqual(0, bottomRight.X);
            Assert.AreEqual(0, bottomRight.Y);
        }
        
        [TestMethod]
        public void ShouldInitializeValueTypeByParameter()
        {
            var rectangle = new Rectangle(1, 2);
            var topLeft = rectangle.TopLeft;
            var bottomRight = rectangle.BottomRight;
            
            Assert.AreEqual(1, topLeft.X);
            Assert.AreEqual(2, topLeft.Y);
            Assert.AreEqual(1, bottomRight.X);
            Assert.AreEqual(2, bottomRight.Y);
        }
    }

    internal sealed class Rectangle
    {
        public Point TopLeft, BottomRight;
        
        public Rectangle() {}

        public Rectangle(int x, int y)
        {
            TopLeft = new Point(x, y);
            BottomRight = new Point(x, y);
        }
    }

    internal struct Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}