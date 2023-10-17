﻿using Splan.Platform.Domain.Enums;

namespace Splan.Platform.Domain.Employee
{
    public static class EmployeeFactory
    {
        public static Employee Create(string name, string position, string educationalBackground, 
            int contractingRegime, bool coordinator, string rhClassification)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            if (string.IsNullOrWhiteSpace(position))
                throw new ArgumentException($"'{nameof(position)}' cannot be null or whitespace.", nameof(position));

            if (string.IsNullOrWhiteSpace(educationalBackground))
                throw new ArgumentException($"'{nameof(educationalBackground)}' cannot be null or whitespace.", nameof(educationalBackground));

            if (string.IsNullOrWhiteSpace(rhClassification))
                throw new ArgumentException($"'{nameof(rhClassification)}' cannot be null or whitespace.", nameof(rhClassification));
            if(!(contractingRegime >= 1 && contractingRegime <= 6))
                throw new ArgumentException($"'{nameof(contractingRegime)}' cannot be null or whitespace.", nameof(contractingRegime));

            var employee = new Employee()
            {
                Name = name,
                Function = position,
                EducationDegree = educationalBackground,
                ContractRegimeId = contractingRegime,
                IsCoordinator = coordinator,
                Classification = rhClassification
            };

            return employee;
        }
    }
}
