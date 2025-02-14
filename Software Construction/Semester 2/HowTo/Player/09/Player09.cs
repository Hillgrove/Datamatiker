
// This is the class definition for the class Player
public class Player09
{
    // Define an instance field named _sword here
    private Sword _sword;
    public string Name { get; }
    public int LifePoints { get; private set; }
    public bool IsDead { get { return LifePoints <= 0; } }

    public Player09(string name, int lifePoints)
    {
        // Initialize the instance field _sword here
        _sword = new Sword(50, 250);
        Name = name;
        LifePoints = lifePoints;
    }

    public void RaiseLifePoints(int points)
    {
        if (points >= 0)
        {
            LifePoints += points;
        }
    }

    public void LowerLifePoints(int points)
    {
        if (points >= 0)
        {
            LifePoints -= points;
        }
    }

    public int DealDamage()
    {
        // Use the instance field _sword here
        return _sword.CalculateDamage();
    }
}
