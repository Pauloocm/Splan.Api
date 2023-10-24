using Splan.Platform.Application.Employee.Commands;
using Splan.Platform.Application.Employee.Dtos;
using Splan.Platform.Application.Phase.Commands;

namespace Splan.Platform.Application
{
    public interface ISplanAppService
    {
        Task<Guid> Add(AddEmployeeCommand command, CancellationToken cancellationToken = default);
        Task Update(UpdateEmployeeCommand command, CancellationToken cancellationToken = default);
        Task<EmployeeDto> GetEmployeeById(Guid id, CancellationToken cancellationToken = default);
        Task<List<EmployeeDto>> Get(CancellationToken cancellationToken = default);
        Task Delete(DeleteEmployeeCommand command, CancellationToken cancellationToken = default);

        Task<Guid> AddPhase(AddPhaseCommand command, CancellationToken cancellationToken = default);
        Task<Phase.Phase> UpdatePhase(UpdatePhaseCommand command, CancellationToken cancellationToken = default);
        Task DeletePhase(DeletePhaseCommand command, CancellationToken cancellationToken = default);
        Task<List<Phase.Phase>> ListAllPhases(CancellationToken cancellationToken = default);
    }
}
