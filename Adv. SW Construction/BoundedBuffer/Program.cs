using BoundedBuffer;

var experiment = new Experiment(100);
await experiment.StartAsync();


Console.Write("Press any key to continue.");
Console.ReadKey();
