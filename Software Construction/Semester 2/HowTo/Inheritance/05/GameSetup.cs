
public class GameSetup
{
    private static List<string> _lines = new List<string>
    {
        "Hello",
        "What a fine day!",
        "The Fare will begin tomorrow",
        "I'm lost..."
    };

    private List<ICharacter> _characters;

    public GameSetup()
    {
        _characters = new List<ICharacter>();

        // Add some character objects of different types here.
        ICharacter aNpc = new NPC04("NPClaus", 100, 25, _lines);
        ICharacter aPassiveNPC = new PassiveNPC04("Passi-Ve", 200, _lines);
        ICharacter aZombie = new Zombie();
        _characters.Add(aNpc); 
        _characters.Add(aPassiveNPC);
        _characters.Add(aZombie);
    }

    public void AllTalk() 
    {
        Console.WriteLine("Start of conversation");
        // Use a foreach loop to let all characters Talk
        foreach (ICharacter character in _characters)
        {
            Console.WriteLine($"{character.Name} says: \"{character.Talk()}\"");
        }
    }
}

