
public class EvenBetterObjectComparer
{
    public T Largest<T>(T x, T y, T z, IComparer<T> comparer)
    {
        if (comparer == null)
        {
            throw new ArgumentNullException(nameof(comparer), "Comparer cannot be null.");
        }

        // Assume x is the largest
        T max = x;

        if (comparer.Compare(y, max) > 0)
        {
            max = y;
        }

        if (comparer.Compare(z, max) > 0) 
        {
            max = z;
        }

        return max;
    }
}

