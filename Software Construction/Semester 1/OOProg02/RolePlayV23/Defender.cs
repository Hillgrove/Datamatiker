
public class Defender : Character
{
    private int _damageReductionPercent = 50;

    #region Constructor
    public Defender(string name, int hitPoints, int minDamage, int maxDamage) 
        : base(name, hitPoints, minDamage, maxDamage)
    {
    }
    #endregion

    #region Override Section
    protected override int ReceiveDamageModifyChance
    {
        get { return 45; }
    }

    protected override int CalculateModifiedReceivedDamage(int receivedDamage)
    {
        return base.CalculateModifiedReceivedDamage(receivedDamage) * _damageReductionPercent / 100;
    }
    #endregion
}

