
#region Create drinks
using System.Runtime.CompilerServices;
using System.Xml.Linq;

List<Drink> drinks = new List<Drink>();
drinks.Add(new Drink("Cuba Libre", "Rum", 3, "Cola", 20));
drinks.Add(new Drink("Russia Libre", "Vodka", 3, "Cola", 20));
drinks.Add(new Drink("The Day After", "None", 0, "Water", 20));
drinks.Add(new Drink("Red Mule", "Vodka", 3, "Fanta", 20));
drinks.Add(new Drink("Double Straight", "Whiskey", 6, "None", 0));
drinks.Add(new Drink("Pearly Temple", "None", 0, "Sprite", 20));
drinks.Add(new Drink("High Spirit", "Vodka", 6, "Sprite", 20));
drinks.Add(new Drink("Watered Down", "Whiskey", 3, "Water", 3));
drinks.Add(new Drink("Caribbean Gold", "Rum", 6, "Fanta", 20));
drinks.Add(new Drink("Siberian Zone", "Vodka", 6, "None", 0));
#endregion

// Helper function
void Print(IEnumerable<string> list)
{
    foreach (string drink in list)
    {
        Console.WriteLine(drink);
    }
}


// The names of all drinks
Console.WriteLine("The name of all drinks:");
Print(from drink in drinks
      select drink.Name);
Console.WriteLine();

// The names of all drinks without alcohol
Console.WriteLine("The name of all drinks without alchohol:");
Print(from drink in drinks
      where drink.AlcoholicPart == "None"
      select drink.Name);
Console.WriteLine();

// The name, alcohol part and sum for all drinks with alchohol
Console.WriteLine("Print the name, alcohol part and sum for all drinks with alchohol");
var q3 = from drink in drinks
        where drink.AlcoholicPart != "None"
        select new { drink.Name, drink.AlcoholicPart, drink.AlcoholicPartAmount };

foreach (var item in q3)
{
    Console.WriteLine($"{item.Name}, {item.AlcoholicPart} - {item.AlcoholicPartAmount} dl");
}
Console.WriteLine();

// The names of all drinks in alphabetical order.
var q4 = from drink in drinks
         orderby drink.Name
         select drink.Name;

Print(q4);
Console.WriteLine();

// The total amount of alcohol in the drinks.
Console.WriteLine("The total amount of alcohol in the drinks.");
var q5 = (from drink in drinks
         where drink.AlcoholicPart != "None"
         select drink.AlcoholicPartAmount).Sum();  


Console.WriteLine($"{q5} dl");
Console.WriteLine();

// The average amount of alcohol in drinks with alcohol.
Console.WriteLine("The average amount of alcohol in drinks with alcohol.");
var q6 = (from drink in drinks
         where drink.AlcoholicPart != "None"
         select drink.AlcoholicPartAmount).Average();

Console.WriteLine($"{q6} dl");