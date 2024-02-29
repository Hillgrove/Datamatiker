
public class Incident
{
    private static int _counter = 1;
    public int Id { get; }
    public string? Program { get; }
    public int Severity { get; }
    public string? Description { get; }
    public bool Open { get; private set; }
    public Dictionary<int, Comment> Comments { get; }
    public double?TotalTimeSpent
    { 
        get
        {
            double? totalTime = 0;
            foreach (var comment in Comments.Values)
            {
                totalTime += comment.TimeSpent;
            }
            return totalTime;
        }
    }

    public Customer Customer { get; }

    public Incident(string program, int severity, string description, Customer customer) 
    {
        Id = _counter;
        _counter++;
        Program = program;
        Severity = severity;
        Description = description;
        Open = true;
        Comments = new Dictionary<int, Comment>();
        Customer = customer;
    }

    public override string ToString()
    {
        string s = $"Incident Id: {Id}\n" +
                   $"Customer: {Customer.Name}\n" +
                   $"Program: {Program}\n" +
                   $"Severity: {Severity}\n" +
                   $"Description: {Description}\n" +
                   $"Open: {Open}\n" +
                   $"Timespent: {TotalTimeSpent} min\n";

        foreach (Comment comment in Comments.Values )
        {
            s += comment.ToString();
        }
        
        return s;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment.Id, comment);
    }

    public void Close()
    {
        Open = false;
    }
}

