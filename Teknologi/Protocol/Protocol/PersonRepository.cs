
namespace Protocol
{
    internal class PersonRepository
    {
        private List<Person> _persons = new List<Person>();

        // TODO: Implement CRUDs
        public void Create(string[] instruction)
        {
            //string instruction = "create|John Due|Fuglevænget 12, 2000 Frederiksberg|12345678";
            string name = instruction[1];
            string address = instruction[2];
            string phone = instruction[3];
            Person _ = new Person(name, address, phone);
            _persons.Add(_);
            
            Console.WriteLine($"Added:\n{_.ToString()}\n");
        }

        public string Read(string[] instruction)
        {
            //string instruction = "read|0"
            int index = Int32.Parse(instruction[1]);
            Person _ = _persons[index];
            
            Console.WriteLine($"Read index {index}:\n{_.ToString()}\n");
            
            return "Not Implemented";  // TODO: Should it return the person instead?

        }

        public void Update(string[] instruction)
        {
            //string instruction = "update|0|Lars Hansen|Fuglevænget 12, 2860 Søborg|88-888-888";
            int index = Int32.Parse(instruction[1]);
            Person _ = _persons[index];
            
            Console.WriteLine($"Before update:\n{_.ToString()}");
            
            string name = instruction[2];
            string address = instruction[3];
            string phone = instruction[4];
            _.Name = name;
            _.Address = address;
            _.PhoneNumber = phone;

            Console.WriteLine($"\nAfter update:\n{_.ToString()}\n");
        }

        public void Delete(string[] instruction)
        {
            //string instruction = "delete|0|
            int index = Int32.Parse(instruction[1]);
            Person deletedPerson = _persons[index];
            _persons.RemoveAt(index);
            
            Console.WriteLine($"Deleted:\n{deletedPerson}");
        }
    }
}
