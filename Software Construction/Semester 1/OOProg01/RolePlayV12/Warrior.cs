
public class Warrior
{
    #region Instance fields
    private Sword _swordOne;
    private Sword? _swordTwo;
    private double _damageMult;

    #endregion

    #region Constructor
    public Warrior(string name, int hitPoints, double damageMult, Sword swordOne, Sword? swordTwo = null)
    {
        Name = name;
        HitPoints = hitPoints;
        _swordOne = swordOne;
        _swordTwo = swordTwo;
        _damageMult = damageMult;
    }
    #endregion

    #region Properties
    public string Name { get; }

    public int HitPoints { get; private set; }

    public bool Dead { get { return HitPoints <= 0; } }
    #endregion

    #region Methods
    public void ReceiveDamage(int points)
    {
        HitPoints = HitPoints - points;
    }

    public int DealDamage()
    {
        int damage = _swordOne.DealDamage();

        if (_swordTwo != null)
        {
            damage += _swordTwo.DealDamage();
        }
        
        return (int)(damage * _damageMult);

    }

    public string GetInfo()
    {
        return $"{Name} has {HitPoints} hit points ({(Dead ? "dead" : "alive")})";
    }

    public void changeSword(Sword swordOne, Sword? swordTwo = null)
    {
        _swordOne = swordOne;
        _swordTwo = swordTwo;
    }
    #endregion
}
