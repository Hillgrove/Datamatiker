
public class Customer : Person
{
    public string? Title { get; set; }

    public Customer(string name, string phone, string title) 
        : base(name, phone)
    {
        Title = title;
    }
}

