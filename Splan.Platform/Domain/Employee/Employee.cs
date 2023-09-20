using Splan.Platform.Domain.Enums;

namespace Splan.Platform.Domain.Employee
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Position { get; set; }

        public string EducationalBackground { get; set; }

        public ContractingRegime? ContractingRegime { get; set; }

        public bool Coordinator { get; set; }

        public string RhClassification { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? ContractDate { get; set; }
        public decimal? ValuePerHour { get; set; }
        
        public Employee()
        {
            Id = Guid.NewGuid();
        }
    }
}
