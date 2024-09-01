using System.Drawing;
using System.Dynamic;
using System.Net;
using System.Reflection;

namespace JSON_Exercise_1.Models
{
    internal class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public int MonthsEmployed { get; set; }
        public List<string>? JobAreas { get; set; }

        public Employee(string name, int salary, int monthsEmployed, List<string>? jobAreas)
        {
            Name = name;
            Salary = salary;
            MonthsEmployed = monthsEmployed;
            JobAreas = jobAreas;
        }

        public override string ToString()
        {
            var jobInfo = JobAreas != null && JobAreas.Count > 0
                ? string.Join(", ", JobAreas)
                : "No jobinfo available";
            return $"Name: {Name} - Salary: {Salary} - MonthsEmployed: {MonthsEmployed} - JobAreas: {jobInfo}";
        }
    }
}
