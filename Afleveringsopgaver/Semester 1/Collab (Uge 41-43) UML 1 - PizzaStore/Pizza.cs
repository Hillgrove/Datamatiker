
public class Pizza
{
    #region Instance fields
    private Topping? _topping;
    #endregion

    #region Properties
    public string Name { get; }
    public int Price { get; }
    #endregion

    #region Construction
    public Pizza(string name, int price, Topping? topping = null)
    {
        Name = name;
        _topping = topping;
        if (price > 0)
        {
            Price = price;
        }
        else
        {
            // Exceptions are for the developer.
            throw new ArgumentException($"Price of {name} cannot be negative");
        }
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        if ( _topping == null )
        {
            return $"{Name} med tomat og ost - {Price}kr.";
        }
        else
        {
            return $"{Name} med tomat, ost og {_topping} - {Price}kr.";
        }
    }
    #endregion
}