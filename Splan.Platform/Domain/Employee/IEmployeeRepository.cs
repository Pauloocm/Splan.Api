
using Splan.Platform.Application.Finances.Dtos;
using Splan.Platform.Domain.Finances;
using Splan.Platform.Domain.Project;

namespace Splan.Platform.Domain.Employee
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee, CancellationToken cancellationToken = default);
        Task<Employee> GetById(Guid projectId, Guid id, CancellationToken cancellationToken = default);
        Task<Employee> GetSingleOrDefaultAsync(Guid projectId, Guid id, CancellationToken cancellationToken = default);
        Task<IList<Employee>> ListAll(Guid projectId, CancellationToken cancellationToken = default);
        Task Delete(Guid projectId, Guid key, CancellationToken cancellationToken = default);

        Task UpdateDatabase(CancellationToken cancellationToken = default);
        

        Task AddProject(Project.Project project, CancellationToken cancellationToken);
        Task<Project.Project> GetProject(Guid projectId, CancellationToken cancellationToken);
        Task<IList<Project.Project>> ListAllProjects(CancellationToken cancellationToken);
        Task DeleteProject(Guid id, CancellationToken cancellationToken);

        Task<IList<FinanceItemDto>> ListRhItens(Guid projectId, CancellationToken cancellationToken);
    }
}
