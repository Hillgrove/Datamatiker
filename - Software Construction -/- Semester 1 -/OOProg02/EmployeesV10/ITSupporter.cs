
public class ITSupporter : Employee
{
    #region Properties
    public string PrimaryWorkArea { get; set; }

    public string AllInformation
    {
        get
        {
            return $"IT-Supporter {Name} works {HoursPerWeek} hours/week, mostly with {PrimaryWorkArea}";
        }
    }
    #endregion

    #region Constructor
    public ITSupporter(string name, int hoursPerWeek, string primaryWorkArea)
        : base(name, hoursPerWeek)
    {
        PrimaryWorkArea = primaryWorkArea;
    }
    #endregion
}