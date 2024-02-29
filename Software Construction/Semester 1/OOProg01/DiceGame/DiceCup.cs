/// <summary>
/// This class represents a dice cup containing two dice.
/// </summary>
public class DiceCup
{
    #region Instance fields
    private Die _die1;
    private Die _die2;
    private Die _die3;
    #endregion

    #region Constructor
    public DiceCup(int numberOfSides)
    {
        _die1 = new Die(numberOfSides);
        _die2 = new Die(numberOfSides);
        _die3 = new Die(numberOfSides);
    }
    #endregion

    // Implement a property TotalValue: the sum of 
    // the face values of the dice in the cup
    public int TotalValue()
    {
        return _die1.FaceValue + _die2.FaceValue + _die3.FaceValue;
    }

    // Implement a method Shake: all the dice in the cup should be rolled
    public void Shake()
    {
        _die1.Roll();
        _die2.Roll();
        _die3.Roll();
    }
}
