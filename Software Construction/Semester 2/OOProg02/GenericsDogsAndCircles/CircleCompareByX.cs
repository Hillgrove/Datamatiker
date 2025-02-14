
public class CircleCompareByX : IComparer<Circle>
{
    public int Compare(Circle? x, Circle? y)
    {
        if (x.X < y.X) { return -1; }
        if (x.X > y.X) { return 1; }
        return 0;
    }
}