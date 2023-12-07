namespace Splan.Platform.Application.Finances.Commands
{
    public class UpdateRhFinanceCommand
    {
        public Guid EmployeeKey { get; set; }

        public DateTime ContractDateMonth { get; set; }
        public decimal ValuePerHour { get; set; }
        public int HoursWorkedMonth { get; set; }
    }
}
