
public class Resource
{
    public string Name { get; }

    public Resource(string name)
    {
        Validator.ValidateName(name);
        Name = name.Trim().ToTitleCase();
    }
}
