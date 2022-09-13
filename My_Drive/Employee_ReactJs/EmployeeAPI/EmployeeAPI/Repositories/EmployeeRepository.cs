using System;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee data)
        {
            var employee = await _context.Employee.AddAsync(data);
            await _context.SaveChangesAsync();
            return employee.Entity;

        }
        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = await GetEmployeeById(id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Age = employee.Age;
                await _context.SaveChangesAsync();
                return existingEmployee;
            }
            return null;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employee = await GetEmployeeById(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employee.ToListAsync();
        }

    }
}

