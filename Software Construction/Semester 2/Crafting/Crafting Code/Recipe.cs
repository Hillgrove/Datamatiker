
public class Recipe
{
    private Dictionary<Resource, int> _requiredResources;
    public string Name { get; }

    public Recipe(string name, params (Resource resource, int amount)[] resources)
    {
        Name = name;
        _requiredResources = resources.ToDictionary(pair => pair.resource, pair => pair.amount);
    }

    public bool IsCraftable(Inventory inventory)
    {
        foreach (var (resource,  requiredAmount) in _requiredResources)
        {
            if (!inventory.HasResource(resource, requiredAmount))
            {
                return false;
            }
        }

        return true;
    }
}

