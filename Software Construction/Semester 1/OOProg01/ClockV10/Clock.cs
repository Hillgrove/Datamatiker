
public class Clock
{
    public Clock()
    {
        Minutes = 0;
    }

    public int Minutes { get; private set; }

    public string GetTime()
    {
        // not yet implemented
        int hours = (Minutes / 60) % 24;
        int minutes = Minutes % 60;
        return $"{hours:D2}:{minutes:D2}";
    }

    public void setTime(int hour, int minute)
    {
        Minutes = hour * 60 + minute;
    }

    public void AdvanceTime()
    {
        Minutes += 1;
    }
}

