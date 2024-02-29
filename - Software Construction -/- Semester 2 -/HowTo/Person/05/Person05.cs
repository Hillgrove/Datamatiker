
// This is the class definition for the class Person
public class Person05
{
    // Update the constructor definition
    public Person05(string name, double height, double weight)
    {
        // Update the initialization here
        Name = name;
        Height = height;
        Weight = weight;
    }

    public string Name { get; }
    // Add two new properties here
    public double Height { get; set; }
    public double Weight { get; set; }
}
