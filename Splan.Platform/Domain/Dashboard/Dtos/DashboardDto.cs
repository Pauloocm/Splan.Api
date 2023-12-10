namespace Splan.Platform.Domain.Dashboard.Dtos
{
    public class DashboardDto
    {
        public int QuantityEmployees { get; set; }
        public int FinanceItens { get; set; }
        public TimeSpan RemainingDays { get; set; }
        public decimal TotalSpend { get; set; }
    }
}
