namespace JSON_Exercise_1.Models
{
    internal class Dealership
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public List<Car>? Cars { get; set; }
        public List<Employee>? Employees { get; set; }

        public Dealership(string name, string? address, List<Car>? cars, List<Employee>? employees)
        {
            Name = name;
            Address = address;
            Cars = cars;
            Employees = employees;
        }

        public override string ToString()
        {
            var carsInfo = Cars != null && Cars.Count > 0
                ? string.Join("\n", Cars.Select(car => "- " + car.ToString()))
                : "No cars available";

            var employeesInfo = Employees != null && Employees.Count > 0
                ? string.Join("\n", Employees.Select(employee => "- " + employee.ToString()))
                : "No employees available";

            return $"Dealership Name: {Name}\n" +
                   $"Address: {Address}\n" +
                   $"Cars:\n" +
                   $"{carsInfo}\n" +
                   $"Employees:\n" +
                   $"{employeesInfo}";
        }
    }
}
