
public class Player
{
    public string Name { get; }
    private Inventory _inventory { get; }

    public Player(string name)
    {
        Name = name;
        _inventory = new Inventory();
    }

    public void AddToInventory(Resource resource, int amount)
    {
        _inventory.Add(resource, amount);
    }
}