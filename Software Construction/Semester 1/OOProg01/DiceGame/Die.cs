/// <summary>
/// This class represents a single 6-sided die
/// </summary>
public class Die
{
    #region Instance fields
    int _numberOfSides;
    #endregion

    #region Constructor
    public Die(int numberOfSides)
    {
        _numberOfSides = numberOfSides;
        Roll();  // This puts the die in a well-defined state
    }
    #endregion

    #region Properties
    public int FaceValue { get; private set; }
    #endregion

    #region Methods
    /// <summary>
    /// Roll the die: the value will be set to a random number
    /// between 1 and 6 (both included).
    /// </summary>
    public void Roll()
    {
        FaceValue = RandomNumberGenerator.Generate(1, _numberOfSides);
    }
    #endregion
}
