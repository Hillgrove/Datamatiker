
public class Warrior
{
    #region Instance fields
    private RandomNumberGenerator _randomNumberGenerator;
    #endregion

    #region Constructor
    public Warrior(string name, int hitpoints)
    {
        Name = name;
        Level = 1;
        Hitpoints = hitpoints;
        _randomNumberGenerator = new RandomNumberGenerator();
    }
    #endregion

    #region Properties
    public string Name { get; }

    public int Level { get; private set; }

    public int Hitpoints { get; private set; }

    public bool Dead { get { return Hitpoints <= 0; } }

    #endregion

    #region Methods
    public void LevelUp()
    {
        Level++;
    }

    public void TakeDamage(int damage)
    {
        Hitpoints -= damage;
    }

    public int DealDamage() 
    {
        return _randomNumberGenerator.RandomNumber();
    }
    #endregion
}
