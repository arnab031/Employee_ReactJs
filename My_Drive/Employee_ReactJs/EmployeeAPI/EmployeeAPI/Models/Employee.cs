using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

