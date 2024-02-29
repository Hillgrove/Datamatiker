
public abstract class Person
{
    private static int _counter = 1;
    public int Id { get; private set; }
    public string? Name { get; private set; }
    public string? Phone { get; set; }

    public Person(string name, string phone)
    {
        Id = _counter;
        _counter++;
        Name = name;
        Phone = phone;
    }
}

