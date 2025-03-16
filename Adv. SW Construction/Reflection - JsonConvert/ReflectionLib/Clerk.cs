namespace ReflectionLib
{
    public class Clerk : Person
    {
        public List<string> Skills { get; set; } = [];
        
        public Clerk(string name, int birthYear) 
            : base(name, birthYear)
        {
        }
    }
}
