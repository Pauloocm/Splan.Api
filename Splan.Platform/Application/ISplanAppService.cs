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
        Task<List<EmployeeDto>> ListEmployees(Guid projectId, CancellationToken cancellationToken = default);
        Task DeleteEmployee(DeleteEmployeeCommand command, Guid projectId, CancellationToken cancellationToken = default);

        Task<Guid> AddPhase(AddPhaseCommand command, CancellationToken cancellationToken = default);
        Task<Phase.Phase> UpdatePhase(UpdatePhaseCommand command, CancellationToken cancellationToken = default);
        Task DeletePhase(DeletePhaseCommand command, CancellationToken cancellationToken = default);
        Task<List<Phase.Phase>> ListAllPhases(CancellationToken cancellationToken = default);

        Task<Guid> AddRhFinance(AddRhFinanceFromEmployee command, Guid projectId, CancellationToken cancellationToken = default);
        Task<List<EmployeeRhFinanceDto>> ListRhFinances(Guid projectId, CancellationToken cancellationToken = default);

        Task<Guid> AddFinanceItem(AddFinanceItemCommand command, Guid projectId, CancellationToken cancellationToken = default);
        Task<List<FinanceItemDto>> ListFinanceItens(CancellationToken cancellationToken = default);

        Task<Guid> AddPdf(IFormFile pdfFile, AddPdfCommand command, CancellationToken cancellationToken = default);
        Task<Domain.Pdf.Pdf> DownloadPdf(Guid pdfIdfication, CancellationToken cancellationToken = default);

        Task<Guid> Add(AddProjectCommand command, CancellationToken cancellationToken = default);
        Task Update(UpdateProjectCommand command, CancellationToken cancellationToken = default);
        Task<List<Project>> List(CancellationToken cancellationToken = default);
        Task Delete(DeleteProjectCommand command, CancellationToken cancellationToken = default);
    }
}
