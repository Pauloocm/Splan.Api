using Splan.Platform.Application.Employee.Commands;

namespace Splan.Platform.Application
{
    public interface ISplanAppService
    {
        Task<Guid> Add(AddEmployeeCommand addEmployeeCommand, CancellationToken cancellationToken = default);
    }
}
