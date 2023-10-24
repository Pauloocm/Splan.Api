using Splan.Platform.Application.Employee.Commands;
using Splan.Platform.Application.Employee.Dtos;
using Splan.Platform.Application.Phase;
using Splan.Platform.Application.Phase.Commands;
using Splan.Platform.Domain.Employee;
using Splan.Platform.Domain.Employee.Exceptions;
using Splan.Platform.Domain.GlobalServices;

namespace Splan.Platform.Application
{
    public class SplanAppService : ISplanAppService
    {
        private readonly IEmployeeRepository EmployeesRepository;
        private readonly IGlobalRepository GlobalRepository;

        public SplanAppService(IEmployeeRepository employeeRepository, IGlobalRepository globalRepository)
        {
            EmployeesRepository = employeeRepository;
            GlobalRepository = globalRepository;
        }

        public async Task<Guid> Add(AddEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var employee = EmployeeFactory.Create(command.Name, command.Function, command.EducationDegree,
                command.HiringRegimeId, command.IsCoordinator, command.Classification);

            await EmployeesRepository.AddAsync(employee, cancellationToken);

            return employee.Key;
        }

        public async Task<List<EmployeeDto>> Get(CancellationToken cancellationToken = default)
        {
            var employees = await EmployeesRepository.GetAllAsync(cancellationToken);

            return EmployeeDto.ToDto(employees);
        }

        public async Task<EmployeeDto> GetEmployeeById(Guid employeId, CancellationToken cancellationToken = default)
        {
            if (employeId == Guid.Empty)
                throw new ArgumentNullException(nameof(employeId));

            var employee = await EmployeesRepository.GetById(employeId);

            if (employee is null)
                throw new EmployeeNotFoundException(employeId);

            var employeeDto = EmployeeDto.ToDto(employee);

            return employeeDto;
        }

        public async Task Update(UpdateEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            var employee = await GetEmployee(command.Key, cancellationToken);

            employee.Update(command.Name, command.Function, command.EducationDegree,
                command.HiringRegimeId, command.IsCoordinator, command.Classification);

            await EmployeesRepository.UpdateDatabase();
        }

        private async Task<Domain.Employee.Employee> GetEmployee(Guid employeId, CancellationToken cancellationToken = default)
        {
            if (employeId == Guid.Empty)
                throw new ArgumentNullException(nameof(employeId));

            var employee = await EmployeesRepository.GetSingleOrDefaultAsync(employeId, cancellationToken);

            return employee is null ? throw new EmployeeNotFoundException(employeId) : employee;
        }

        private async Task<Phase.Phase> GetPhase(Guid phaseId, CancellationToken cancellationToken = default)
        {
            if (phaseId == Guid.Empty)
                throw new ArgumentNullException(nameof(phaseId));

            var phase = await GlobalRepository.GetPhaseAsync(phaseId, cancellationToken);

            return phase is null ? throw new PhaseNotFoundException(phaseId) : phase;
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

            var employee = await EmployeesRepository.GetById(command.Key);

            if (employee is null)
                throw new EmployeeNotFoundException(command.Key);

            await EmployeesRepository.Delete(command.Key, cancellationToken);
        }

        public async Task<Guid> AddPhase(AddPhaseCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var phase = PhaseFactory.Create(command.Stage, command.Description);

            await GlobalRepository.AddPhaseAsync(phase, cancellationToken);

            return phase.Key;
        }

        public async Task<Phase.Phase> UpdatePhase(UpdatePhaseCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var phase = await GetPhase(command.PhaseId, cancellationToken);

            phase.Update(command.Stage, command.Description, command.StartDate, command.EndDate);

            await GlobalRepository.UpdateGlobalDatabase(cancellationToken);

            return phase;
        }

        public async Task DeletePhase(DeletePhaseCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var phase = await GetPhase(command.PhaseId, cancellationToken);

            if (phase is null)
                throw new PhaseNotFoundException(command.PhaseId);

            await GlobalRepository.DeletePhase(phase.Key, cancellationToken);
        }

        public async Task<List<Phase.Phase>> ListAllPhases(CancellationToken cancellationToken = default)
        {
            return await GlobalRepository.ListAllPhasesAsync(cancellationToken);
        }
    }
}
