
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography.X509Certificates;

namespace LinesLib.Tests
{
    [TestClass()]
    public class LineSegmentTests
    {
        public LineSegment lineSegment = new LineSegment(1, 10);

        [TestMethod()]
        public void ConstructorTest()
        {
            new LineSegment(1, 10);
            LineSegment validLineSegmentTenTen = new LineSegment(10, 10);
            Assert.ThrowsException<ArgumentException>(() => new LineSegment(10, 1));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            string expected = "Linesegment: 1 - 10";

            // Act
            string actual = lineSegment.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(1)]
        public void ContainsTestIntParameterCorrect(int point)
        {
            lineSegment.Contains(point);
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(11)]
        }

        [TestMethod()]
        public void ContainsTestIntParameterFalse()
        {
            Assert.IsFalse(lineSegment.Contains(0));
        }

        [TestMethod()]
        public void ContainsTestObjParameter()
        {
            LineSegment LineSegmentTwoFive = new LineSegment(2, 5);
            LineSegment LineSegmentZeroNine = new LineSegment(0, 9);
            LineSegment LineSegmentFiveEleven = new LineSegment(5, 11);
            LineSegment LinesegmentOneTen = new LineSegment(1, 10);

            Assert.IsTrue(lineSegment.Contains(LineSegmentTwoFive));
            Assert.IsTrue(lineSegment.Contains(LinesegmentOneTen));



        }
    }
}