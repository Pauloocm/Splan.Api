using Splan.Platform.Domain.Enums;

namespace Splan.Platform.Domain.Employee
{
    public static class EmployeeFactory
    {
        public static Employee Create(string name, string position, string educationalBackground, 
            ContractingRegime contractingRegime, bool coordinator, string rhClassification)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            if (string.IsNullOrWhiteSpace(position))
                throw new ArgumentException($"'{nameof(position)}' cannot be null or whitespace.", nameof(position));

            if (string.IsNullOrWhiteSpace(educationalBackground))
                throw new ArgumentException($"'{nameof(educationalBackground)}' cannot be null or whitespace.", nameof(educationalBackground));

            if (string.IsNullOrWhiteSpace(rhClassification))
                throw new ArgumentException($"'{nameof(rhClassification)}' cannot be null or whitespace.", nameof(rhClassification));

            var employee = new Employee()
            {
                Name = name,
                Position = position,
                EducationalBackground = educationalBackground,
                ContractingRegime = contractingRegime,
                Coordinator = coordinator,
                RhClassification = rhClassification
            };

            return employee;
        }
    }
}
