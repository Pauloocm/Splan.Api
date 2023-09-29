using Splan.Platform.Application.Employee.Commands;
using Splan.Platform.Application.Employee.Dtos;

namespace Splan.Platform.Application
{
    public interface ISplanAppService
    {
        Task<Guid> Add(AddEmployeeCommand addEmployeeCommand, CancellationToken cancellationToken = default);
        Task Update(UpdateEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken = default);
        Task<GetEmployeeCommand> GetById(Guid id);
        Task<EmployeeDto> Get(GetEmployeeCommand getEmployeeCommand, CancellationToken cancellationToken = default);
    }
}
