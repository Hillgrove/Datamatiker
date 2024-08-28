
namespace SchoolLibValidatorUnitTest
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Salary { get; set; }

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
                throw new ArgumentOutOfRangeException(nameof(Salary), Salary, "Salary must be a postive value.");
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
