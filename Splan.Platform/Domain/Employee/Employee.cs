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

        public void Update(string name, string position, string educationBackground, ContractingRegime contractingRegime, bool coordinator, string rhClassification)
        {
            if(name is not null)
            {
                Name = name;
            }

            if (name is not null)
            {
                Position = position;
            }

            if (name is not null)
            {
                EducationalBackground = educationBackground;
            }

            if (name is not null)
            {
                ContractingRegime = contractingRegime;
            }

            if (name is not null)
            {
                Coordinator = coordinator;
            }

            if (name is not null)
            {
                RhClassification = rhClassification;
            }
        }
    }
}
