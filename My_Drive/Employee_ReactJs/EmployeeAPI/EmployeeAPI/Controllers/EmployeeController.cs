using System;

using AutoMapper;
using EmployeeAPI.Models;
using EmployeeAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    public class EmployeeController:Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var employees = await employeeRepository.GetEmployees();
            
            return Ok(mapper.Map<List<Employee>>(employees));
        }
        [HttpGet]
        [Route("[controller]/{Id:int}"),ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetEmployeeAsync([FromRoute] int Id)
        {
            var employee = await employeeRepository.GetEmployeeById(Id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map<Employee>(employee));
            }
        }
        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> AddEmployeAsync([FromBody] Employee data)
        {
            var employee = await employeeRepository.AddEmployee(mapper.Map<Employee>(data));
            //return CreatedAtAction(nameof(GetEmployeeAsync), new { Id = employee.Id }, mapper.Map<Employee>(employee));
            return Ok(mapper.Map<Employee>(employee));
        }
        [HttpPut]
        [Route("[controller]/{Id:int}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] int Id, [FromBody] Employee data)
        {
            var employee = await employeeRepository.GetEmployeeById(Id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                var updatedEmployee = await employeeRepository.UpdateEmployee(Id, mapper.Map<Employee>(data));
                if (updatedEmployee != null)
                {
                    return Ok(mapper.Map<Employee>(updatedEmployee));
                }
                
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("[controller]/{Id:int}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] int Id)
        {
            var employee = await employeeRepository.GetEmployeeById(Id);
            if (employee != null)
            {
                await employeeRepository.DeleteEmployee(Id);
                
                return Ok(mapper.Map<Employee>(employee));
                

            }
            return NotFound();
        }
    }
}

