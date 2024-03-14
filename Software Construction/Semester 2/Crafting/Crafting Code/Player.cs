
public class Player
{
    private Inventory _inventory;
    public string Name { get; }

    public Player(string name)
    {
        Name = name;
        _inventory = new Inventory();
    }

    public bool CanCraft(Recipe recipe)
    {
        return recipe.IsCraftable(_inventory);
    }

    public void AddToInventory(Resource resource, int amount)
    {
        _inventory.Add(resource, amount);
    }
}