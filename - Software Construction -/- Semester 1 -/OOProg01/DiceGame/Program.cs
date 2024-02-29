DiceCup diceCup = new DiceCup(20);

Console.WriteLine($"Total value of dice: {diceCup.TotalValue()}");

diceCup.Shake();

Console.WriteLine($"Total value of dice: {diceCup.TotalValue()}");