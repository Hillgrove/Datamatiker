
double netPriceBook = 30;
double netPriceDVD = 50;
double netPriceGame = 100;
int shipping = 49;
const double TAX = 10;
const int creditcardFeePercent = 2;

int noOfBooksInOrder = 0;
int noOfDVDsInOrder = 12;
int noOfGamesInOrder = 4;

double bruttoPriceBook = netPriceBook + ( netPriceBook / 100 * TAX );
double bruttoPriceDVD = netPriceDVD + ( netPriceDVD / 100 * TAX );
double bruttoPriceGame = netPriceGame + ( netPriceGame / 100 * TAX );

double totalPriceBooks = bruttoPriceBook * noOfBooksInOrder;
double totalPriceDVDs = bruttoPriceDVD * noOfDVDsInOrder;
double totalPriceGames = bruttoPriceGame * noOfGamesInOrder;

double totalPrice = totalPriceBooks + totalPriceDVDs + totalPriceGames + shipping;

double creditFee = totalPrice / 100 * creditcardFeePercent;

Console.WriteLine($"You ordered {noOfBooksInOrder} books, " +
                  $"{noOfDVDsInOrder} DVDs and " +
                  $"{noOfGamesInOrder} games");
Console.WriteLine($"Total cost including tax, shipping and credit card fee: {totalPrice + creditFee} kr.");

