using Splan.Platform.Domain.Employee;
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


        public static EmployeeDto ToDto(string name, string position, string educationBackground, ContractingRegime contractingRegime,
            bool coordinator, string rhClassification)
        {
            var dto = new EmployeeDto()
            {
                Name = name,
                Position = position,
                EducationalBackground = educationBackground,
                ContractingRegime = contractingRegime,
                Coordinator = coordinator,
                RhClassification = rhClassification
            };

            return dto;
        }

        public static EmployeeDto ToDto(Splan.Platform.Domain.Employee.Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            var dto = new EmployeeDto()
            {
                Name = employee.Name,
                Position = employee.Position,
                Coordinator = employee.Coordinator,
                RhClassification = employee.RhClassification
            };

            return dto;
        }

        public static List<EmployeeDto> ToDto(List<Splan.Platform.Domain.Employee.Employee> listEmployees)
        {
            if (listEmployees is null)
                throw new ArgumentNullException(nameof(listEmployees));

            var dtoList = new List<EmployeeDto>();

            foreach (var employee in listEmployees)
            {
                dtoList.Add(EmployeeDto.ToDto(employee));
            }

            return dtoList;
        }
    }
}
