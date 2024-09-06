namespace SharedCalculator
{
    /// <summary>
    /// Simple calculator app for addition, subtraction, multiplication and division
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Addition of x and y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Returns x + y</returns>
        public double Add(double x, double y)
        {
            return x + y;
        }

        /// <summary>
        /// Subtraction of y from x
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Returns x - y</returns>
        public double Subtract(double x, double y)
        {
            return x - y;
        }

        /// <summary>
        /// Multiplication of x and y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Returns x * y</returns>
        public double Multiply(double x, double y)
        {
            return x * y;
        }

        /// <summary>
        /// Division of x with y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Returns x / y</returns>
        /// <exception cref="DivideByZeroException">Thrown when y is zero</exception>
        public double Divide(double x, double y)
        {
            return x / y;
        }
    }
}
