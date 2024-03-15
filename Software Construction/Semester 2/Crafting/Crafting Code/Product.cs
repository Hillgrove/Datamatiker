
public  class Product
{
    public string Name { get; }

    public Product(string name)
    {
        Validator.ValidateName(name);
        Name = name.Trim().ToTitleCase();
    }
}