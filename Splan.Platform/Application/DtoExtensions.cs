using Splan.Platform.Application.Employee.Dtos;

namespace Splan.Platform.Application
{
    public static class DtoExtensions
    {
        public static RhFinanceDto ToRhFinanceDto(this Domain.Employee.Employee employee)
        {
            if(employee == null) throw new ArgumentNullException(nameof(employee));

            var rhFinanceDto = new RhFinanceDto()
            {
                ContractDateMonth = employee.ContractDate,
                HoursWorkedMonth = employee.HoursWorkedMonth,
                ValuePerHour = employee.ValuePerHour,
            };

            return rhFinanceDto;
        }
    }
}
