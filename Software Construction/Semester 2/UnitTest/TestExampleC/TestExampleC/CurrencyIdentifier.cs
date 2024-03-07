
/// <summary>
/// Represents a currency identifier with specific validation rules.
/// The identifier must be a non-null, non-empty string of exactly three alphabetic characters.
/// </summary>    
public class CurrencyIdentifier
{
    /// <summary>
    /// Gets the validated and normalized currency identifier.
    /// </summary>
    public string Identifier { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CurrencyIdentifier"/> class with a specified identifier.
    /// </summary>
    /// <param name="identifier">The currency identifier string to be validated.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when the identifier is null, empty, or consists of white-space characters only,
    /// is not exactly 3 characters long, or contains non-letter characters.
    /// </exception>
    public CurrencyIdentifier(string identifier)
    {
        string identifierUpper = identifier.ToUpper().Trim();

        if (string.IsNullOrEmpty(identifierUpper))
        {
            throw new ArgumentException("Identifier cannot be null, empty or only white-space characters.", nameof(identifier));
        }

        if (identifierUpper.Length != 3)
        {
            throw new ArgumentException("Identifier needs to be 3 characters long.", nameof(identifier));
        }

        if (!identifierUpper.All(char.IsLetter))
        {
            throw new ArgumentException("Identifier must consist only of alphabetic characters", nameof(identifier));
        }

        Identifier = identifierUpper;
    }
}

