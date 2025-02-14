
// Does a validator need validation?
public static class Validator
{
    public static void ValidateString(string name)
    {
        string? trimmedName = name?.Trim();

        if (string.IsNullOrEmpty(trimmedName))
        {
            throw new ArgumentNullException($"Invalid Name: '{name}'. Name must contain at least 2 characters", nameof(name));
        }

        if (trimmedName.Length < 2)
        {
            throw new ArgumentException($"Invalid Name: '{name}'. Name must contain at least 2 characters", nameof(name));
        }
    }
}
