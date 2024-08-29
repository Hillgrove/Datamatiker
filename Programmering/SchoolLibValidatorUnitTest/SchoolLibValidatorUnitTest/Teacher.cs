
namespace SchoolLibValidatorUnitTest
{
    public class Teacher : Person
    {
        public int Salary { get; set; }

        public void ValidateSalary()
        {
            if (Salary <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Salary), Salary, "Salary must be a postive value.");
            }
        }

        public override void Validate()
        {
            base.Validate();
            ValidateSalary();
        }
        
        public override string ToString()
        {
            return base.ToString() + $" - Salary: {Salary}";
        }
    }
}
