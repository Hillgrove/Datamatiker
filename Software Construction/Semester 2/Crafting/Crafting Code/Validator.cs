
// Does a validator need validation?
public static class Validator
{
    public static void ValidateName(string name)
    {
        string? trimmedName = name?.Trim();

        if (string.IsNullOrEmpty(trimmedName) || trimmedName.Length < 2)
        {
            throw new ArgumentNullException($"Invalid Name: '{name}'. Name must contain at least 2 characters", nameof(name));
        }

        if (!trimmedName.All(char.IsLetter))
        {
            throw new ArgumentException($"Invalid Name: '{name}'. Name must consist of only alphabetic characters", nameof(name));
        }
    }
}
