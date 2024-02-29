
public class ChainLinkDouble
{
    public double Value { get; set; }
    public ChainLinkDouble? Next {  get; set; }

    // Implement ChainLinkDouble here
    public ChainLinkDouble(double value)
    {
        Value = value;
        Next = null;
    }

    public ChainLinkDouble(double value, ChainLinkDouble next)
    {
        Value= value;
        Next = next;
    }
}
