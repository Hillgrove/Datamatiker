
public class Warrior
{
    private string _name;

    public Warrior(string name)
    {
        _name = name;
        Level = 1;
    }

    public string Name { get { return _name; } }
    public int Level { get; private set; }

    public void LevelUp()
    {
        Level++;
    }
}
