
/// <Assignment>
/// 1. Run the program as-is, and observe the result. Can you figure out when the comparisons return true?
/// 2.In the Car class, uncomment the Equals method (only that method), and run the program again. What has changed?
/// 3. Uncomment the rest of the code in the Car class, and run the program again. What has changed?
/// 4. The printing of Car objects is still not very satisfying. In the Car class, override the ToString method, 
/// so that it returns a string giving a reasonable description of the Car object (note that the ToString method 
/// should not call Console.WriteLine; it should only return a string to the caller). Run the program again, 
/// and see what difference it makes.
/// </Assignment>



Car carNo1 = new Car("BJ43009", "Ford", "Mondeo", 120000);
Car carNo2 = new Car("BJ43009", "Ford", "Mondeo", 120000);
Car carNo3 = new Car("BJ43009", "Opel", "Kadett", 55000);
Car carNo4 = carNo3;
Car carNo5 = new Car("ST88711", "Ford", "Mondeo", 120000);

Console.WriteLine();
Console.WriteLine(carNo1);
Console.WriteLine(carNo2);
Console.WriteLine(carNo3);
Console.WriteLine(carNo4);
Console.WriteLine(carNo5);

Console.WriteLine();
Console.WriteLine($"carNo1 is equal to carNo2 : {carNo1.Equals(carNo2)}");
Console.WriteLine($"carNo1 is equal to carNo3 : {carNo1.Equals(carNo3)}");
Console.WriteLine($"carNo1 is equal to carNo4 : {carNo1.Equals(carNo4)}");
Console.WriteLine($"carNo3 is equal to carNo4 : {carNo3.Equals(carNo4)}");
Console.WriteLine($"carNo1 is equal to carNo5 : {carNo1.Equals(carNo5)}");

Console.WriteLine();
Console.WriteLine($"carNo1 == carNo2 : {carNo1 == carNo2}");
Console.WriteLine($"carNo1 == carNo3 : {carNo1 == carNo3}");
Console.WriteLine($"carNo1 == carNo4 : {carNo1 == carNo4}");
Console.WriteLine($"carNo3 == carNo4 : {carNo3 == carNo4}");
Console.WriteLine($"carNo1 == carNo5 : {carNo1 == carNo5}");
