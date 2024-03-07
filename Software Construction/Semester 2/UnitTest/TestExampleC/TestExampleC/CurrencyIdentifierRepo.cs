
internal class CurrencyIdentifierRepo
{

    private List<CurrencyIdentifier> _currencies;

    public CurrencyIdentifierRepo()
    {
        _currencies = new List<CurrencyIdentifier>();
    }

    public void Add(CurrencyIdentifier currency)
    {
        if (_currencies.Contains(currency))
        {
            throw new ArgumentException("Currency Identifier already exists", nameof(currency));
        }

        _currencies.Add(currency);
    }

    public void Remove(CurrencyIdentifier currency)
    {
        if (! _currencies.Contains(currency))
        {
            throw new ArgumentException("Currency Identifier does not exist", nameof(currency));
        }

        _currencies.Remove(currency);
    }

    public bool Contains(CurrencyIdentifier currency) 
    {
        return _currencies.Contains(currency);
    }


}

