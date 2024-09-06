
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(10)]
        public void ContainsTestIntParameterCorrect(int point)
        {
            Assert.IsTrue(lineSegment.Contains(point));

        }

        [DataRow(0)]
        [DataRow(11)]
        [TestMethod()]
        public void ContainsTestIntParameterFalse(int point)
        {
            Assert.IsFalse(lineSegment.Contains(point));
        }

        [TestMethod()]
        public void ContainsTestObjParameterCorrect()
        {
            LineSegment lineSegmentTwoFive = new LineSegment(2, 5);
            LineSegment linesegmentOneTen = new LineSegment(1, 10);

            Assert.IsTrue(lineSegment.Contains(lineSegmentTwoFive));
            Assert.IsTrue(lineSegment.Contains(linesegmentOneTen));
        }

        public void ContainsTestObjParameterFalse()
        {
            LineSegment lineSegmentZeroNine = new LineSegment(0, 9);
            LineSegment lineSegmentFiveEleven = new LineSegment(5, 11);

            Assert.IsFalse(lineSegment.Contains(lineSegmentZeroNine));
            Assert.IsFalse(lineSegment.Contains(lineSegmentFiveEleven));
        }
    }
}