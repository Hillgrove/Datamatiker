
namespace SharedCalculator.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        Calculator calculator = new Calculator();

        [TestMethod()]
        [DataRow(0, 0, 0)]
        [DataRow(-1, -1, -2)]
        [DataRow(1, 1, 2)]
        [DataRow(1, -1, 0)]
        [DataRow(1, 2.14, 3.14)]
        public void AddTest(double x, double y, double expected)
        {
            // Act
            double result = calculator.Add(x, y);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [DataRow(0, 0, 0)]
        [DataRow(-1, -1, 0)]
        [DataRow(1, 1, 0)]
        [DataRow(1, -1, 2)]
        [DataRow(2.5, 1.2, 1.3)]
        public void SubtractTest(double x, double y, double expected)
        {
            // Act
            double result = calculator.Subtract(x, y);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [DataRow(0, 0, 0)]
        [DataRow(-1, -1, 1)]
        [DataRow(1, 1, 1)]
        [DataRow(1, -1, -1)]
        [DataRow(2.5, 2, 5)]
        public void MultiplyTest(double x, double y, double expected)
        {
            // Act
            double result = calculator.Multiply(x, y);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [DataRow(-1, -1, 1)]
        [DataRow(1, 1, 1)]
        [DataRow(1, -1, -1)]
        [DataRow(1, 2, .5)]
        public void DivideTest(double x, double y, double expected)
        {
            // Act
            double result = calculator.Divide(x, y);

            // Arrange
            Assert.AreEqual(expected, result);
        }

        public void DivideByZeroTest()
        {
            // Arrange
            Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(1, 0));
        }
    }
}