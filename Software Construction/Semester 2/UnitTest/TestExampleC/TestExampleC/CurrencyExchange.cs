
public class CurrencyExchange
{
    // Implement the logic described in the requirement
    // specification for CurrencyExchange
    public Dictionary<string, decimal> ExchangeRates { get; private set; }


    public CurrencyExchange()
    {
        ExchangeRates = new Dictionary<string, decimal>();
    }


    public void AddCurrencyCross(string currencyCross, decimal exchangeRate)
    {
        string currencyCrossUpper = currencyCross.ToUpper().Trim();

        if (string.IsNullOrWhiteSpace(currencyCrossUpper))
        {
             throw new ArgumentException("Currency cross cannot be null, empty or only consist of whitespace characters.", nameof(currencyCross));
        }

        if (ExchangeRates.ContainsKey(currencyCrossUpper))
        {
            throw new ArgumentException("Currency cross already exists.", nameof(currencyCross));
        }

        if (exchangeRate < 0)
        {
            throw new ArgumentOutOfRangeException("Exchange rate should be postive.", nameof(exchangeRate));
        }

        ExchangeRates.Add(currencyCrossUpper, exchangeRate);
    }


    public decimal Exchange(string currencyCross, decimal amount)
    {
        string currencyCrossUpper = currencyCross.ToUpper().Trim();

        if (string.IsNullOrWhiteSpace(currencyCrossUpper))
        {
            throw new ArgumentException("Currency cross cannot be null, empty or only consist of whitespace characters.", nameof(currencyCross));
        }

        if (!ExchangeRates.ContainsKey(currencyCrossUpper))
        {
            throw new ArgumentException("Currency cross does not exist.", nameof(currencyCross));
        }

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Amount must be positive", nameof(amount));
        }

        decimal exhangeRate = ExchangeRates[currencyCrossUpper];
        return amount * exhangeRate;
    }
    
}
