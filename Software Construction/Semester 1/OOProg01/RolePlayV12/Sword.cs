
public class Sword
{
    #region Instance fields
    private int _maxDamage;
    private int _minDamage;
    private Random _generator;
    #endregion

    #region Constructor
    public Sword(string name, int minDamage, int maxDamage)
    {
        Name = name;
        _minDamage = minDamage;
        _maxDamage = maxDamage;
        _generator = new Random(Guid.NewGuid().GetHashCode());
    }
    #endregion

    #region Properties
    public string Name { get; }
    #endregion

    #region Methods
    public int DealDamage()
    {
        return _generator.Next(_minDamage, _maxDamage);
    }
    #endregion
}
