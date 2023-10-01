using Splan.Platform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Employee.Dtos
{
    public class EmployeeDto
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public string EducationalBackground { get; set; }

        public ContractingRegime ContractingRegime { get; set; }

        public bool Coordinator { get; set; } = false;

        public string RhClassification { get; set; }
    }
}
