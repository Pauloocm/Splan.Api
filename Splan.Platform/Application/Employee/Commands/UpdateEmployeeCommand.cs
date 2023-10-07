using Splan.Platform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Employee.Commands
{
    public class UpdateEmployeeCommand
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string EducationalBackground { get; set; }

        [Required]
        public int ContractingRegime { get; set; }

        public bool Coordinator { get; set; } = false;

        [Required]
        public string RhClassification { get; set; }
    }
}
