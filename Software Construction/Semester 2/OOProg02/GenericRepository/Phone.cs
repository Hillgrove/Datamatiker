
public class Phone
{
    public string Model { get; set; }
    public string Brand { get; set; }

    public Phone(string model, string brand)
    {
        Model = model;
        Brand = brand;
    }

    public override string ToString()
    {
        return $"{Brand} just released the new {Model}.";
    }
}