
public  class Product
{
    public string Name { get; }

    public Product(string name)
    {
        Validator.ValidateString(name);
        Name = name.Trim().ToTitleCase();
    }
}