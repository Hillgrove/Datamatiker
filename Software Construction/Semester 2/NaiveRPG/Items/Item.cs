
public abstract class Item
{
    public virtual string Description { get; }

    protected Item(string description)
    {
        Description = description;
    }

    public override string ToString()
    {
        return $"{Description}";
    }
}

