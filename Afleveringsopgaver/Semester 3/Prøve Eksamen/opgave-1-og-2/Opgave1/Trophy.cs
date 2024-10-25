

namespace Opgave1
{
    public class Trophy
    {
        public int Id { get; set; }
        public string? Competition { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            // Output example: "Id: 1, Competition: World Cup, Year: 1998"
            return $"Id: {Id}, Competition: {Competition}, Year: {Year}";
        }

        public void ValidateCompetition()
        {
            if (string.IsNullOrWhiteSpace(Competition) || Competition.Length < 3)
            {
                throw new ArgumentException("Competition must be at least 3 characters long and not null or whitespace", nameof(Competition));
            }
        }

        public void ValidateYear()
        {
            if (Year < 1970 || Year > 2024)
            {
                throw new ArgumentException("Year must be between 1970 and 2024", nameof(Year));
            }
        }

        public void Validate()
        {
            ValidateCompetition();
            ValidateYear();
        }
    }
}
