
public class Troll : Actor
{
    public Sword? SwordToLoot { get; }
    public Shield? ShieldToLoot { get; }

    public Troll(string name, int healthPoints)
        :base(name, healthPoints)
    {
        GoldOwned = 35;
        SwordToLoot = new Sword("sword description test");
        ShieldToLoot = null;
    }

    public override int DealDamage()
    {
        throw new NotImplementedException();
    }
}
