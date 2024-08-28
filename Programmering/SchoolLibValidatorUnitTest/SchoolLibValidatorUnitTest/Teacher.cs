
namespace SchoolLibValidatorUnitTest
{
    public class Teacher
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Salary { get; private set; }

        public Teacher(int id, string name, int salary) 
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public void ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.", nameof(Name));
            }
        }

        public void ValidateSalary()
        {
            if (Salary <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Salary), Salary, "Salary must be a postive value");
            }
        }

        public void Validate()
        {
            ValidateName();
            ValidateSalary();
        }
        
        public override string ToString()
        {
            return $"{Id}: {Name} - Salary: {Salary}";
        }

    }
}
