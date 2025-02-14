
public class Customer
{
    public int Id { get; }
    public string Name { get; }
    public string Phone_Number { get; }
    public int Credit { get; }

    public Customer(int id, string name, string phone_Number, int credit)
    {
        Id = id;
        Name = name;
        Phone_Number = phone_Number;
        Credit = credit;
    }

    public override string ToString()
    {
        return $"[{Id, 2}]  {Name, 20} - {Phone_Number} - Credit: {Credit, 5}";
    }
}

