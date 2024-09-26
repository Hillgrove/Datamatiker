
using RepositoryUsingEFinMVC.DAL;
using System.Collections.Generic;
namespace RepositoryUsingEFinMVC.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int EmployeeID);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int EmployeeID);
        void Save();
    }
}