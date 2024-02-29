
public class Supporter : Person
{
    public string? Education { get; set; }

    public Supporter(string name, string phone, string education)
        : base(name, phone)
    {
        Education = education;
    }
}