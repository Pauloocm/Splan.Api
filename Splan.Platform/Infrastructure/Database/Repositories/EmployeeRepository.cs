using Microsoft.EntityFrameworkCore;
using Splan.Platform.Application.Finances.Dtos;
using Splan.Platform.Domain.Employee;
using Splan.Platform.Domain.Project;
using System.Threading;

namespace Splan.Platform.Infrastructure.Database.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext DbContext;

        public EmployeeRepository(DataContext dbcontext)
        {
            DbContext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        public async Task AddAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            await DbContext.Employees.AddAsync(employee, cancellationToken);
            DbContext.SaveChanges();
        }

        public async Task AddProject(Project project, CancellationToken cancellationToken)
        {
            if (project is null)
                throw new ArgumentNullException(nameof(project));

            await DbContext.Projects.AddAsync(project, cancellationToken);
            DbContext.SaveChanges();
        }

        public async Task Delete(Guid projectId, Guid key, CancellationToken cancellationToken = default)
        {
            if (key == Guid.Empty)
                throw new ArgumentNullException(nameof(key));

            var employeeToBeDeleted = await DbContext.Employees.Where(e => e.ProjectId == projectId).FirstOrDefaultAsync(e => e.Key == key, cancellationToken);

            DbContext.Employees.Remove(employeeToBeDeleted);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProject(Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            var project = DbContext.Projects.Find(id);

            DbContext.Projects.Remove(project);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IList<Employee>> ListAll(Guid projectId, CancellationToken cancellationToken = default)
        {
            var result = await DbContext.Employees.Where(e => e.ProjectId == projectId).ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IList<Project>> ListAllProjects(CancellationToken cancellationToken)
        {
            return await DbContext.Projects.ToListAsync(cancellationToken);
        }

        public async Task<Employee> GetById(Guid projectId, Guid id, CancellationToken cancellationToken = default)
        {
            var result = await DbContext.Employees.Where(e => e.ProjectId == projectId).FirstOrDefaultAsync(e => e.Key == id);

            return result;
        }

        public async Task<Project> GetProject(Guid projectId, CancellationToken cancellationToken)
        {
            return await DbContext.Projects.FindAsync(projectId, cancellationToken);
        }

        public async Task<Employee> GetSingleOrDefaultAsync(Guid projectId, Guid id, CancellationToken cancellationToken = default)
        {
            var employee = await DbContext.Employees.Where(e => e.ProjectId == projectId).FirstOrDefaultAsync(e => e.Key == id, cancellationToken);

            return employee;
        }

        public Task<IList<FinanceItemDto>> ListRhItens(Guid projectId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateDatabase(CancellationToken cancellationToken = default)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
