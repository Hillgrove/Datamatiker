
public class Inventory
{
    private Dictionary<Resource, int> _contents { get; }

    public Inventory()
    {
        _contents = new Dictionary<Resource, int>();
    }

    public void Add(Resource resource, int amount)
    {
        _contents.Add(resource, amount);
    }
}
