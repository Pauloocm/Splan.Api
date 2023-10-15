using Splan.Platform.Domain.Enums;

namespace Splan.Platform.Application.Employee.Dtos
{
    public class EmployeeDto
    {
        public Guid employeeId { get; set; }
        public string Name { get; set; }

        public string Position { get; set; }

        public string EducationalBackground { get; set; }

        public new HiringRegime ContractRegime { get; set; }

        public bool Coordinator { get; set; } = false;

        public string RhClassification { get; set; }


        public static EmployeeDto ToDto(Guid employeeId, string name, string position, string educationBackground, int contractingRegimeId,
            bool coordinator, string rhClassification)
        {

            var dto = new EmployeeDto()
            {
                employeeId = employeeId,
                Name = name,
                Position = position,
                EducationalBackground = educationBackground,
                ContractRegime = (HiringRegime)Enum.Parse(typeof(HiringRegime), ParseEnum.ParseIntToEnum(contractingRegimeId)),
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
                employeeId = employee.Id,
                Name = employee.Name,
                Position = employee.Position,
                EducationalBackground = employee.EducationalBackground,
                ContractRegime = (HiringRegime)Enum.Parse(typeof(HiringRegime), ParseEnum.ParseIntToEnum(employee.ContractRegimeId)),
                Coordinator = employee.Coordinator,
                RhClassification = employee.RhClassification
            };

            return dto;
        }

        public static List<EmployeeDto> ToDto(List<Splan.Platform.Domain.Employee.Employee> listEmployees)
        {
            if (listEmployees is null)
                return Enumerable.Empty<EmployeeDto>().ToList();


            var dtoList = new List<EmployeeDto>();

            foreach (var employee in listEmployees)
            {
                dtoList.Add(EmployeeDto.ToDto(employee));
            }

            return dtoList;
        }
    }
}
