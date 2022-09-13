using System;
using AutoMapper;
using EmployeeAPI.Models;

namespace EmployeeAPI.Mapper
{
    public class Mappings:Profile
    {
        public Mappings()
        {
            CreateMap<Employee, Employee>().ReverseMap();
        }
    }
}

