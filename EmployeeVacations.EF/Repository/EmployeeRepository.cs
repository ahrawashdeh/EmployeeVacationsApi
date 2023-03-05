using EmployeeVacations.Core.Interfaces;
using EmployeeVacations.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVacations.EF.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly DataContext _dataContext;

        public EmployeeRepository(DataContext dataContext) : base(dataContext) 
        {
            _dataContext = dataContext;
        }
      
        public async Task<List<Employee>> GetEmployeesWithVacationsAsync()
        {
            return await _dataContext.Set<Employee>().Include(e => e.Vacations).ToListAsync();
        }
    }
}
