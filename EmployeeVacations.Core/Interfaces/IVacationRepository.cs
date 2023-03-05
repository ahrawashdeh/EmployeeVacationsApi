using EmployeeVacations.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVacations.Core.Interfaces
{
    public interface IVacationRepository : IBaseRepository<Vacations>
    {
        Task<List<Vacations>> GetVacationsAsync();
    }
}
