using Splan.Platform.Application.Employee.Commands;
using Splan.Platform.Application.Employee.Dtos;

namespace Splan.Platform.Application
{
    public interface ISplanAppService
    {
        Task<Guid> Add(AddEmployeeCommand command, CancellationToken cancellationToken = default);
        Task Update(UpdateEmployeeCommand command, CancellationToken cancellationToken = default);
        Task<EmployeeDto> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken = default);
        Task<List<EmployeeDto>> Get(CancellationToken cancellationToken = default);
        Task Delete(DeleteEmployeeCommand command, CancellationToken cancellationToken = default);
    }
}
