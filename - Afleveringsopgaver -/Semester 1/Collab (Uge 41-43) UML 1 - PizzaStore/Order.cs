
public class Order
{
    #region Instance fields
    private const int DELIVERY_COST = 40;
    private const double VAT = 25;
    #endregion

    #region Properties
    public Customer Customer { get; }
    public Pizza Pizza { get; }
    public DateTime OrderDate { get; }
    public double VATcost
    {
        get
        {
            return Pizza.Price * VAT / 100;
        }
    }
    #endregion

    #region Constructor
    public Order(Customer customer, Pizza pizza)
    {
        Customer = customer;
        Pizza = pizza;
        OrderDate = DateTime.Now;
    }
    #endregion

    #region Methods
    public double CalculateTotalPrice()
    {
        int pizzaCost = Pizza.Price;
        double VATcost = pizzaCost * VAT / 100;
        double totalPrice = pizzaCost + VATcost + DELIVERY_COST;
        return totalPrice;
    }

    public override string ToString()
    {
        return $"Bestilling:\n" +
               $"{Pizza}\n\n" +
               $"Pris:\n" +
               $"Pizza: {Pizza.Price:F2} kr.\n" +
               $"Moms ({VAT}%): {VATcost:F2} kr.\n" +
               $"Levering: {DELIVERY_COST:F2} kr.\n" +
               $"Ialt: {Pizza.Price + VATcost + DELIVERY_COST:F2} kr.\n\n" +
               $"Levering til:\n" +
               $"{Customer.Name}\n" +
               $"{Customer.Address}\n" +
               $"{Customer.PhoneNumber}\n\n" +
               $"Orderdate:\n" +
               $"{OrderDate}";
    }
    #endregion
}