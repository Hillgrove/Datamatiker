﻿
Dog d1 = new Dog("King", 25);
Dog d2 = new Dog("Tiny", 95);
Dog d3 = new Dog("Rufus", 36);
Dog d4 = new Dog("Spot", 55);
Dog d5 = new Dog("Daisy", 8);
List<Dog> dogs = new List<Dog> { d1, d2, d3, d4, d5 };

// Print out all Dogs with a weight larger than 40 kg.
Console.WriteLine("All dogs over 40kg");
ConditionalPrint(dogs, d => d.Weight > 40);

// Print out all Dogs with a weight smaller than Rufus' weight.
Console.WriteLine("All dogs with a weight smaller than Rufus");
ConditionalPrint(dogs, d => d.Weight < d3.Weight);


// Print out all Dogs with a name that contains an "i"
Console.WriteLine("Print out all Dogs with a name that contains an \"i\"");
ConditionalPrint(dogs, d => d.Name.Contains("i"));

static void ConditionalPrint<T>(List<T> objects, Predicate<T> pred)
{
    Console.WriteLine();
    foreach (var item in objects.FindAll(pred))
    {
        Console.WriteLine(item);
    }
}