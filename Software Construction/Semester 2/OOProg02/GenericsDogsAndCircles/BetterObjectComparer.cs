
public class BetterObjectComparer<T> where T : IComparable<T>
{
    public T Largest(T objA, T objB, T objC)
    {
        if (objA.CompareTo(objB) > 0)
        {
            return objA.CompareTo(objC) > 0 ? objA : objC;
        }

        return objB.CompareTo(objC) > 0 ? objB : objC;
    }
}

