using System.ComponentModel.DataAnnotations;

namespace EmployeeVacations.Core.Models
{
    public class Vacations
    {
        public int Id { get; set; }
        [Required]
        public DateTime? FromDate { get; set; }
        [Required]
        public DateTime? ToDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
