using Splan.Platform.Application.Employee.Commands;
using Splan.Platform.Application.Employee.Dtos;
using Splan.Platform.Domain.Employee;
using Splan.Platform.Domain.Employee.Exceptions;

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

            var employee = EmployeeFactory.Create(addEmployeeCommand.Name, addEmployeeCommand.Position, addEmployeeCommand.EducationalBackground,
                addEmployeeCommand.ContractingRegime, addEmployeeCommand.Coordinator, addEmployeeCommand.RhClassification);

            await employeesRepository.AddAsync(employee, cancellationToken);

            return employee.Id;
        }

        public async Task<List<EmployeeDto>> Get(CancellationToken cancellationToken = default)
        {
            var employees = await employeesRepository.GetAllAsync(cancellationToken);

            var DtoEmployees = new List<EmployeeDto>();

            foreach (var dto in employees)
            {
                var employeeDto = new EmployeeDto()
                {
                    Name = dto.Name,
                    Position = dto.Position,
                    ContractingRegime = (Domain.Enums.ContractingRegime)dto.ContractingRegime,
                    Coordinator = dto.Coordinator,
                    EducationalBackground = dto.EducationalBackground,
                    RhClassification = dto.RhClassification
                };

                DtoEmployees.Add(employeeDto);
            }

            return DtoEmployees;
        }

        public async Task<GetEmployeeCommand> GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            var result = await employeesRepository.GetById(id);

            if (result is null)
                throw new EmployeeNotFoundException(id);

            var employee = new GetEmployeeCommand()
            {
                Name = result.Name,
                Position = result.Position,
            };

            return employee;
        }

        public async Task Update(UpdateEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken = default)
        {
            var employee = await GetEmployee(updateEmployeeCommand.EmployeeId, cancellationToken);

            employee.Update(updateEmployeeCommand.Name, updateEmployeeCommand.Position, updateEmployeeCommand.EducationalBackground,
                updateEmployeeCommand.ContractingRegime, updateEmployeeCommand.Coordinator, updateEmployeeCommand.RhClassification);

            employeesRepository.UpdateDatabase();
        }

        private async Task<Domain.Employee.Employee> GetEmployee(Guid employeeId, CancellationToken cancellationToken = default)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentNullException(nameof(employeeId));

            var employee = await employeesRepository.GetSingleOrDefaultAsync(employeeId, cancellationToken);

            return employee is null ? throw new EmployeeNotFoundException(employeeId) : employee;
        }
    }
}
