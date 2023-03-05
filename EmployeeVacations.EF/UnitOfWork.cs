using EmployeeVacations.Core;
using EmployeeVacations.Core.Interfaces;
using EmployeeVacations.Core.Models;
using EmployeeVacations.EF.Repository;

namespace EmployeeVacations.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
            
        public IEmployeeRepository Employees { get; private set; }

        public IVacationRepository Vacations { get; private set; }

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            Employees = new EmployeeRepository(_dataContext);
            Vacations = new VacationRepository(_dataContext);

        }
        public async Task<int> Complete()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
