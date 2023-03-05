using EmployeeVacations.Core;
using EmployeeVacations.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeVacations.Api.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var employees = await _unitOfWork.Employees.GetAll();
            if (employees == null)
            {
                return NotFound("No Employyes");
            }
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _unitOfWork.Employees.GetById(id);
            if (employee == null)
            {
                return BadRequest("Not Found");
            }
            return employee;
        } 

        [HttpGet("employee-vacations")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesWithVacations()
        {
            var employeeVacations = await _unitOfWork.Employees.GetEmployeesWithVacationsAsync();
            if (employeeVacations == null)
            {
                return NotFound("No Employees");
            }
            return Ok(employeeVacations);
        }

        [HttpPost("add-employee")]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {  
            if (employee == null)
            {
                return BadRequest("Error adding employee");
            }
            await _unitOfWork.Employees.Add(employee);
            await _unitOfWork.Complete();
            return Ok(employee);
        }

        [HttpPut("update-employee")]
        public async Task<ActionResult<Employee>> Put(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Error updating employee");
            }
            await _unitOfWork.Employees.Update(employee);
            await _unitOfWork.Complete();
            return Ok(employee);
        }

        [HttpDelete("delete-employee/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _unitOfWork.Employees.Delete(id);
            await _unitOfWork.Complete(); 
            return Ok();
        }

    }
}
