
public class Player
{
    public string Name { get; }
    public Dictionary<Resource, int> Inventory { get; }

    public Player(string name)
    {
        Name = name;
        Inventory = new Dictionary<Resource, int>();
    }

    public void AddToInventory(Resource resource, int amount)
    {
        Inventory.Add(resource, amount);
    }

    public void CraftRecipe(Recipe recipe)
    {   
        // TODO
        throw new NotImplementedException();
    }
}

