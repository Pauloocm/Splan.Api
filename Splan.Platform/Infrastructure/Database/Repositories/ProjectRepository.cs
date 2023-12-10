using Microsoft.EntityFrameworkCore;
using Splan.Platform.Application.Phase;
using Splan.Platform.Domain.Employee;
using Splan.Platform.Domain.Finances;
using Splan.Platform.Domain.Pdf;
using Splan.Platform.Domain.Project;

namespace Splan.Platform.Infrastructure.Database.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext DbContext;

        public ProjectRepository(DataContext dbcontext)
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

        public async Task Delete(Guid key, Guid projectId, CancellationToken cancellationToken = default)
        {
            if (projectId == Guid.Empty)
                throw new ArgumentNullException(nameof(projectId));

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

        public async Task<Employee> GetById(Guid employeeId, Guid projectId, CancellationToken cancellationToken = default)
        {
            var result = await DbContext.Employees.Where(e => e.ProjectId == projectId).FirstOrDefaultAsync(e => e.Key == employeeId);

            if (result is null)
                return null;

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

        public async Task<IList<FinanceItem>> ListRhItens(Guid projectId, CancellationToken cancellationToken)
        {
            return await DbContext.Itens.Where(p => p.ProjectId == projectId).ToListAsync(cancellationToken);
        }

        public async Task UpdateDatabase(CancellationToken cancellationToken = default)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task AddPdf(Pdf pdf, CancellationToken cancellationToken = default)
        {
            if (pdf is null)
                throw new ArgumentNullException(nameof(pdf));

            var exist = await DbContext.Pdfs.SingleOrDefaultAsync(p => p.FinanceItemId == pdf.FinanceItemId, cancellationToken);

            if (exist != null)
                DbContext.Pdfs.Remove(exist);

            await DbContext.Pdfs.AddAsync(pdf, cancellationToken);
            DbContext.SaveChanges();
        }

        public async Task<Pdf> GetPdf(Guid itemId, CancellationToken cancellationToken = default)
        {
            var pdf = await DbContext.Pdfs.FirstOrDefaultAsync(p => p.FinanceItemId == itemId, cancellationToken);

            return pdf;
        }

        public async Task<FinanceItem> GetFinanceItem(Guid itemId, Guid projectId, CancellationToken cancellationToken = default)
        {
            var item = await DbContext.Itens.Where(p => p.ProjectId == projectId).SingleOrDefaultAsync(i => i.Key == itemId, cancellationToken);

            if (item is null)
                return null;

            return item;
        }

        public async Task<List<FinanceItem>> ListAllFinanceItens(Guid projectId, CancellationToken cancellationToken = default)
        {
            var itens = await DbContext.Itens.Where(i => i.ProjectId == projectId).ToListAsync(cancellationToken);

            if (itens is null)
                return null;

            return itens;
        }

        public async Task DeleteFinanceItem(Guid itemId, Guid projectId, CancellationToken cancellationToken = default)
        {
            if (itemId == Guid.Empty)
                throw new ArgumentNullException(itemId.ToString());

            var item = await DbContext.Itens.Where(i => i.ProjectId == projectId).FirstOrDefaultAsync(i => i.Key == itemId, cancellationToken);

            if (item is null)
                throw new ArgumentNullException(itemId.ToString());

            DbContext.Remove(item);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddFinanceItem(FinanceItem financeItem, CancellationToken cancellationToken = default)
        {
            if (financeItem is null)
                throw new ArgumentNullException(nameof(financeItem));

            await DbContext.Itens.AddAsync(financeItem, cancellationToken);
            DbContext.SaveChanges();
        }

        public async Task AddPhaseAsync(Phase phase, CancellationToken cancellationToken = default)
        {
            if (phase is null)
                throw new ArgumentNullException(nameof(phase));

            await DbContext.Phases.AddAsync(phase, cancellationToken);
            DbContext.SaveChanges();
        }

        public async Task DeletePhase(Guid phaseId, Guid projectId, CancellationToken cancellationToken = default)
        {
            if (phaseId == Guid.Empty)
                throw new ArgumentNullException(phaseId.ToString());

            var phase = await DbContext.Phases.Where(p => p.ProjectId == projectId).FirstOrDefaultAsync(p => p.Id == phaseId, cancellationToken);

            if (phase is null)
                throw new ArgumentNullException(phaseId.ToString());

            DbContext.Remove(phase);
            await DbContext.SaveChangesAsync(cancellationToken);
        }


        public async Task<Phase> GetPhaseAsync(Guid phaseId, Guid projectId, CancellationToken cancellationToken = default)
        {
            var phase = await DbContext.Phases.Where(p => p.ProjectId == projectId).
                FirstOrDefaultAsync(p => p.Id == phaseId, cancellationToken);

            return phase;
        }

        public async Task<List<Phase>> ListAllPhasesAsync(Guid projectId, CancellationToken cancellationToken = default)
        {
            var phases = await DbContext.Phases.Where(p => p.ProjectId == projectId).ToListAsync(cancellationToken);

            return phases;
        }
    }
}
