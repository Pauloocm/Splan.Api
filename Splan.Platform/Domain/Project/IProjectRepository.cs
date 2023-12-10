using Splan.Platform.Application.Phase;
using Splan.Platform.Domain.Finances;

namespace Splan.Platform.Domain.Project
{
    public interface IProjectRepository
    {
        Task AddAsync(Employee.Employee employee, CancellationToken cancellationToken = default);
        Task<Employee.Employee> GetById(Guid employeeId, Guid projectId, CancellationToken cancellationToken = default);
        Task<Employee.Employee> GetSingleOrDefaultAsync(Guid projectId, Guid id, CancellationToken cancellationToken = default);
        Task<IList<Employee.Employee>> ListAll(Guid projectId, CancellationToken cancellationToken = default);
        Task Delete(Guid key, Guid projectId, CancellationToken cancellationToken = default);

        Task UpdateDatabase(CancellationToken cancellationToken = default);


        Task AddProject(Project project, CancellationToken cancellationToken);
        Task<Project> GetProject(Guid projectId, CancellationToken cancellationToken);
        Task<IList<Project>> ListAllProjects(CancellationToken cancellationToken);
        Task DeleteProject(Guid id, CancellationToken cancellationToken);

        Task<IList<FinanceItem>> ListRhItens(Guid projectId, CancellationToken cancellationToken);

        Task AddPdf(Pdf.Pdf pdf, CancellationToken cancellationToken = default);
        Task<Pdf.Pdf> GetPdf(Guid itemId, CancellationToken cancellationToken = default);

        Task AddFinanceItem(FinanceItem financeItem, CancellationToken cancellationToken = default);
        Task<FinanceItem> GetFinanceItem(Guid itemId, Guid projectId, CancellationToken cancellationToken = default);
        Task DeleteFinanceItem(Guid itemId, Guid projectId, CancellationToken cancellationToken = default);
        Task<List<FinanceItem>> ListAllFinanceItens(Guid projectId, CancellationToken cancellationToken = default);


        Task AddPhaseAsync(Phase phase, CancellationToken cancellationToken = default);
        Task<Phase> GetPhaseAsync(Guid phaseId, Guid projectId, CancellationToken cancellationToken = default);
        Task DeletePhase(Guid phaseId, Guid projectId, CancellationToken cancellationToken = default);
        Task<List<Phase>> ListAllPhasesAsync(Guid projectId, CancellationToken cancellationToken = default);

        Task<Dashboard.Dashboard> GetDashboardResults(Guid projectId, CancellationToken cancellationToken = default);
        
    }
}
