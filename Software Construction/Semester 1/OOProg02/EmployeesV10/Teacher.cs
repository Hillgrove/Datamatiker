
public class Teacher : Employee
{
    #region Properties

    public int PayGrade { get; set; }

    public string AllInformation
    {
        get
        {
            return $"Teacher {Name} works {HoursPerWeek} hours/week, at paygrade {PayGrade}";
        }
    }
    #endregion

    #region Constructor
    public Teacher(string name, int hoursPerWeek, int payGrade)
        : base(name, hoursPerWeek)
    {
        PayGrade = payGrade;
    }
    #endregion
}