using Microsoft.AspNetCore.Http;
using Splan.Platform.Application.Employee.Commands;
using Splan.Platform.Application.Employee.Dtos;
using Splan.Platform.Application.Finances.Commands;
using Splan.Platform.Application.Finances.Dtos;
using Splan.Platform.Application.Pdf.Commands;
using Splan.Platform.Application.Phase.Commands;
using Splan.Platform.Application.Projects.Commands;
using Splan.Platform.Domain.Project;

namespace Splan.Platform.Application
{
    public interface ISplanAppService
    {
        Task<Guid> AddEmployee(AddEmployeeCommand command, Guid projectId, CancellationToken cancellationToken = default);
        Task UpdateEmployee(UpdateEmployeeCommand command, Guid projectId, CancellationToken cancellationToken = default);
        Task<EmployeeDto> GetEmployeeById(Guid employeeId, Guid projectId, CancellationToken cancellationToken = default);
        Task<IList<EmployeeDto>> ListEmployees(Guid projectId, CancellationToken cancellationToken = default);
        Task DeleteEmployee(DeleteEmployeeCommand command, Guid projectId, CancellationToken cancellationToken = default);


        Task<RhFinanceDto> UpdateRhFinance(UpdateRhFinanceCommand command, Guid projectId, CancellationToken cancellationToken = default);
        Task<Guid> AddPhase(AddPhaseCommand command, Guid projectId, CancellationToken cancellationToken = default);
        Task<Phase.Phase> UpdatePhase(UpdatePhaseCommand command, Guid projectId, CancellationToken cancellationToken = default);
        Task DeletePhase(DeletePhaseCommand command, Guid projectId, CancellationToken cancellationToken = default);
        Task<IList<Phase.Phase>> ListAllPhases(Guid projectId, CancellationToken cancellationToken = default);

        Task<Guid> AddRhFinance(AddRhFinanceFromEmployee command, Guid projectId, CancellationToken cancellationToken = default);
        Task<IList<EmployeeRhFinanceDto>> ListRhFinances(Guid projectId, CancellationToken cancellationToken = default);

        Task<Guid> AddFinanceItem(AddFinanceItemCommand command, Guid projectId, CancellationToken cancellationToken = default);
        Task<IList<FinanceItemDto>> ListFinanceItens(Guid projectId, CancellationToken cancellationToken = default);

        Task<Guid> AddPdf(IFormFile pdfFile, AddPdfCommand command, CancellationToken cancellationToken = default);
        Task<Domain.Pdf.Pdf> DownloadPdf(Guid itemId, CancellationToken cancellationToken = default);

        Task<Guid> Add(AddProjectCommand command, CancellationToken cancellationToken = default);
        Task Update(UpdateProjectCommand command, CancellationToken cancellationToken = default);
        Task<IList<Project>> List(CancellationToken cancellationToken = default);
        Task Delete(DeleteProjectCommand command, CancellationToken cancellationToken = default);
        Task UpdateFinanceItem(Guid projectId, UpdateFinanceItemCommand command, CancellationToken cancellationToken);
        Task DeleteFinanceItem(Guid projectId, DeleteFinanceItemCommand command, CancellationToken cancellationToken);
    }
}
