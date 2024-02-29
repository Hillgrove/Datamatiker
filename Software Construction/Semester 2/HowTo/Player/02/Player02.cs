
// This is the class definition for the class Player
public class Player02
{
    public string Name { get; }
    public int LifePoints { get;set; }

    public Player02(string name)
    {
        // Update code block, so LifePoints gets initialized.
        Name = name;
        LifePoints = 100;
    }

    // Add one more constructor
    public Player02(string name, int lifepoints) 
    {
        Name = name;
        LifePoints = lifepoints;
    }

}
