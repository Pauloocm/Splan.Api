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

        public async Task<Guid> Add(AddEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var employee = EmployeeFactory.Create(command.Name, command.Position, command.EducationalBackground,
                command.ContractingRegime, command.Coordinator, command.RhClassification);

            await employeesRepository.AddAsync(employee, cancellationToken);

            return employee.Id;
        }

        public async Task<List<EmployeeDto>> Get(CancellationToken cancellationToken = default)
        {
            var employees = await employeesRepository.GetAllAsync(cancellationToken);

            return EmployeeDto.ToDto(employees);
        }

        public async Task<EmployeeDto> GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            var employee = await employeesRepository.GetById(id);

            if (employee is null)
                throw new EmployeeNotFoundException(id);

            var employeeDto = EmployeeDto.ToDto(employee);

            return employeeDto;
        }

        public async Task Update(UpdateEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            var employee = await GetEmployee(command.EmployeeId, cancellationToken);

            employee.Update(command.Name, command.Position, command.EducationalBackground,
                command.ContractingRegime, command.Coordinator, command.RhClassification);

            await employeesRepository.UpdateDatabase();
        }

        private async Task<Domain.Employee.Employee> GetEmployee(Guid employeeId, CancellationToken cancellationToken = default)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentNullException(nameof(employeeId));

            var employee = await employeesRepository.GetSingleOrDefaultAsync(employeeId, cancellationToken);

            return employee is null ? throw new EmployeeNotFoundException(employeeId) : employee;
        }

        /// <summary>
        /// Exclui um funcionário com base no comando fornecido.
        /// </summary>
        /// <param name="command">O comando que especifica o ID do funcionário a ser excluído.</param>
        /// <param name="cancellationToken">Um token de cancelamento opcional para interromper a operação.</param>
        /// <exception cref="ArgumentNullException">É lançada se o comando for nulo.</exception>
        /// <exception cref="EmployeeNotFoundException">É lançada se o funcionário com o ID especificado não for encontrado.</exception>
        /// <returns>Uma tarefa que representa a conclusão da operação de exclusão.</returns>
        public async Task Delete(DeleteEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var employee = await employeesRepository.GetById(command.EmployeeId);

            if (employee is null)
                throw new EmployeeNotFoundException(command.EmployeeId);

            await employeesRepository.Delete(command.EmployeeId, cancellationToken);
        }
    }
}
