
using System.Diagnostics;

/// <summary>
/// A very simple representation of a car
/// </summary>
public class Car
{
    #region Instance fields
    private string _licensePlate;
    private int _price;

    public static int _carCount = 0;
    public static int _licensePlateUses = 0;
    public static int _priceUses = 0;
    #endregion

    #region Constructor
    public Car(string licensePlate, int price)
    {
        _licensePlate = licensePlate;
        _price = price;
        _carCount++;
    }
    #endregion

    #region Properties
    public string LicensePlate
    {
        get { _licensePlateUses++; return _licensePlate; }
        set { _licensePlate = value; }
    }

    public int Price
    {
        get { _priceUses++; return _price; }
        set { _price = value; }
    }
    #endregion

    public static void PrintUsageStatistics()
    {
        Console.WriteLine($"Cars created: {_carCount}");
        Console.WriteLine($"License Plate uses: {_licensePlateUses}");
        Console.WriteLine($"Price uses: {_priceUses}");
    }
}
