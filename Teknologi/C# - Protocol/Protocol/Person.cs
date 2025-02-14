
namespace Protocol
{
    internal class Person
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public Person(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            PhoneNumber = phone;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAddress: {Address}\nPhonenumber: {PhoneNumber}";
        }
    }
}
