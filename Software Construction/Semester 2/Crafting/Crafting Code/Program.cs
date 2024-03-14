
CraftingManager craftingManager = new CraftingManager();

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

Player p1 = new Player("Lennie");
p1.AddToInventory(wood, 3);
p1.AddToInventory(iron, 5);
p1.AddToInventory(fabric, 2);
p1.AddToInventory(thread, 1);

bool canCraftAxe = craftingManager.IsCraftable(p1, axeRecipe);
bool canCraftGloves = craftingManager.IsCraftable(p1 , glovesRecipe);

Console.WriteLine(canCraftAxe);
Console.WriteLine(canCraftGloves);