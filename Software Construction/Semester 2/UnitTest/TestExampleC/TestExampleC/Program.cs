
//Console.WriteLine("Nothing to see here, move along to the unit tests! \nI've told you once before...");

CurrencyExchange currencyExchange = new CurrencyExchange();
CurrencyIdentifierRepo currencyIdentifierRepo = new CurrencyIdentifierRepo();
CurrencyIdentifier EUR = new CurrencyIdentifier("EUR");
CurrencyIdentifier USD = new CurrencyIdentifier("USD");
currencyIdentifierRepo.Add(USD);
currencyIdentifierRepo.Add(EUR);
currencyExchange.AddCurrencyCross(EUR, USD, 1.20M);

decimal amountFrom = 100;
decimal amountTo = currencyExchange.Exchange(EUR, USD, 100);

Console.WriteLine($"{amountFrom} {EUR.Identifier} is {amountTo} {USD.Identifier}");