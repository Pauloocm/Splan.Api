namespace Splan.Platform.Domain.Employee
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee, CancellationToken cancellationToken = default);
        Task<Employee> GetById(Guid id, CancellationToken cancellationToken = default);
        Task<Employee> GetSingleOrDefaultAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default);
        Task UpdateDatabase(CancellationToken cancellationToken = default);
        Task Delete(Guid employeeId, CancellationToken cancellationToken = default);
    }
}
