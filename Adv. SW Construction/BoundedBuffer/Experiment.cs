namespace BoundedBuffer
{
    internal class Experiment
    {
        private static readonly Random _random = new();
        private readonly int _bufferSize;

        public Experiment(int bufferSize)
        {
            _bufferSize = bufferSize;
        }

        private static void Producer(BoundedBuffer<Item> queue)
        {
            Thread.Sleep(_random.Next(10, 150));
            var item = new Item(_random.Next(0, 100));
            queue.Insert(item);
            Console.WriteLine($"Produced: {item}");
        }

        private static void Consumer(BoundedBuffer<Item> queue)
        {
            Thread.Sleep(_random.Next(10, 150));
            var item = queue.Consume();
            Console.WriteLine($"Consumed: {item}");
        }

        public async Task StartAsync()
        {
            var queue = new BoundedBuffer<Item>(_bufferSize);

            List<Task> tasks =
            [
                Task.Run(() => Producer(queue)),
                Task.Run(() => Producer(queue)),
                Task.Run(() => Producer(queue)),
                Task.Run(() => Producer(queue)),
                Task.Run(() => Consumer(queue)),
                Task.Run(() => Consumer(queue))
            ];

            await Task.WhenAll(tasks);

            Console.WriteLine("\nTasks completed.");
        }
    }
}
