using Splan.Platform.Domain.Enums;

namespace Splan.Platform.Domain.Employee
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Function { get; set; }

        public string EducationDegree { get; set; }
        public HiringRegime Type { get; set; }

        public int HiringRegimeId { get; set; }

        public bool IsCoordinator { get; set; }

        public string Classification { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? ContractDate { get; set; }
        public decimal? ValuePerHour { get; set; }

        public Employee()
        {
            Id = Guid.NewGuid();
            Type = (HiringRegime)Enum.Parse(typeof(HiringRegime), ParseEnum.ParseIntToEnum(HiringRegimeId));
        }

        public void Update(string? name, string? position, string? educationBackground, int contractingRegime, bool? coordinator, string? rhClassification)
        {
            if (name is not null)
            {
                Name = name;
            }

            if (position is not null)
            {
                Function = position;
            }

            if (educationBackground is not null)
            {
                EducationDegree = educationBackground;
            }

            if (contractingRegime >= 1 && contractingRegime <= 6)
            {
                Type = (HiringRegime)Enum.Parse(typeof(HiringRegime),ParseEnum.ParseIntToEnum(HiringRegimeId));
            }

            if (coordinator is not null)
            {
                IsCoordinator = (bool)coordinator;
            }

            if (rhClassification is not null)
            {
                Classification = rhClassification;
            }
        }
    }
}
