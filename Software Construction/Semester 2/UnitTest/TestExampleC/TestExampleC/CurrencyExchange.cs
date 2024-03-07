
public class CurrencyExchange
{
    // Implement the logic described in the requirement
    // specification for CurrencyExchange
    public Dictionary<string, decimal> ExchangeRates { get; private set; }


    public CurrencyExchange()
    {
        ExchangeRates = new Dictionary<string, decimal>();
    }


    public void AddCurrencyCross(CurrencyIdentifier currencyFrom, CurrencyIdentifier currencyTo, decimal exchangeRate)
    {
        string currencyCross = currencyFrom.Identifier + currencyTo.Identifier;

        if (ExchangeRates.ContainsKey(currencyCross))
        {
            throw new ArgumentException("Currency cross already exists.", nameof(currencyCross));
        }

        if (exchangeRate < 0)
        {
            throw new ArgumentOutOfRangeException("Exchange rate should be postive.", nameof(exchangeRate));
        }

        ExchangeRates.Add(currencyCross, exchangeRate);
    }


    public decimal Exchange(CurrencyIdentifier currencyFrom, CurrencyIdentifier currencyTo, decimal amount)
    {
        string currencyCross = currencyFrom.Identifier + currencyTo.Identifier;

        if (!ExchangeRates.ContainsKey(currencyCross))
        {
            throw new ArgumentException("Currency cross does not exist.", nameof(currencyCross));
        }

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Amount must be positive", nameof(amount));
        }

        decimal exhangeRate = ExchangeRates[currencyCross];
        return amount * exhangeRate;
    }
    
}
