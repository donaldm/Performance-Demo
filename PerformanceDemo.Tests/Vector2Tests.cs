using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Utilities;
using NUnit.Framework;

namespace PerformanceDemo.Unit_Tests
{
    [TestFixture]
    public class Vector2Tests
    {
        [TestCase(2, 5, Result=2)]
        [TestCase(3, 2, Result=3)]
        [TestCase(0.5, 0.7, Result=0.5)]
        public double ConstructorSetsXComponent(double a, double b)
        {
            Vector2 testVector = new Vector2(a, b);
            return testVector.X;
        }

        [TestCase(2,5, Result=5)]
        [TestCase(3,2, Result=2)]
        [TestCase(0.5, 0.7, Result=0.7)]
        public double ConstructorSetsYComponent(double a, double b)
        {
            Vector2 testVector = new Vector2(a, b);
            return testVector.Y;
        }

        [TestCase(1,2,3,4)]
        [TestCase(-2.5, -3.5, 2, 3.6)]
        public void TestVectorAddition(double a, double b, double c, double d)
        {
            Vector2 firstVector = new Vector2(a, b);
            Vector2 secondVector = new Vector2(c, d);
            Vector2 resultVector = firstVector + secondVector;
            Assert.AreEqual(resultVector.X, a + c);
            Assert.AreEqual(resultVector.Y, b + d);
        }

        [TestCase(3,4,1,2)]
        [TestCase(-1, -2, -4, -5)]
        [TestCase(-4.5, -3.2, 0, 1.5)]
        public void TestVectorSubtraction(double a, double b, double c, double d)
        {
            Vector2 firstVector = new Vector2(a, b);
            Vector2 secondVector = new Vector2(c, d);
            Vector2 resultVector = firstVector - secondVector;
            Assert.AreEqual(resultVector.X, a - c);
            Assert.AreEqual(resultVector.Y, b - d);
        }
    }
}
