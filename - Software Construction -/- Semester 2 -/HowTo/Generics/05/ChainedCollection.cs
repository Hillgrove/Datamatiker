
public class ChainedCollection<T> : IChainedCollection<T> where T : IHasId
{
    public ChainLink<T>? Start { get; private set; }
    public ChainLink<T>? End { get; private set; }
  
    public bool IsEmpty
    {
        // DONE
        get { return Start == null; } 
    }

    public int Count
    { 
        get { return CountRest(Start); } 
    }

    public ChainedCollection()
    {
        Start = null;
        End = null;
    }

    public void AddStart(T value)
    {
        // DONE
        if (IsEmpty)
        {
            AddFirstLink(value);
        }
        else
        {
            ChainLink<T> newStart = new ChainLink<T>(value, Start);
            Start = newStart;
        }
    }

    public void AddEnd(T value)
    {
        // DONE
        if (IsEmpty)
        {
            AddFirstLink(value);
        }
        else
        {
            ChainLink<T> newEnd = new ChainLink<T>(value);
            End.Next = newEnd;
            End = newEnd;
        }
    }

    public T? Read(int id)
    {
        // DONE
        if (IsEmpty) { return default; }

        ChainLink<T>? link = Start;
        while (link != null)
        {
            if (link.Value.Id == id)
            { 
                return link.Value; 
            }
            
            link = link.Next; 
        }

        return default;
    }

    public List<T> GetAll()
    {
        List<T> list = new List<T>();

        // TODO
        ChainLink<T>? link = Start;
        while (link != null)
        {
            list.Add(link.Value);
            link = link.Next;
        }

        return list;
    }

    #region Private helper methods

    private void AddFirstLink(T value)
    {
        Start = new ChainLink<T>(value);
        End = Start;
    }

    private int CountRest(ChainLink<T>? link)
    {
        if (link == null)
            return 0;

        return 1 + CountRest(link.Next);
    }

    private T? ReadRest(ChainLink<T>? link, int id)
    {
        if (link == null)
            return default;

        if (link.Value.Id == id)
            return link.Value;

        return ReadRest(link.Next, id);
    }

    #endregion
}
