
public class Resource
{
    public string Name { get; }

    public Resource(string name)
    {
        Validator.ValidateString(name);
        Name = name.Trim().ToTitleCase();
    }
}
