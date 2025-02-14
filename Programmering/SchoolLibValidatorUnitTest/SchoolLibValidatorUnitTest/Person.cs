
namespace SchoolLibValidatorUnitTest
{
    public class Person : IPerson
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public GenderType Gender { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }

        public void ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.", nameof(Name));
            }
        }

        public virtual void Validate()
        {
            ValidateName();
        }
    }
}
