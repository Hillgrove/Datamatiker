
public class Player
{
    private Inventory _inventory { get; }
    public string Name { get; }

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