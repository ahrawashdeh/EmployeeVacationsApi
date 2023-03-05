using EmployeeVacations.Core.Interfaces;
using EmployeeVacations.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVacations.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IVacationRepository Vacations { get; }

        Task<int> Complete();
    }
}
