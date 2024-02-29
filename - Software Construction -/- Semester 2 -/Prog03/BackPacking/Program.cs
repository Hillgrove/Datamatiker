
List<BackPackItem> items = new List<BackPackItem>();

items.Add(new BackPackItem("Rope", (decimal)1.5, 15));
items.Add(new BackPackItem("Water", 2, 30));
items.Add(new BackPackItem("Extra Water", 2, 20));
items.Add(new BackPackItem("Toilet Paper", (decimal)0.5, 8));
items.Add(new BackPackItem("Coffee", (decimal)0.5, 6));
items.Add(new BackPackItem("Mosquito Net", 1, 15));
items.Add(new BackPackItem("Pocket Knife", (decimal)0.3, 10));
items.Add(new BackPackItem("Laptop", 2, 20));
items.Add(new BackPackItem("Fishing Rod", (decimal)2.5, 30));
items.Add(new BackPackItem("Mini Stove", (decimal)1.5, 20));
items.Add(new BackPackItem("Tent", 5, 80));
items.Add(new BackPackItem("Chocolate", (decimal)0.4, 5));
items.Add(new BackPackItem("First Aid Kit", (decimal)1.2, 25));
items.Add(new BackPackItem("Sleeping Bag", 2, 25));
items.Add(new BackPackItem("Food", (decimal)1.5, 20));
items.Add(new BackPackItem("Extra Food", (decimal)1.5, 12));
items.Add(new BackPackItem("SunScreen", 1, 20));

Console.WriteLine("Stupid solution");
IBackPackingSolver solverA = new BackPackingSolverStupid(items, (decimal)15.0);
solverA.Run();

Console.WriteLine();

Console.WriteLine("Smart solution");
IBackPackingSolver solverB = new BackPackingSolverSmart(items, (decimal)15.0);
solverB.Run();