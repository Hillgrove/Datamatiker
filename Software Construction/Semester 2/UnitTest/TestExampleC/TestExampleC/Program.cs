
//Console.WriteLine("Nothing to see here, move along to the unit tests! \nI've told you once before...");

CurrencyExchange currencyExchange = new CurrencyExchange();
CurrencyIdentifierRepo currencyIdentifierRepo = new CurrencyIdentifierRepo();

CurrencyIdentifier EUR = new CurrencyIdentifier("EUR");
CurrencyIdentifier USD = new CurrencyIdentifier("USD");
CurrencyIdentifier DKK = new CurrencyIdentifier("DKK");

currencyIdentifierRepo.Add(USD);
currencyIdentifierRepo.Add(EUR);
currencyIdentifierRepo.Add(DKK);

decimal eurToUsdRate = 1.20M;
decimal eurToDkkRate = 7.44M;
decimal usdToDkkRate = 6.19M;
decimal usdToEurRate = 0.92M;

currencyExchange.AddOrUpdateExchangeRate(EUR, USD, eurToUsdRate);
currencyExchange.AddOrUpdateExchangeRate(EUR, DKK, eurToDkkRate);
currencyExchange.AddOrUpdateExchangeRate(USD, DKK, usdToDkkRate);
currencyExchange.AddOrUpdateExchangeRate(USD, EUR, usdToEurRate);


decimal amountFrom = 100;

decimal amountTo = currencyExchange.Exchange(EUR, USD, 100);
Console.WriteLine($"{amountFrom} {EUR.Identifier} is {amountTo} {USD.Identifier}");

amountTo = currencyExchange.Exchange(USD, DKK, 100);
Console.WriteLine($"{amountFrom} {USD.Identifier} is {amountTo} {DKK.Identifier}");

