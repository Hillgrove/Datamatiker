
/// <summary>
/// This class represent an order, containing a
/// number of items (only represented by price)
/// </summary>
public class Order
{
    private const double TaxHighLimitAmount = 40.0;
    private const double TaxHighPercentage = 10.00;
    private const double TaxLowPercentage = 8.00;
    private const double ShippingHighCost = 9.00;
    private const double ShippingLowCost = 5.00;
    private const int ShippingHighCostLimitItems = 3;
    private const double EUTaxPercentage = 2.00;
    private const double EUTaxMinimumAmount = 1.00;

    #region Instance fields
    private List<double> _itemPriceList;
    #endregion

    #region Constructor
    public Order(List<double> itemPriceList)
    {
        _itemPriceList = itemPriceList;
    }
    #endregion

    #region Properties
    public double TotalOrderPrice
    {
        get { return CalculateTotalOrderPrice(); }
    }
    #endregion

    #region Methods
    private double CalculateTotalOrderPrice()
    {
        ApplyTax();
        ApplyShipping();
        ApplyEUTax();
        return TotalCost();
    }

    // Add tax to the price
    private void ApplyTax()
    { 
        for (int index = 0; index < _itemPriceList.Count; index++)
        {
            if (_itemPriceList[index] < TaxHighLimitAmount)
            {
                _itemPriceList[index] *= (1 + (TaxHighPercentage / 100)); // 10 % State tax on cheap items
            }
            else
            {
                _itemPriceList[index] *= (1 + (TaxLowPercentage / 100)); // 8 % State tax on expensive items
            }
        }
    }

    // first three items cost 9 kr. per item for shipping, rest cost 5 kr. per item
    private void ApplyShipping()
    {
        for (int index = 0; index < _itemPriceList.Count; index++)
        {
            _itemPriceList[index] += index < ShippingHighCostLimitItems ? ShippingHighCost : ShippingLowCost;
        }
    }

    // Add 2 % EU tax (after state tax and shipping), however at most 1 kr. per item
    private void ApplyEUTax()
    {
        for (int index = 0; index < _itemPriceList.Count; index++)
        {
            double euTax = _itemPriceList[index] * (EUTaxPercentage / 100) > EUTaxMinimumAmount ? _itemPriceList[index] * EUTaxPercentage / 100 : EUTaxMinimumAmount;
            _itemPriceList[index] += euTax;
        }
    }

    // Find the total cost of the items
    private double TotalCost()
    {
        double totalCost = 0.0;
        for (int index = 0; index < _itemPriceList.Count; index++)
        {
            totalCost = totalCost + _itemPriceList[index];
        }

        return totalCost;
    }   
    #endregion
}
