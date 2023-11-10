using Microsoft.AspNetCore.Http;
using Splan.Platform.Application.Employee.Commands;
using Splan.Platform.Application.Employee.Dtos;
using Splan.Platform.Application.Finances.Commands;
using Splan.Platform.Application.Finances.Dtos;
using Splan.Platform.Application.Pdf.Commands;
using Splan.Platform.Application.Phase.Commands;

namespace Splan.Platform.Application
{
    public interface ISplanAppService
    {
        Task<Guid> Add(AddEmployeeCommand command, CancellationToken cancellationToken = default);
        Task Update(UpdateEmployeeCommand command, CancellationToken cancellationToken = default);
        Task<EmployeeDto> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken = default);
        Task<List<EmployeeDto>> List(CancellationToken cancellationToken = default);
        Task Delete(DeleteEmployeeCommand command, CancellationToken cancellationToken = default);

        Task<Guid> AddPhase(AddPhaseCommand command, CancellationToken cancellationToken = default);
        Task<Phase.Phase> UpdatePhase(UpdatePhaseCommand command, CancellationToken cancellationToken = default);
        Task DeletePhase(DeletePhaseCommand command, CancellationToken cancellationToken = default);
        Task<List<Phase.Phase>> ListAllPhases(CancellationToken cancellationToken = default);

        Task<Guid> AddRhFinance(AddRhFinanceFromEmployee command, CancellationToken cancellationToken = default);
        Task<List<EmployeeRhFinanceDto>> ListRhFinances(CancellationToken cancellationToken = default);

        Task<Guid> AddFinanceItem(AddFinanceItemCommand command, CancellationToken cancellationToken = default);
        Task<Guid> AddPdf(IFormFile pdfFile, AddPdfCommand command, CancellationToken cancellationToken = default);
        Task<List<FinanceItemDto>> ListFinanceItens(CancellationToken cancellationToken = default);
    }
}
