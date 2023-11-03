using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Employee.Commands
{
    public class AddRhFinanceFromEmployee
    {
        [Required]
        public Guid Key { get; set; }

        [Required]
        public DateTime ContractDateMonth { get; set; }

        [Required]
        public decimal ValuePerHour { get; set; }

        [Required]
        public int HoursWorkedMonth { get; set; }
    }
}
