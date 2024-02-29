
Warrior warriorA = new Warrior("Ragnar");
Warrior warriorB = new Warrior("Lagertha");

Console.WriteLine($"Warrior A is called {warriorA.Name}");
Console.WriteLine($"Warrior B is called {warriorB.Name}");

warriorA.LevelUp();
warriorA.LevelUp();
warriorB.LevelUp();

Console.WriteLine($"{warriorA.Name} is level {warriorA.Level}");
Console.WriteLine($"{warriorB.Name} is level {warriorB.Level}");