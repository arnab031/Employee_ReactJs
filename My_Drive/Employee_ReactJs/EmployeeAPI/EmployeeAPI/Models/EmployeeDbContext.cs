using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Models
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
    }
}

