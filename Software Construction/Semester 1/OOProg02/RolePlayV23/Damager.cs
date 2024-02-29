
public class Damager : Character
{
    #region Constructor
    public Damager(string name, int hitPoints, int minDamage, int maxDamage)
        : base(name, hitPoints, minDamage, maxDamage)
    {
    }
    #endregion

    #region Override Section
    protected override int DealDamageModifyChance
    {
        get { return 50; }
    }

    protected override int CalculateModifiedDealDamage(int dealtDamage)
    {
        return base.CalculateModifiedDealDamage(dealtDamage) * (1 + 100 / 100);
    }
    #endregion
}

