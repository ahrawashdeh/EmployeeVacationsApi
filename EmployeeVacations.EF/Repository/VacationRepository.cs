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
    public class VacationRepository : BaseRepository<Vacations>, IVacationRepository
    {
        private readonly DataContext _dataContext;

        public VacationRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Vacations>> GetVacationsAsync()
        {
            return await _dataContext.Set<Vacations>().Include(e => e.Employee).ToListAsync();
        }
    }
}
