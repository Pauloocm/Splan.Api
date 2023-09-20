using Splan.Platform.Application.Employee.Commands;
using Splan.Platform.Domain.Employee;

namespace Splan.Platform.Application
{
    public class SplanAppService : ISplanAppService
    {
        private readonly IEmployeeRepository employeesRepository;

        public SplanAppService(IEmployeeRepository employeeRepository)
        {
            employeesRepository = employeeRepository;
        }

        public async Task<Guid> Add(AddEmployeeCommand addEmployeeCommand, CancellationToken cancellationToken = default)
        {
            if (addEmployeeCommand is null)
                throw new ArgumentNullException(nameof(addEmployeeCommand));

            var employee = EmployeeFactory.Create(addEmployeeCommand.Name,addEmployeeCommand.Position, addEmployeeCommand.EducationalBackground,
                addEmployeeCommand.ContractingRegime, addEmployeeCommand.Coordinator, addEmployeeCommand.RhClassification);

            await employeesRepository.AddAsync(employee, cancellationToken);

            return employee.Id;
        }
    }
}
