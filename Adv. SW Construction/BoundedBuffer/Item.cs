namespace BoundedBuffer
{
    internal class Item
    {
        public int Id { get; init; }
        public int Value { get; init; }
        private static int _objectsCreated = 0;

        public Item(int value)
        {
            Value = value;
            Id = _objectsCreated++;
        }

        public override string ToString()
        {
            return $"ID: {Id} - Value: {Value}";
        }
    }
}
