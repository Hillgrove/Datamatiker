
#region Create ingredients
Ingredient ingVodka = new Ingredient("Vodka", 15, 40);
Ingredient ingRum = new Ingredient("Rum", 15, 40);
Ingredient ingGin = new Ingredient("Gin", 15, 40);
Ingredient ingTripleSec = new Ingredient("Triple Sec", 20, 30);
Ingredient ingCola = new Ingredient("Cola", 1, 0);
Ingredient ingLimeJuice = new Ingredient("Lime Juice", 2, 0);
Ingredient ingCranJuice = new Ingredient("Cranberry Juice", 2, 0);
Ingredient ingGingerBeer = new Ingredient("Ginger Beer", 2, 4);
Ingredient ingMinWater = new Ingredient("Mineral Water", 1, 0);

List<Ingredient> ingredients = new List<Ingredient>
            {
                ingVodka,
                ingRum,
                ingGin,
                ingTripleSec,
                ingCola,
                ingLimeJuice,
                ingCranJuice,
                ingGingerBeer,
                ingMinWater
            };
#endregion

#region Create cocktails
Cocktail c1 = new Cocktail("Long Island Ice Tea");
c1.AddIngredient("Rum", 3);
c1.AddIngredient("Vodka", 3);
c1.AddIngredient("Gin", 3);
c1.AddIngredient("Cola", 9);

Cocktail c2 = new Cocktail("Moscow Mule");
c2.AddIngredient("Vodka", 4);
c2.AddIngredient("Lime Juice", 3);
c2.AddIngredient("Ginger Beer", 10);

Cocktail c3 = new Cocktail("Cosmopolitan");
c3.AddIngredient("Vodka", 4);
c3.AddIngredient("Triple Sec", 2);
c3.AddIngredient("Lime Juice", 6);
c3.AddIngredient("Cranberry Juice", 6);

Cocktail c4 = new Cocktail("Mojito");
c4.AddIngredient("Rum", 4);
c4.AddIngredient("Mineral Water", 10);
c4.AddIngredient("Lime Juice", 2);

List<Cocktail> cocktails = new List<Cocktail> { c1, c2, c3, c4 };
#endregion

#region Query 1
FormatedPrint("Query 1 - Names of all cocktails", ConsoleColor.Red);
foreach (var name in cocktails.Select(cocktails => cocktails.Name))
{
    Console.WriteLine(name);
}
Console.WriteLine();
#endregion

#region Query 2
FormatedPrint("Query 2 - Name and ingredients of each cocktail", ConsoleColor.Red);

foreach ( var cocktail in cocktails.Select(cocktails => new { cocktails.Name, cocktails.Ingredients } ))
{
    FormatedPrint(cocktail.Name, ConsoleColor.Green);
    foreach (var ingredient in cocktail.Ingredients)
    {
        Console.WriteLine($"{ingredient.Key} - {ingredient.Value} cl");
    }

    Console.WriteLine();
}

Console.WriteLine();
#endregion

#region Query 3
FormatedPrint("Query 3 - Name and ingredients of each cocktail with ingredients over 10% alcohol", ConsoleColor.Red);

var query3 = from cocktail in cocktails
             from ing in cocktail.Ingredients
             join ingredient in ingredients on ing.Key equals ingredient.Name
             where ingredient.AlcoholPercent > 10
             select new 
             { 
                 cocktailName = cocktail.Name, 
                 ingredientName =ingredient.Name
             };

var groupedResults = from result in query3
                     group result by result.cocktailName into cocktailGroup
                     select new
                     {
                         Cocktailname = cocktailGroup.Key,
                         Ingredients = cocktailGroup.Select(i => i.ingredientName).Distinct()
                     };

foreach (var cocktail in groupedResults)
{
    FormatedPrint(cocktail.Cocktailname, ConsoleColor.Green);
    foreach (var ingredient in cocktail.Ingredients)
    {
        Console.WriteLine(ingredient);
    }

    Console.WriteLine();
}
#endregion

#region query 4
FormatedPrint("Query 4 - name and the price each cocktail", ConsoleColor.Red);
var query4 = from cocktail in cocktails
             select new
             {
                 cocktail.Name,
                 Price = (from coIng in cocktail.Ingredients
                          join ing in ingredients
                          on coIng.Key equals ing.Name
                          select coIng.Value * ing.PricePerCl).Sum()
             };

foreach (var cocktail in query4)
{
    Console.WriteLine($"{cocktail.Name} - {cocktail.Price} kr.");
}

Console.WriteLine();
#endregion

#region Query 5
FormatedPrint("Query 5 - name and the alcohol percentage for each cocktail", ConsoleColor.Blue);
var query5 = from cocktail in cocktails
             select new
             {
                 cocktail.Name,
                 AlcoholPercentage = (from coIng in cocktail.Ingredients
                                      join ing in ingredients
                                      on coIng.Key equals ing.Name
                                      select coIng.Value * ing.AlcoholPercent).Sum() /
                                     (from coIng in cocktail.Ingredients
                                      join ing in ingredients
                                      on coIng.Key equals ing.Name
                                      select coIng.Value).Sum()
             };

foreach (var cocktail in query5)
{
    Console.WriteLine($"{cocktail.Name} - {cocktail.AlcoholPercentage:F0}%");
}

Console.WriteLine();
#endregion

#region Helperfunction for printing formatted text
void FormatedPrint(string text, ConsoleColor color)
{
    Console.ForegroundColor = color; // Set text color
    Console.WriteLine(text);
    Console.ResetColor(); // Reset to default color
}
#endregion