
public class IncidentRepository
{
    public string SupportCenter { get; private set; }
    public int NumberOfSupporters { get; set; }
    public List<Incident> Incidents { get; }

    public IncidentRepository(string supportCenter, int numberOfSupporters)
    {
        SupportCenter = supportCenter;
        NumberOfSupporters = numberOfSupporters;
        Incidents = new List<Incident>();
    }

    public void AddIncident(Incident incident)
    {
        Incidents.Add(incident);
    }

    public override string ToString()
    {
        string s = $"Supportcenter: {SupportCenter} ({NumberOfSupporters} supporters)\n" +
                   $"*************************************************************\n";
        
        foreach (Incident incident in Incidents)
        {
            s += incident.ToString();
            s += "\n";
        }

        return s;
    }

    public void AddCommentToIncident(int incidentId, Comment comment)
    {
        foreach (Incident incident in Incidents)
        {
            if (incident.Id == incidentId)
            {
                incident.AddComment(comment);
            }
        }
    }

    public int OpenIncidents()
    {
        int count = 0;
        foreach(Incident incident in Incidents)
        {
            if (incident.Open)
            {
                count++;
            }
        }
        
        return count;
    }
}

