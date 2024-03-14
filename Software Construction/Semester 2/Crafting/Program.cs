
Resource wood = new Resource("Wood");
Resource iron = new Resource("Iron");
Resource fabric = new Resource("Fabric");
Resource thread = new Resource("Thread");

Recipe axeRecipe = new Recipe("Axe",
    (wood, 2),
    (iron, 3),
    (thread, 1));

Recipe glovesRecipe = new Recipe("Gloves",
    (fabric, 2),
    (thread, 2));

Product axeProduct = new Product("Axe", axeRecipe);
Product glovesProduct = new Product("Gloves", glovesRecipe);

Player p1 = new Player("Lennie");
p1.AddToInventory(wood, 3);
p1.AddToInventory(iron, 5);
p1.AddToInventory(fabric, 2);
p1.AddToInventory(thread, 1);

bool craft1 = axeProduct.IsCraftable(p1.Inventory);
bool craft2 = glovesRecipe.IsCraftable(p1.Inventory);


Console.WriteLine(craft1);
Console.WriteLine(craft2);