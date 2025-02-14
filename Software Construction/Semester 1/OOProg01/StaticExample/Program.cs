
// ListMethods test
List<int> aList = new List<int> { 23, 86, 51, 11, 39 };

int smallest = ListMethods.FindSmallestNumber(aList);
Console.WriteLine($"The smallest number in the list is : {smallest}");

int average = ListMethods.FindAverage(aList);
Console.WriteLine($"The average of the list is : {average}");

Car car1 = new Car("ABCD", 123);
Car car2 = new Car("EFGH", 234);
Car car3 = new Car("IJKL", 345);

string licensePlate = car1.LicensePlate;
licensePlate = car1.LicensePlate;
licensePlate = car1.LicensePlate;

int price = car2.Price;

Car.PrintUsageStatistics();