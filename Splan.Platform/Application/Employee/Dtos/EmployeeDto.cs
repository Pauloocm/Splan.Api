using Splan.Platform.Domain.Enums;

namespace Splan.Platform.Application.Employee.Dtos
{
    public class EmployeeDto
    {
        public Guid employeeId { get; set; }
        public string Name { get; set; }

        public string Function { get; set; }

        public string EducationDegree { get; set; }

        public new HiringRegime HiringRegimeId { get; set; }

        public bool IsCoordinator { get; set; } = false;

        public string Classification { get; set; }


        public static EmployeeDto ToDto(Guid employeeId, string name, string position, string educationBackground, int contractingRegimeId,
            bool coordinator, string rhClassification)
        {

            var dto = new EmployeeDto()
            {
                employeeId = employeeId,
                Name = name,
                Function = position,
                EducationDegree = educationBackground,
                HiringRegimeId = (HiringRegime)Enum.Parse(typeof(HiringRegime), ParseEnum.ParseIntToEnum(contractingRegimeId)),
                IsCoordinator = coordinator,
                Classification = rhClassification
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
                Function = employee.Function,
                EducationDegree = employee.EducationDegree,
                HiringRegimeId = (HiringRegime)Enum.Parse(typeof(HiringRegime), ParseEnum.ParseIntToEnum(employee.HiringRegimeId)),
                IsCoordinator = employee.IsCoordinator,
                Classification = employee.Classification
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
