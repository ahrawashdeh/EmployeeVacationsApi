using System.ComponentModel.DataAnnotations;

namespace EmployeeVacations.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public List<Vacations>? Vacations { get; set; }
    }
}
