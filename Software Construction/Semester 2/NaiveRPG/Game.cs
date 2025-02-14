
public class Game
{
    public void Run()
    {
        Actor playerA = new Player("Sigrid", 250);
       
        // What does the Player own right now?
        Console.WriteLine("The game is starting");
        Console.WriteLine($"{playerA.Name} now owns:");
        Console.WriteLine("---------------------------");
        Console.WriteLine($"Money  :  {((Player)playerA).GoldOwned} gold");
        Console.WriteLine($"Money  :  {playerA.GoldOwned} gold");
        Console.WriteLine($"Boots  :  {(playerA.BootsOwned == null ? "(none)" : playerA.BootsOwned.ToString())}");
        Console.WriteLine($"Shield :  {(playerA.ShieldOwned == null ? "(none)" : playerA.ShieldOwned.ToString())}");
        Console.WriteLine($"Sword  :  {(playerA.SwordOwned == null ? "(none)" : playerA.SwordOwned.ToString())}");
        Console.WriteLine();
        Console.WriteLine();

        Bear aBear = new Bear();
        Troll aTroll = new Troll("Brutus");

        // Kill Bear
        while (!aBear.Dead)
        {
            // Character always deals 7 in damage...
            aBear.ReceiveDamage(7);
        }

        // Loot Bear
        playerA.GoldOwned = playerA.GoldOwned + aBear.GoldOwned;
        if (aBear.BootsToLoot != null)
        {
            playerA.BootsOwned = aBear.BootsToLoot;
        }

        // Kill Troll
        while (!aTroll.Dead)
        {
            // Character always deals 7 in damage...
            aTroll.ReceiveDamage(7);
        }

        // Loot Troll
        playerA.GoldOwned = playerA.GoldOwned + aTroll.GoldOwned;
        if (aTroll.SwordToLoot != null)
        {
            playerA.SwordOwned = aTroll.SwordToLoot;
        }
        if (aTroll.ShieldToLoot != null)
        {
            playerA.ShieldOwned = aTroll.ShieldToLoot;
        }

        // What does the Character own right now?
        Console.WriteLine("The game is over");
        Console.WriteLine($"{playerA.Name} now owns:");
        Console.WriteLine("---------------------------");
        Console.WriteLine($"Money  :  {playerA.GoldOwned} gold");
        Console.WriteLine($"Boots  :  {(playerA.BootsOwned == null ? "(none)" : playerA.BootsOwned.ToString())}");
        Console.WriteLine($"Shield :  {(playerA.ShieldOwned == null ? "(none)" : playerA.ShieldOwned.ToString())}");
        Console.WriteLine($"Sword  :  {(playerA.SwordOwned == null ? "(none)" : playerA.SwordOwned.ToString())}");
        Console.WriteLine();
        Console.WriteLine();
    }
}
