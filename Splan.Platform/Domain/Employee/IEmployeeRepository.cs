namespace Splan.Platform.Domain.Employee
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee, CancellationToken cancellationToken = default);
    }
}
