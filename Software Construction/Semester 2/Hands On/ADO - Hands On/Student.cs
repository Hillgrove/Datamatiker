
public class Student
{
    public int Id { get; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public Student(string name, string email)
    {
        Email = email;
        Name = name;
    }

    public override string ToString()
    {
        return $"[{Id:2}] : {Name} - {Email}";
    }
}

