
public class Pizza
{
    #region Properties
    public string Name { get; }
    public List<string> Toppings { get; set; }
    public int Price { get; set; }
    #endregion

    #region Construction
    public Pizza(string name, List<string> topping, int price)
    {
        Name = name;
        Toppings = topping;
        if (price > 0)
        {
            Price = price;
        }
        else
        {
            throw new ArgumentException($"Price of {name} cannot be negative");
        }
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        string toppings = Toppings.Count > 0 ? string.Join(", ", Toppings) : "No toppings";
        return $"{Name} med {toppings} - {Price}kr.";
    }
    #endregion
}