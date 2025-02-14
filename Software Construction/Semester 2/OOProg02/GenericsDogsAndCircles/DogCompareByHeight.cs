
public class DogCompareByHeight : IComparer<Dog>
{
    public int Compare(Dog? x, Dog? y)
    {
        if (x.Height < y.Height) { return -1; }
        if (x.Height > y.Height) { return 1; }
        return 0;
    }
}