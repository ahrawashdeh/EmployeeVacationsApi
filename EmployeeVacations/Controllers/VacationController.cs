using EmployeeVacations.Api.Controllers;
using EmployeeVacations.Core;
using EmployeeVacations.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace VacationsVacationss.Api.Controllers
{
    public class VacationsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public VacationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Vacations>> GetAll()
        {
            return await _unitOfWork.Vacations.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vacations>> GetById(int id)
        {
            var vacation = await this._unitOfWork.Vacations.GetById(id);
            if (vacation == null)
            {
                return NotFound();
            }
            return vacation;
        }

        [HttpGet("vacationsEmp")]
        public async Task<ActionResult<List<Vacations>>> GetVacationsEmployee()
        {
            return await _unitOfWork.Vacations.GetVacationsAsync();
        }

        [HttpPost("add-Vacations")]
        public async Task<ActionResult<Vacations>> Post(Vacations vacation)
        {
            if (vacation != null)
            {
                var employee = await _unitOfWork.Employees.GetById(vacation.EmployeeId);
                if (employee  == null)
                {
                    return BadRequest("No employee with this Id");
                }
                await _unitOfWork.Vacations.Add(vacation);
                await _unitOfWork.Complete();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("update-vacation")]
        public async Task<ActionResult<Vacations>> Put(Vacations vacation)
        {
            if (vacation != null)
            {
                await this._unitOfWork.Vacations.Update(vacation);
                await this._unitOfWork.Complete();
                return Ok(vacation);
            }
            return BadRequest();
        }

        [HttpDelete("delete-vacation/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _unitOfWork.Vacations.Delete(id);
            await _unitOfWork.Complete();
            return Ok();
        }
    }
}
