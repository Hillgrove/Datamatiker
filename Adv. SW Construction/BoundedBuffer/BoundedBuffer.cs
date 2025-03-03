namespace BoundedBuffer
{
    internal class BoundedBuffer<T>
    {
        private readonly Queue<T> _buffer = new();
        private readonly object _lockObj = new();
        private readonly Semaphore _empty;
        private readonly Semaphore _full;

        public BoundedBuffer(int capacity)
        {
            _empty = new Semaphore(capacity, capacity);
            _full = new Semaphore(0, capacity);
        }

        public void Insert(T item)
        {
            _empty.WaitOne(); // wait for space to insert

            lock (_lockObj)
            {
                _buffer.Enqueue(item);
            }

            _full.Release(); // Signal that there is a new item to consume
        }

        public T Consume()
        {
            T item;

            _full.WaitOne(); // Wait for an item to consume

            lock (_lockObj)
            {
                item = _buffer.Dequeue();                
            }

            _empty.Release(); // Signal that there is now space in the buffer
            return item;
        }
    }
}
