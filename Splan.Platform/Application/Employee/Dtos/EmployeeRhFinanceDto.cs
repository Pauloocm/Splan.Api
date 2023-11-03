namespace Splan.Platform.Application.Employee.Dtos
{
    public class EmployeeRhFinanceDto
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal ValuePerHour { get; set; }
        public int HoursWorkedMonth { get; set; }
        public string FormatedDate { get; set; }
        public decimal Value { get; set; }

        public EmployeeRhFinanceDto()
        {
            Value = ValuePerHour * HoursWorkedMonth;
        }

        public static EmployeeRhFinanceDto ToDto(Splan.Platform.Domain.Employee.Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            var dto = new EmployeeRhFinanceDto()
            {
                Key = employee.Key,
                Name = employee.Name,
                HoursWorkedMonth = employee.HoursWorkedMonth,
                ValuePerHour = employee.ValuePerHour,
                ContractDate = employee.ContractDate,
                FormatedDate = employee.ContractDate.ToString("MM/yyyy"),
                Value = employee.ValuePerHour * employee.HoursWorkedMonth
            };

            return dto;
        }

        public static List<EmployeeRhFinanceDto> ToDto(List<Splan.Platform.Domain.Employee.Employee> listEmployees)
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
