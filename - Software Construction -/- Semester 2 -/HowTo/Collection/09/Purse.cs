
/// <summary>
/// A Purse can contain coins of various types, 
/// and various amounts of each type.
/// </summary>
public class Purse
{
    private Dictionary<CoinType, int> _coins = new Dictionary<CoinType, int>();

    /// <summary>
    /// Return the total value (in kr.) of the Purse content.
    /// </summary>
    public int ValueInKr
    {
        get 
        {
            int total = 0;

            foreach (KeyValuePair<CoinType, int> coinCount in _coins)
            {
                total += ValueOfCoinType(coinCount.Key) * coinCount.Value;
            }

            return total; 
        } 
    }

    /// <summary>
    /// Adds coins to the Purse.
    /// </summary>
    public void AddCoins(CoinType coinType, int noOfCoins)
    {
        // TODO
        if (_coins.ContainsKey(coinType))
        {
            _coins[coinType] += noOfCoins;
        }

        else
        {
            _coins.Add(coinType, noOfCoins);
        }
        
    }

    /// <summary>
    /// Returns the number of coinType coins currently in the purse.
    /// </summary>
    public int GetNoOfCoins(CoinType coinType)
    {
        if (_coins.ContainsKey(coinType))
        {
            return _coins[coinType];
        }

        return 0;
    }

    /// <summary>
    /// Helper method. Use as-is.
    /// </summary>
    private int ValueOfCoinType(CoinType coinType)
    {
        return Convert.ToInt32(coinType);
    }
}
