
public class Employee
{
    public string Name { get; }
    public int HoursPerWeek { get; set; }

    public Employee(string name, int hoursPerWeek) 
    {
        Name = name;
        HoursPerWeek = hoursPerWeek;
    }
}