using EmployeeVacations.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeVacations.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        DbSet<Employee> Employees { get; set; }
        DbSet<Vacations> Vacations { get; set; }
    }
}
