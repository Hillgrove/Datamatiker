
namespace ActorRepositoryLib
{
    public class Actor : IActor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BirthYear { get; set; }

        public void ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException(nameof(Name), "Name cannot be null or empty.");
            }

            if (Name.Length < 4)
            {
                throw new ArgumentException("Name must be at least 4 characters long.", nameof(Name));
            }
        }

        public void ValidateBirthYear()
        {
            if (BirthYear < 1820 || BirthYear > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException(nameof(BirthYear), "Birth year must be between 1820 and the current year.");
            }
        }

        public void Validate()
        {
            ValidateName();
            ValidateBirthYear();
        }
    }
}
