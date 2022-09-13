using System;
using EmployeeAPI.Models;

namespace EmployeeAPI
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int id, Employee employee);
        Task<Employee> DeleteEmployee(int id);
    }
}

