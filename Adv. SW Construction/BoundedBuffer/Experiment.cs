namespace BoundedBuffer
{
    internal class Experiment
    {
        private static readonly Random _random = Random.Shared;

        private void Producer(BoundedBuffer<Item> queue)
        {
            while (true)
            {
                Thread.Sleep(_random.Next(100, 250));
                var item = new Item(_random.Next(10000));
                queue.Insert(item);
                Console.WriteLine($"Produced: {item}"); 
            }
        }

        private void Consumer(BoundedBuffer<Item> queue)
        {
            while (true)
            {
                var item = queue.Consume();
                Console.WriteLine($"Consumed: {item}");
                Thread.Sleep(_random.Next(500)); 
            }
        }

        public void Start(int bufferSize, int noOfProducers, int noOfConsumers)
        {
            var queue = new BoundedBuffer<Item>(bufferSize);

            for (int i = 0; i < noOfProducers; i++)
            {
                Task.Run(() => Producer(queue));
            }

            Thread.Sleep(100);
            for (int i = 0; i < noOfConsumers; i++)
            {
                Task.Run(() => Consumer(queue));
            }
        }
    }
}
