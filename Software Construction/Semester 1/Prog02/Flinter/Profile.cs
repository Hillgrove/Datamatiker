
/// <summary>
/// This class represents a person profile,
/// for instance for a dating website
/// </summary>
public class Profile
{
    #region Enumerations
    public enum Gender { Man, Woman, Other };
    public enum EyeColor { Green, Blue, Grey, Brown };
    public enum HairColor { Brown, Black, Blond, Red };
    public enum HeightCategory { VeryShort, Short, Medium, Tall, VeryTall };
    #endregion

    #region Instance fields
    private Gender _gender;
    private EyeColor _eyeColor;
    private HairColor _hairColor;
    private HeightCategory _heightCategory;
    #endregion

    #region Constructor
    public Profile(Gender gender, EyeColor eyeColor, HairColor hairColor, HeightCategory heightCategory)
    {
        _gender = gender;
        _eyeColor = eyeColor;
        _hairColor = hairColor;
        _heightCategory = heightCategory;
    }
    #endregion

    #region Properties
    public string Description
    {
        get
        {
            return $"You got a {_gender} with {_eyeColor} eyes and {_hairColor} hair, who is {HeightDescription}";
        }
    }

    public string HeightDescription
    {
        get
        {
            switch (_heightCategory)
            {
                case HeightCategory.VeryShort:
                    return "Very short";
                case HeightCategory.Short:
                    return "Short";
                case HeightCategory.Medium:
                    return "Medium height";
                case HeightCategory.Tall:
                    return "Tall";
                case HeightCategory.VeryTall:
                    return "Very tall";
                default:
                    return "Unknown height"; // Not strictly needed since we use enums, but C# wants a default.
            }
        }
    }
    #endregion
}
