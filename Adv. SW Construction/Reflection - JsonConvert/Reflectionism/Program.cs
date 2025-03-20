using MyJsonLib;
using Newtonsoft.Json;
using ReflectionLib;
using System.Reflection;

Clerk aClerk = new Clerk("Clerkmaster", 1980);
Manager aManager = new Manager("Managerio", 1978);

aClerk.Skills.Add("Clerkiness");
aClerk.Skills.Add("Clericality");
aManager.Employees.Add(aClerk);

void TryReflection(Type? type)
{
    if (type == null || type == typeof(object)) return;

    Console.WriteLine($"Class Name: {type.Name}");
    Console.WriteLine($"Type: {(type.IsInterface ? "Interface" : type.IsAbstract ? "Abstract Class" : "Class")}");

    Console.WriteLine($"\nProperties:");
    foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
    {
        Console.WriteLine($" - {prop.Name} ({prop.PropertyType.Name})");
    }

    Console.WriteLine("\nMethods:");
    foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
    {
        Console.WriteLine($" - {method.Name}");
    }

    Console.WriteLine();
    TryReflection(type.BaseType);
}

//TryReflection(aClerk.GetType());

string clerkSerialized = JsonConvert.SerializeObject(aClerk);
Console.WriteLine(clerkSerialized);

var something = MyJsonConverter.Serialize(aClerk);
Console.WriteLine(something);
