
public class Topping
{

    #region Properties
    public string Name { get; }
    #endregion

    #region Constructor
    public Topping(string name)
    {
        Name = name;
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        return Name;
    }
    #endregion
}