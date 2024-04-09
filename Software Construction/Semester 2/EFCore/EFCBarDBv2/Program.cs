﻿
using Microsoft.EntityFrameworkCore;
using EFCBarDBv2.ModelsGenerated;

Console.WriteLine("Test of EFCore, two related tables");    
Console.WriteLine();


// 1) Create a context to access the database
using EFCDrinkDBContext context = new EFCDrinkDBContext();

// 2a) Read all drinks from the DB, and print them (should print 10 drinks)
var drinksNoInclude =
    context.Drinks;

Helpers.PrintList(drinksNoInclude, "(without Include)");


// 2b) Read all drinks from the DB, and print them (should print 10 drinks)
var drinksWithInclude =
    context.Drinks
        .Include("AlcoholicPart")
        .Include("NonAlcoholicPart");

Helpers.PrintList(drinksWithInclude, "(with Include)");

// Create new drinks and print them out
Drink d1 = new Drink()
{
    Name = "Gin and Tonic",
    AlcoholicPartId = context.GetIngredientByName("Gin")?.Id,
    AlcoholicPartAmount = 3,
    NonAlcoholicPartId = context.GetIngredientByName("Tonic")?.Id,
    NonAlcoholicPartAmount = 15
};

Drink d2 = new Drink()
{
    Name = "Elefanta",
    AlcoholicPartId = context.GetIngredientByName("Rum")?.Id,
    AlcoholicPartAmount = 3,
    NonAlcoholicPartId = context.GetIngredientByName("Fanta")?.Id,
    NonAlcoholicPartAmount = 20
};

context.Drinks.Add(d1);
context.Drinks.Add(d2);
context.SaveChanges();

Helpers.PrintList(drinksWithInclude, "(with Include)");

context.Drinks.Remove(d1);
context.Drinks.Remove(d2);
context.SaveChanges();

Helpers.PrintList(drinksWithInclude, "(with Include)");