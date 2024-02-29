
public class Bear : Actor
{
    public Boots BootsToLoot { get; }

    public Bear(string name, int healthPoints, int gold) 
        : base(name, healthPoints)
    {
        GoldOwned = gold;
        BootsToLoot = new Boots("boots description test");
    }

    public override int DealDamage()
    {
        throw new NotImplementedException();
    }
}
