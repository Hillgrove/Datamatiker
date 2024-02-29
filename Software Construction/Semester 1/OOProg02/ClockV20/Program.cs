
PulseGenerator theGenerator = new PulseGenerator();

// Create some Clock objects
Clock danishClock = new Clock("klokken er: ");
Clock englishClock = new Clock("The time is: ", 2);


// Attach the relevant methods from the Clock objects 
// to the Pulse event in theGenerator
theGenerator.Pulse += danishClock.PrintTime;
theGenerator.Pulse += danishClock.Tick;

theGenerator.Pulse += englishClock.PrintTime;
theGenerator.Pulse += englishClock.Tick;

void TheGenerator_Pulse()
{
    throw new NotImplementedException();
}


// Start pulsing... (don't mind the warning about "...not awaited")
theGenerator.Start(1000);

Console.ReadKey();
