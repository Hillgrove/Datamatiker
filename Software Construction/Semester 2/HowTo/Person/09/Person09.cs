
// This is the class definition for the class Person
public class Person09
{
    public string Name { get; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double BMI { get { return Weight / (Height * Height); } }
    public bool Underweight { get { return BMI < 18.5; } }
    
    
    public Person09(string name, double height, double weight)
    {
        Name = name;
        Weight = weight;
        Height = height;
    }


    public bool IsUnderweight(double bmiLimit)
    {
        return BMI < bmiLimit;
    }

    public void PrintPersonData()
    {
        Console.WriteLine($"Navn: {Name}");
        Console.WriteLine($"Højde i meter: {Height}");
        Console.WriteLine($"Vægt i kg: {Weight}");
        Console.WriteLine($"BMI: {BMI:F2}");
        Console.WriteLine($"Undervægtig: {Underweight}");
    }
}
