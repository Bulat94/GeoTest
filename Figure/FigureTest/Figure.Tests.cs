using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figure;

namespace FigureTest
{
    [TestClass]
    public class FigureTest
    {
        public void ExceptionTest(Action a)
        {
            Assert.ThrowsException<FormatException>(a);           
        }

        public void AreaTest<T>(double expectedArea, T figure)
            where T: Figure.Figure
        {
            Assert.AreEqual(expectedArea, Math.Round(figure.Area(), 4));
        }

        [TestMethod]
        public void InvalidTriangleSides()
        {
            ExceptionTest(() => new Triangle(1, 1, 1));
            ExceptionTest(() => new Triangle(4, 2, 2));
        }

        [TestMethod]
        public void ZeroTriangleParams()
        {
            ExceptionTest(() => new Triangle(4, 0, 1));
            ExceptionTest(() => new Triangle(0, 4, 4));
            ExceptionTest(() => new Triangle(9, 3, 0));
        }

        [TestMethod]
        public void ZeroCircleParams()
        {
            ExceptionTest(() => new Circle(0));
            ExceptionTest(() => new Circle(3).Radius = 0);
        }

        [TestMethod]
        public void NegativeTriangleParams()
        {
            ExceptionTest(() => new Triangle(-5,-4, -3));
            ExceptionTest(() => new Triangle(-5, 4, 3));
            ExceptionTest(() => new Triangle(5, -4, 3));
            ExceptionTest(() => new Triangle(5, 4, -3));
        }

        [TestMethod]
        public void NegativeCircleParams()
        {
            ExceptionTest(() => new Circle(-5));
            ExceptionTest(() => new Circle(3).Radius = -2);
        }

        [TestMethod]
        public void CircleAreaCalculate()
        {
            Circle c = new Circle(2);
            AreaTest(12.5664, c);
            c.Radius= 3.412;
            AreaTest(36.5736, c);
        }

        [TestMethod]
        public void TriangleAreaCalculate()
        {
            AreaTest(6, new Triangle(5, 4, 3));
            AreaTest(1.548, new Triangle(3.5557840204376867, 3.44, 0.9));
        }
    }
}
