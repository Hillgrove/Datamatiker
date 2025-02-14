
public class Inventory
{
    private Dictionary<Resource, int> _contents { get; }

    public Inventory()
    {
        _contents = new Dictionary<Resource, int>();
    }

    public void Add(Resource resource, int amount)
    {
        ValidateAmount(amount);
        _contents.Add(resource, amount);
    }

    // TODO
    public void Remove(Resource resource)
    {
        throw new NotImplementedException();
    }

    public bool HasResource(Resource resource, int requiredAmount)
    {
        return _contents.TryGetValue(resource, out int availableAmount) && availableAmount >= requiredAmount;
    }

    public void ValidateAmount(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException($"Invalid amount '{amount}'. Amount must be positive", nameof(amount));
        }
    }    
}
