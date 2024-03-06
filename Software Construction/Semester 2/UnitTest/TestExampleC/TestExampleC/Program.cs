
//Console.WriteLine("Nothing to see here, move along to the unit tests! \nI've told you once before...");

CurrencyExchange currencyExchange = new CurrencyExchange();

currencyExchange.AddCurrencyCross("EURUSD", 1.20M);


decimal amountFrom = 100;
string currencyFrom = "eur";
string currencyTo = "usd";

decimal amountTo = currencyExchange.Exchange("EURUSD", amountFrom);

Console.WriteLine($"{amountFrom} {currencyFrom} is {amountTo} {currencyTo}");