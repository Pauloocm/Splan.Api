using Splan.Platform.Application.Employee.Dtos;
using Splan.Platform.Domain.Dashboard;
using Splan.Platform.Domain.Dashboard.Dtos;

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

        public static DashboardDto ToDashboardDto(this Dashboard dashboard)
        {
            var dashboardDto = new DashboardDto()
            {
                QuantityEmployees = dashboard.QuantityEmployees,
                FinanceItens = dashboard.FinanceItens,
                RemainingDays = dashboard.RemainingDays,
                TotalSpend = dashboard.TotalSpend,
            };

            return dashboardDto;
        }
    }
}
