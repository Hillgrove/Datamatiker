namespace ReflectionLib
{
    public class Manager : Person
    {
        public List<Person> Employees { get; set; } = [];

        public Manager(string name, int birthyear) : base(name, birthyear)
        {
        }
    }
}
