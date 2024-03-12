
Resource wood = new Resource("Wood");
Resource iron = new Resource("Iron");
Resource fabric = new Resource("Fabric");
Resource thread = new Resource("Thread");

Recipe axe = new Recipe("Axe",
    (wood, 2),
    (iron, 3),
    (thread, 1));

Recipe gloves = new Recipe("Gloves",
    (fabric, 2),
    (thread, 2));

Player p1 = new Player("Lennie");
p1.Inventory.Add(wood, 3);
p1.Inventory.Add(iron, 5);
p1.Inventory.Add(fabric, 2);
p1.Inventory.Add(thread, 1);

bool craft1 = axe.IsCraftable(p1.Inventory);
bool craft2 = gloves.IsCraftable(p1.Inventory);

Console.WriteLine(craft1);
Console.WriteLine(craft2);