
namespace SchoolLibValidatorUnitTest
{
    public class Student : Person
    {
        public int Semester {  get; set; }

        public void ValidateSemester()
        {
            if (Semester < 1 || Semester > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(Semester), Semester, "Semester must be between 1 and 7.");
            }
        }

        public override void Validate()
        {
            base.Validate();
            ValidateSemester();
        }

        public override string ToString()
        {
            return base.ToString() + $" - Semester: {Semester}";
        }
    }
}
