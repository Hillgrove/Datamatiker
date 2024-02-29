
public class Comment
{
    private static int _counter = 1;
    public int Id { get; }
    public string? Description { get; }
    public double? TimeSpent { get; }
    public Supporter Supporter { get; }

    public Comment(string description,  double? timeSpent, Supporter supporter)
    {
        Id = _counter;
        _counter++;
        Description = description;
        TimeSpent = timeSpent;
        Supporter = supporter;
    }

    public override string ToString()
    {
        return $"Comment Id: {Id}\n" +
               $"Description: {Description}\n" +
               $"Time Spent: {TimeSpent} min\n" +
               $"By supporter: {Supporter.Name}\n";
    }
}

