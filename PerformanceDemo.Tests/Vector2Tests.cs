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
    }
}
