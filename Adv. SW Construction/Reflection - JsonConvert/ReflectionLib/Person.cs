namespace ReflectionLib
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - BirthYear;
            }
        }

        protected Person(string name, int birthYear)
        {
            Name = name;
            BirthYear = birthYear;
        }
    }
}
