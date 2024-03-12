
public class Recipe
{
    public string Name { get; }
    public Dictionary<Resource, int> Resources { get; private set; }

    public Recipe(string name, params (Resource resource, int amount)[] resources)
    {
        Name = name;
        Resources = resources.ToDictionary(pair => pair.resource, pair => pair.amount);
    }

    public bool IsCraftable(Inventory inventory)
    {
        foreach (var resource in Resources)
        {
            if (!inventory.Contents.ContainsKey(resource.Key) || inventory.Contents[resource.Key] < resource.Value)
            {
                return false;
            }
        }
        return true;
    }
}

