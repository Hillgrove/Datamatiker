
public abstract class Actor
{
    public string Name { get; }
    public int HealthPoints { get; protected set; }
    public bool Dead { get { return HealthPoints <= 0; } }
    public int GoldOwned { get; set; }

    public Actor(string name, int healthPoints)
    {
        Name = name;
        HealthPoints = healthPoints;
    }

    public virtual void ReceiveDamage(int damagePoints)
    {
        HealthPoints -= damagePoints;
    }

    public abstract int DealDamage();
     
}
