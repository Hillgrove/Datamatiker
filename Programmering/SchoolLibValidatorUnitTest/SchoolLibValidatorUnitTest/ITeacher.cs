
namespace SchoolLibValidatorUnitTest
{
    public interface ITeacher
    {
        List<string>? Classes { get; set; }
        int Salary { get; set; }

        string ToString();
        void Validate();
        void ValidateClasses();
        void ValidateSalary();
    }
}