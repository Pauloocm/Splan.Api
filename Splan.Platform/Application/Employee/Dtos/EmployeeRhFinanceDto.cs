namespace Splan.Platform.Application.Employee.Dtos
{
    public class EmployeeRhFinanceDto
    {
        public Guid EmployeeKey { get; set; }
        public string Name { get; set; }
        public DateTime contractDateMonth { get; set; }
        public decimal ValuePerHour { get; set; }
        public int HoursWorkedMonth { get; set; }

        public static EmployeeRhFinanceDto ToDto(Domain.Employee.Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            var dto = new EmployeeRhFinanceDto()
            {
                EmployeeKey = employee.Key,
                Name = employee.Name,
                HoursWorkedMonth = employee.HoursWorkedMonth,
                ValuePerHour = employee.ValuePerHour,
                contractDateMonth = employee.ContractDate,
            };

            return dto;
        }

        public static IList<EmployeeRhFinanceDto> ToDto(IList<Domain.Employee.Employee> listEmployees)
        {
            if (listEmployees is null)
                return Enumerable.Empty<EmployeeRhFinanceDto>().ToList();

            var rhFinancesDtoList = new List<EmployeeRhFinanceDto>();

            foreach (var employee in listEmployees)
            {
                rhFinancesDtoList.Add(EmployeeRhFinanceDto.ToDto(employee));
            }

            return rhFinancesDtoList;
        }
    }
}
