using Microsoft.EntityFrameworkCore;
using Splan.Platform.Application.Phase;
using Splan.Platform.Domain.Finances;
using Splan.Platform.Domain.GlobalServices;
using Splan.Platform.Domain.Pdf;

namespace Splan.Platform.Infrastructure.Database.Repositories
{
    public class GlobalRepository : IGlobalRepository
    {
        private readonly DataContext DbContext;

        public GlobalRepository(DataContext dbcontext)
        {
            DbContext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        public async Task AddFinanceItem(FinanceItem financeItem, CancellationToken cancellationToken = default)
        {
            if (financeItem is null)
                throw new ArgumentNullException(nameof(financeItem));

            await DbContext.Itens.AddAsync(financeItem, cancellationToken);
            DbContext.SaveChanges();
        }

        public async Task AddPdf(Pdf pdf, CancellationToken cancellationToken = default)
        {
            if (pdf is null)
                throw new ArgumentNullException(nameof(pdf));

            await DbContext.Pdfs.AddAsync(pdf, cancellationToken);
            DbContext.SaveChanges();
        }

        public async Task AddPhaseAsync(Phase phase, CancellationToken cancellationToken = default)
        {
            if (phase is null)
                throw new ArgumentNullException(nameof(phase));

            await DbContext.Phases.AddAsync(phase, cancellationToken);
            DbContext.SaveChanges();
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

        public async Task<Pdf> GetPdf(Guid itemId, CancellationToken cancellationToken = default)
        {
            var pdf = await DbContext.Pdfs.FirstOrDefaultAsync(p => p.FinanceItemId == itemId, cancellationToken);

            return pdf;
        }

        public async Task<FinanceItem> GetFinanceItem(Guid itemId, CancellationToken cancellationToken = default)
        {
            var item = await DbContext.Itens.FindAsync(itemId, cancellationToken);

            if (item is null)
                return null;

            return item;
        }

        public async Task<Phase> GetPhaseAsync(Guid phaseId, Guid projectId, CancellationToken cancellationToken = default)
        {
            var phase = await DbContext.Phases.Where(p => p.ProjectId == projectId).
                FirstOrDefaultAsync(p => p.Id == phaseId, cancellationToken);

            return phase;
        }

        public async Task<List<FinanceItem>> ListAllFinanceItens(Guid projectId, CancellationToken cancellationToken = default)
        {
            var itensTotal = DbContext.Itens.Count();

            var itens = await DbContext.Itens.Where(i => i.ProjectId == projectId).ToListAsync(cancellationToken);

            if (itens is null)
                return null;

            return itens;
        }

        public async Task<List<Phase>> ListAllPhasesAsync(Guid projectId, CancellationToken cancellationToken = default)
        {
            var phases = await DbContext.Phases.Where(p => p.ProjectId == projectId).ToListAsync(cancellationToken);

            return phases;
        }

        public async Task UpdateGlobalDatabase(CancellationToken cancellationToken = default)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
