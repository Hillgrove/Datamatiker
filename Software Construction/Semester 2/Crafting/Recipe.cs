
public class Recipe
{
    public string Name { get; }
    public Dictionary<Resource, int> Resources { get; private set; }

    public Recipe(string name, params (Resource resource, int amount)[] resources)
    {
        Name = name;
        Resources = resources.ToDictionary(pair => pair.resource, pair => pair.amount);
    }

    public bool IsCraftable(Player player)
    {
        foreach (var resource in Resources)
        {
            if (!player.Inventory.ContainsKey(resource.Key) || player.Inventory[resource.Key] < resource.Value)
            {
                return false;
            }
        }
        return true;
    }
}

