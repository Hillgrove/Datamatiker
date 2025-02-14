
/// <summary>
/// This class is intended to act as
/// a base class for geometric shapes
/// </summary>
public abstract class Shape
{
    protected Shape(string shapeName)
    {
        ShapeName = shapeName;
    }

    public string ShapeName { get; }
    public abstract double Area { get; }

    public static double FindTotalArea(List<Shape> shapes)
    {
        // This needs to be changed
        double totalArea = 0;
        foreach (Shape s in shapes)
        {
            totalArea += s.Area;
        }
        return totalArea;
    }
}