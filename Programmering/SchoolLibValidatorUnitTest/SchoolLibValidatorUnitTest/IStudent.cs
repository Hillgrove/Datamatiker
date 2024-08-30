namespace SchoolLibValidatorUnitTest
{
    public interface IStudent
    {
        int Semester { get; set; }

        string ToString();
        void Validate();
        void ValidateSemester();
    }
}