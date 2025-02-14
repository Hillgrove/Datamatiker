
Warrior warriorA = new Warrior("Ragnar", 100);
Warrior warriorB = new Warrior("Lagertha", 100);

Console.WriteLine($"Warrior A is called {warriorA.Name}, " +
                  $"is level {warriorA.Level}, " +
                  $"and has {warriorA.Hitpoints} hitpoints");
Console.WriteLine($"Warrior B is called {warriorB.Name}, " +
                  $"is level {warriorB.Level}" +
                  $"and has {warriorB.Hitpoints} hitpoints");


int round = 1;
while (!warriorA.Dead && !warriorB.Dead)
{
    Console.WriteLine();
    Console.WriteLine($"Round {round}:");
    int warriorADamage = warriorA.DealDamage();
    int warriorBDamage = warriorB.DealDamage();
    warriorA.TakeDamage(warriorBDamage);
    warriorB.TakeDamage(warriorADamage);

    Console.WriteLine($"{warriorA.Name} deals {warriorADamage} damage to {warriorB.Name}");
    Console.WriteLine($"{warriorB.Name} deals {warriorBDamage} damage to {warriorA.Name}");

    Console.WriteLine();

    Console.WriteLine($"{warriorA.Name} how has {warriorA.Hitpoints} left.");
    Console.WriteLine($"{warriorB.Name} how has {warriorB.Hitpoints} left.");
    round++;
}

Console.WriteLine();

if (warriorA.Dead && warriorB.Dead)
{
    Console.WriteLine("It's a draw!!! They managed to kill each other.");
}
else if (warriorA.Dead)
{
    Console.WriteLine($"{warriorB.Name} is victorious!!!\n" +
        $"They survived with only {warriorB.Hitpoints} left.");
}
else
{
    Console.WriteLine($"{warriorA.Name} is victorious!!!\n" +
        $"They survived with only {warriorA.Hitpoints} left.");
}
