
// Create a PulseGenerator object
PulseGenerator thePulseGenerator = new PulseGenerator();

// Create some Stock objects
Stock stockNFLX = new Stock("NFLX", 20, 1000);
Stock stockMSFT = new Stock("MSFT", 20, 1000);
Stock stockAAPL = new Stock("AAPL", 20, 1000);
Stock stockNVDA = new Stock("NVDA", 20, 1000);
Stock stockGOOG = new Stock("GOOG", 20, 1000);


// Create some StockTrader objects
StockTrader traderMurdoch = new StockTrader("Murdoch", "NFLX", 100, true);
StockTrader traderTudor = new StockTrader("Tudor", "MSFT", 100, true);
StockTrader traderSoros = new StockTrader("Soros", "NFLX", 500, false);
StockTrader traderSeykota = new StockTrader("Seykota", "MSFT", 500, false);
StockTrader traderLeeson = new StockTrader("Leeson", "NFLX", 250, true);

// Update stock prices on every Pulse event
thePulseGenerator.Pulse += stockNFLX.GenerateNewPrice;
thePulseGenerator.Pulse += stockMSFT.GenerateNewPrice;
thePulseGenerator.Pulse += stockAAPL.GenerateNewPrice;
thePulseGenerator.Pulse += stockNVDA.GenerateNewPrice;
thePulseGenerator.Pulse += stockGOOG.GenerateNewPrice;

// Make sure StockTrader objects are notified when
// the price of a stock changes
stockNFLX.PriceChanged += traderMurdoch.DoTrade;
stockNFLX.PriceChanged += traderTudor.DoTrade;
stockNFLX.PriceChanged += traderSoros.DoTrade;
stockNFLX.PriceChanged += traderSeykota.DoTrade;
stockNFLX.PriceChanged += traderLeeson.DoTrade;
stockMSFT.PriceChanged += traderMurdoch.DoTrade;
stockMSFT.PriceChanged += traderTudor.DoTrade;
stockMSFT.PriceChanged += traderSoros.DoTrade;
stockMSFT.PriceChanged += traderSeykota.DoTrade;
stockMSFT.PriceChanged += traderLeeson.DoTrade;
stockAAPL.PriceChanged += traderMurdoch.DoTrade;
stockAAPL.PriceChanged += traderTudor.DoTrade;
stockAAPL.PriceChanged += traderSoros.DoTrade;
stockAAPL.PriceChanged += traderSeykota.DoTrade;
stockAAPL.PriceChanged += traderLeeson.DoTrade;
stockNVDA.PriceChanged += traderMurdoch.DoTrade;
stockNVDA.PriceChanged += traderTudor.DoTrade;
stockNVDA.PriceChanged += traderSoros.DoTrade;
stockNVDA.PriceChanged += traderSeykota.DoTrade;
stockNVDA.PriceChanged += traderLeeson.DoTrade;
stockGOOG.PriceChanged += traderMurdoch.DoTrade;
stockGOOG.PriceChanged += traderTudor.DoTrade;
stockGOOG.PriceChanged += traderSoros.DoTrade;
stockGOOG.PriceChanged += traderSeykota.DoTrade;
stockGOOG.PriceChanged += traderLeeson.DoTrade;


// Print out current stock prices on every Pulse event
thePulseGenerator.Pulse += () =>
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine("Current Stock Prices:");
    Console.WriteLine(stockAAPL);
    Console.WriteLine(stockGOOG);
    Console.WriteLine(stockMSFT);
    Console.WriteLine(stockNFLX);
    Console.WriteLine(stockNVDA);
};


// Print out the entire Trade log on the LastPulse event
thePulseGenerator.LastPulse += () =>
{
    Console.WriteLine("\n----- All stock trades -----");
    foreach (var entry in TradeLog.Log)
    {
        Console.WriteLine(entry);
    }
};

// Start pulsing...
thePulseGenerator.Start(200, 20);

Console.ReadKey();