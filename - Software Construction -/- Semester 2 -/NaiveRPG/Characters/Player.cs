
public class Player : Actor
{
    public Sword? SwordOwned { get; set; }
    public Shield? ShieldOwned { get; set; }
    public Boots? BootsOwned { get; set; }

    public Player(string name, int healthPoints)
        : base(name, healthPoints)
    {
        GoldOwned = 0;
        SwordOwned = null;
        ShieldOwned = null;
        BootsOwned = null;
    }

    public override int DealDamage()
    {
        throw new NotImplementedException();
    }
}
