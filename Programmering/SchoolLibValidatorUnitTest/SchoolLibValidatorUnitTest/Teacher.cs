
namespace SchoolLibValidatorUnitTest
{
    public class Teacher : Person, ITeacher
    {
        public int Salary { get; set; }
        public List<string>? Classes { get; set; }

        public void ValidateSalary()
        {
            if (Salary <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Salary), Salary, "Salary must be a postive value.");
            }
        }

        public void ValidateClasses()
        {
            if (Classes == null)
            {
                throw new ArgumentNullException(nameof(Classes), "Classes must not be null");
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
