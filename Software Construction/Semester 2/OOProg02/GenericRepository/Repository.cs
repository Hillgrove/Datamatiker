
public class Repository<TKey, TValue> where TKey : notnull
{
    private Dictionary<TKey, TValue> _repository;

    public Repository()
    {
        _repository = new Dictionary<TKey, TValue>();
    }

    public int Count 
    { 
        get { return _repository.Count; } 
    }
    
    public List<TValue> All
    {
        get { return _repository.Values.ToList(); }
    }

    public void Insert(TKey key, TValue obj)
    {
        if (!_repository.ContainsKey(key))
        {
            _repository.Add(key, obj);
        }
    }

    public void Delete(TKey key)
    {
        _repository.Remove(key);
    }

    public void PrintAll()
    {
        foreach (var item in All)
        {
            Console.WriteLine(item);
        }
    }
}

