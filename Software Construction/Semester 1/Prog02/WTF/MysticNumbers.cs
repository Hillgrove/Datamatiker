
using System.Numerics;

public static class MysticNumbers
{
    #region Methods
    public static int ThreeNumbers(int a, int b, int c)
    {
        int result;

        if (b > a)
        {
            result = b;
            if (c > b)
            {
                result = c;
            }
        }
        else
        {
            result = a;
            if (c > a)
            {
                result = c;
            }
        }

        return result;
    }

    public static int FourNumbers(int a, int b, int c, int d)
    {
        int highestAB = TwoNumbers(a, b);
        int highestCD = TwoNumbers(c, d);

        return highestAB > highestCD ? highestAB : highestCD;
    }

    public static int TwoNumbers(int a, int b)
    {
        return a > b ? a : b;
    }
    #endregion
}
