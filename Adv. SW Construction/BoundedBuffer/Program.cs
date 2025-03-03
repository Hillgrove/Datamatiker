using BoundedBuffer;

var experiment = new Experiment();
experiment.Start(bufferSize: 5, noOfConsumers: 4, noOfProducers: 2);

Console.ReadLine();
