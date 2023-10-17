using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Employee.Commands
{
    public class AddEmployeeCommand
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Function { get; set; }

        [Required]
        public string EducationDegree { get; set; }

        [Required]
        public int HiringRegimeId { get; set; }

        public bool IsCoordinator { get; set; } = false;

        [Required]
        public string Classification { get; set; }
    }
}
