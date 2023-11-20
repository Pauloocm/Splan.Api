﻿using Microsoft.AspNetCore.Http;
using Splan.Platform.Application.Employee.Commands;
using Splan.Platform.Application.Employee.Dtos;
using Splan.Platform.Application.Finances.Commands;
using Splan.Platform.Application.Finances.Dtos;
using Splan.Platform.Application.Pdf.Commands;
using Splan.Platform.Application.Phase;
using Splan.Platform.Application.Phase.Commands;
using Splan.Platform.Application.Phase.Exceptions;
using Splan.Platform.Application.Projects.Commands;
using Splan.Platform.Domain.Employee;
using Splan.Platform.Domain.Employee.Exceptions;
using Splan.Platform.Domain.Finances;
using Splan.Platform.Domain.GlobalServices;
using Splan.Platform.Domain.Project;
using Splan.Platform.Domain.Project.Exceptions;

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

        public async Task<Guid> AddEmployee(AddEmployeeCommand command, Guid projectId, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var employee = EmployeeFactory.Create(command.Name, command.Function, command.EducationDegree,
                command.HiringRegimeId, command.IsCoordinator, command.Classification, projectId);

            await EmployeesRepository.AddAsync(employee, cancellationToken);

            return employee.Key;
        }

        public async Task<List<EmployeeDto>> ListEmployees(Guid projectId, CancellationToken cancellationToken = default)
        {
            return EmployeeDto.ToDto(await EmployeesRepository.GetAllAsync(projectId, cancellationToken));
        }

        public async Task<EmployeeDto> GetEmployeeById(Guid employeeId, Guid projectId, CancellationToken cancellationToken = default)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentNullException(nameof(employeeId));

            var employee = await EmployeesRepository.GetById(employeeId, projectId, cancellationToken);

            return employee is null ? throw new EmployeeNotFoundException(employeeId) : EmployeeDto.ToDto(employee);
        }

        public async Task UpdateEmployee(UpdateEmployeeCommand command, Guid projectId, CancellationToken cancellationToken = default)
        {
            var employee = await GetEmployee(command.Key, projectId, cancellationToken);

            employee.Update(command.Name, command.Function, command.EducationDegree,
                command.HiringRegimeId, command.IsCoordinator, command.Classification);

            await EmployeesRepository.UpdateDatabase(cancellationToken);
        }

        private async Task<Domain.Employee.Employee> GetEmployee(Guid projectId, Guid employeId, CancellationToken cancellationToken = default)
        {
            if (employeId == Guid.Empty)
                throw new ArgumentNullException(nameof(employeId));

            var employee = await EmployeesRepository.GetSingleOrDefaultAsync(employeId, projectId, cancellationToken);

            return employee is null ? throw new EmployeeNotFoundException(employeId) : employee;
        }

        /// <summary>
        /// Exclui um funcionário com base no comando fornecido.
        /// </summary>
        /// <param name="command">O comando que especifica o ID do funcionário a ser excluído.</param>
        /// <param name="cancellationToken">Um token de cancelamento opcional para interromper a operação.</param>
        /// <exception cref="ArgumentNullException">É lançada se o comando for nulo.</exception>
        /// <exception cref="EmployeeNotFoundException">É lançada se o funcionário com o ID especificado não for encontrado.</exception>
        /// <returns>Uma tarefa que representa a conclusão da operação de exclusão.</returns>
        public async Task DeleteEmployee(DeleteEmployeeCommand command, Guid projectId, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var employee = await EmployeesRepository.GetById(command.Key, projectId, cancellationToken) ??
                throw new EmployeeNotFoundException(command.Key);

            await EmployeesRepository.Delete(employee.Key, projectId, cancellationToken);
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

            var phase = await GetPhase(command.PhaseId, cancellationToken) ??
                throw new PhaseNotFoundException(command.PhaseId);

            await GlobalRepository.DeletePhase(phase.Key, cancellationToken);
        }

        public async Task<List<Phase.Phase>> ListAllPhases(CancellationToken cancellationToken = default)
        {
            return await GlobalRepository.ListAllPhasesAsync(cancellationToken);
        }

        public async Task<Guid> AddRhFinance(AddRhFinanceFromEmployee command, Guid projectId, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var employee = await EmployeesRepository.GetById(command.Key, projectId, cancellationToken) ??
                throw new EmployeeNotFoundException(command.Key);

            employee.SetRhFinances(command.ContractDateMonth, command.ValuePerHour, command.HoursWorkedMonth);

            await EmployeesRepository.UpdateDatabase(cancellationToken);

            return employee.Key;
        }

        public async Task<List<EmployeeRhFinanceDto>> ListRhFinances(Guid projectId, CancellationToken cancellationToken = default)
        {
            return EmployeeRhFinanceDto.ToDto(await EmployeesRepository.GetAllAsync(projectId, cancellationToken));
        }

        private async Task<Phase.Phase> GetPhase(Guid phaseId, CancellationToken cancellationToken = default)
        {
            if (phaseId == Guid.Empty)
                throw new ArgumentNullException(nameof(phaseId));

            var phase = await GlobalRepository.GetPhaseAsync(phaseId, cancellationToken);

            return phase is null ? throw new PhaseNotFoundException(phaseId) : phase;
        }

        public async Task<Guid> AddFinanceItem(AddFinanceItemCommand command, Guid projectId, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var financeItem = FinanceItemFactory.Create(command.Name, command.Date, command.Value, command.Supplier);

            await GlobalRepository.AddFinanceItem(financeItem, cancellationToken);

            return financeItem.Key;
        }

        public Task<List<FinanceItemDto>> ListFinanceItens(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> AddPdf(IFormFile pdfFile, AddPdfCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await pdfFile.CopyToAsync(memoryStream, cancellationToken);

                    byte[] pdfData = memoryStream.ToArray();

                    var pdf = new Splan.Platform.Domain.Pdf.Pdf(pdfData, command.FinanceItemId, command.Name);

                    await GlobalRepository.AddPdf(pdf, cancellationToken);

                    return pdf.Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Domain.Pdf.Pdf> DownloadPdf(Guid pdfIdfication, CancellationToken cancellationToken = default)
        {
            return await GlobalRepository.GetPdf(pdfIdfication, cancellationToken);
        }

        public async Task<Guid> Add(AddProjectCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var project = ProjectFactory.Create(command.Name, command.Company, command.StartDate,
                command.ExpirationDate, command.Status);

            await EmployeesRepository.AddProject(project, cancellationToken);

            return project.Key;
        }

        public async Task Update(UpdateProjectCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var project = await EmployeesRepository.GetProject(command.projectId, cancellationToken);

            if (project is null)
                throw new ProjectNotFoundException(command.projectId);

            project.Update(command.Name, command.Company, command.StartDate, command.ExpirationDate, command.Status);
        }

        public Task<List<Project>> List(CancellationToken cancellationToken = default)
        {
            return EmployeesRepository.GetAllProjects(cancellationToken);
        }

        public async Task Delete(DeleteProjectCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var project = await EmployeesRepository.GetProject(command.Id, cancellationToken);

            if (project is null)
                throw new ProjectNotFoundException(command.Id);

            await EmployeesRepository.DeleteProject(command.Id, cancellationToken);
        }
    }
}
