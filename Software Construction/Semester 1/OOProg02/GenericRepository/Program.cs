///<Assigment>
/// 1. Examine the implementation of CarRepository and EmployeeRepository. Take note of the similarities and 
///    differences between the classes.
/// 
/// 2. There is currently no repository class for Computer.The next step is therefore to create a repository 
///    class for storing Computer objects.You can choose between two paths:
///      a.The Path of Darkness: Create a class named ComputerRepository, copy/paste code from one of the existing 
///      repository classes into the new class, and modify it to be able to handle Computer objects. Add code to 
///      Program.cs to test your new class.
/// 
///      b.The Path of Light: Create a type-parameterized class named Repository, which can be used for any domain 
///      class. Rewrite the code in Program.cs to use the new class for all three domain classes.
///
/// 3. We now also want to be able to print out the content of(i.e.the objects stored in) a repository.Add this 
///    functionality to your repository class(es) by adding a method named PrintAll, and use it to print out the 
///    content of all three repositories.
/// 
/// 4. We now also want to be able to retrieve the number of objects stored in a repository. Add this functionality 
///    to your repository class(es) by adding a property named Count.
/// 
/// 5. Add a new domain class Phone, and repeat steps 2, 3 and 4 again. If you chose the Path of Darkness, feel 
///    free to reconsider your allegiance…
///</Assigment>

#region Car Repository
//CarRepository cars = new CarRepository();
Repository<string, Car> cars = new Repository<string, Car>();

Car c1 = new Car("AB 12 345", 80000);
Car c2 = new Car("CD 34 456", 65000);
Car c3 = new Car("EF 56 567", 28000);

cars.Insert(c1.LicensePlate, c1);
cars.Insert(c2.LicensePlate, c2);
cars.Insert(c3.LicensePlate, c3);
#endregion

#region Employees Repository
//EmployeeRepository employees = new EmployeeRepository();
Repository<string, Employee> employees = new Repository<string, Employee>();

Employee e1 = new Employee("Allan", 1962);
Employee e2 = new Employee("Bente", 1975);
Employee e3 = new Employee("Carlo", 1973);

employees.Insert(e1.Name, e1);
employees.Insert(e2.Name, e2);
employees.Insert(e3.Name, e3);
#endregion

#region Computer Repository
Repository<string, Computer> computers = new Repository<string, Computer>();

Computer cp1 = new Computer("12345", "Hilldesk");
Computer cp2 = new Computer("67890", "Hilltop");
Computer cp3 = new Computer("666", "Hillphone");

computers.Insert(cp1.SerialNo, cp1);
computers.Insert(cp2.SerialNo, cp2);
computers.Insert(cp3.SerialNo, cp3);
#endregion

#region Phone Repository
Repository<string, Phone> phones = new Repository<string, Phone>();

Phone p1 = new Phone("Galaxy S8", "Samsung");
Phone p2 = new Phone("3310", "Nokia");

phones.Insert(p1.Model, p1);
phones.Insert(p2.Model, p2);
#endregion

cars.PrintAll();
Console.WriteLine();
employees.PrintAll();
Console.WriteLine();
computers.PrintAll();
Console.WriteLine();
phones.PrintAll();
Console.WriteLine();

Console.WriteLine($"Number of cars: {cars.Count}");
Console.WriteLine($"Number of employees: {employees.Count}");
Console.WriteLine($"Number of computers: {computers.Count}");
Console.WriteLine($"Number of phones: {phones.Count}");