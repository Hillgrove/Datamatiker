
using RepositoryUsingEFinMVC.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RepositoryUsingEFinMVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //The following variable is going to hold the EmployeeDBContext instance
        private readonly EmployeeDBContext _context;

        //Initialzing the EmployeeDBContext instance
        public EmployeeRepository()
        {
            _context = new EmployeeDBContext();
        }

        //Initializing the EmployeeDBContext instance which it received as an argument
        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        //This method will return all the Employees from the Employee table
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        //This method will return one Employee's information from the Employee table
        //based on the EmployeeID which it received as an argument
        public Employee GetById(int EmployeeID)
        {
            return _context.Employees.Find(EmployeeID);
        }

        //This method will Insert one Employee object into the Employee table
        //It will receive the Employee object as an argument which needs to be inserted into the database
        public void Insert(Employee employee)
        {
            //The State of the Entity is going to be Added State
            _context.Employees.Add(employee);
        }

        //This method is going to update the Employee data in the database
        //It will receive the Employee object as an argument
        public void Update(Employee employee)
        {
            //It will mark the Entity State as Modified
            _context.Entry(employee).State = EntityState.Modified;
        }

        //This method is going to remove the Employee Information from the Database
        //It will receive the EmployeeID as an argument whose information needs to be removed from the database
        public void Delete(int EmployeeID)
        {
            //First, fetch the Employee details based on the EmployeeID id
            Employee employee = _context.Employees.Find(EmployeeID);

            //If the employee object is not null, then remove the employee
            if (employee != null)
            {
                //This will mark the Entity State as Deleted
                _context.Employees.Remove(employee);
            }

        }

        //This method will make the changes permanent in the database
        //That means once we call Insert, Update, and Delete Methods, then we need to call
        //the Save method to make the changes permanent in the database
        public void Save()
        {
            //Based on the Entity State, it will generate the corresponding SQL Statement and
            //Execute the SQL Statement in the database
            //For Added Entity State: It will generate INSERT SQL Statement
            //For Modified Entity State: It will generate UPDATE SQL Statement
            //For Deleted Entity State: It will generate DELETE SQL Statement
            _context.SaveChanges();
        }
        private bool disposed = false;

        //As a context object is a heavy object or you can say time-consuming object
        //So, once the operations are done we need to dispose of the same using Dispose method
        //The EmployeeDBContext class inherited from DbContext class and the DbContext class
        //is Inherited from the IDisposable interface

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}