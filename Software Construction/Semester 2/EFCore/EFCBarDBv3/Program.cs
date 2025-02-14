
Console.WriteLine("Test of IDataService interfaces");
Console.WriteLine();

EFCoreDrinkDataService drinkService = new EFCoreDrinkDataService();
EFCoreIngredientDataService ingredientService = new EFCoreIngredientDataService();

// 1. Printing the Drink and Ingredient tables before changing them
Helpers.PrintList(drinkService.GetAll(), "Pristine drinks");
Helpers.PrintList(ingredientService.GetAll(), "Pristine ingredients");


// 2. Adding 2 new drinks and printing the Drink and Ingredient tables
Drink d1 = new Drink()
{
    Name = "Gin and Tonic",
    AlcoholicPartId = ingredientService.ReadByName("Gin").Id,
    AlcoholicPartAmount = 3,
    NonAlcoholicPartId = ingredientService.ReadByName("Tonic").Id,
    NonAlcoholicPartAmount = 15
};

Drink d2 = new Drink()
{
    Name = "Elefanta",
    AlcoholicPartId = ingredientService.ReadByName("Rum").Id,
    AlcoholicPartAmount = 3,
    NonAlcoholicPartId = ingredientService.ReadByName("Fanta").Id,
    NonAlcoholicPartAmount = 20
};

drinkService.Create(d1);
drinkService.Create(d2);

Helpers.PrintList(drinkService.GetAll(), "Added 2 new drinks");

// 3. Deleting them again, also printing again
drinkService.Delete(d1.Id);
drinkService.Delete(d2.Id);

Helpers.PrintList(drinkService.GetAll(), "Removed the drinks again");
