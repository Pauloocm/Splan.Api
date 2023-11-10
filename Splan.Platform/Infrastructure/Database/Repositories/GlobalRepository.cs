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

        public async Task DeleteFinanceItem(Guid itemId, CancellationToken cancellationToken = default)
        {
            if (itemId == Guid.Empty)
                throw new ArgumentNullException(itemId.ToString());

            var item = await DbContext.Itens.FindAsync(itemId, cancellationToken);

            if (item is null)
                throw new ArgumentNullException(itemId.ToString());

            DbContext.Remove(item);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeletePhase(Guid phaseId, CancellationToken cancellationToken = default)
        {
            if (phaseId == Guid.Empty)
                throw new ArgumentNullException(phaseId.ToString());

            var phase = await DbContext.Phases.FindAsync(phaseId, cancellationToken);

            if (phase is null)
                throw new ArgumentNullException(phaseId.ToString());

            DbContext.Remove(phase);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Pdf> GetPdf(Guid pdfId, CancellationToken cancellationToken = default)
        {
            var pdf = await DbContext.Pdfs.FindAsync(pdfId, cancellationToken);

            return pdf;
        }

        public async Task<FinanceItem> GetFinanceItem(Guid itemId, CancellationToken cancellationToken = default)
        {
            var item = await DbContext.Itens.FindAsync(itemId, cancellationToken);

            if (item is null)
                return null;

            return item;
        }

        public async Task<Phase> GetPhaseAsync(Guid phaseId, CancellationToken cancellationToken = default)
        {
            var phase = await DbContext.Phases.FindAsync(phaseId, cancellationToken);

            return phase;
        }

        public async Task<List<FinanceItem>> ListAllFinanceItens(CancellationToken cancellationToken = default)
        {
            var itens = await DbContext.Itens.ToListAsync(cancellationToken);

            if (itens is null)
                return null;

            return itens;
        }

        public async Task<List<Phase>> ListAllPhasesAsync(CancellationToken cancellationToken = default)
        {
            var phases = await DbContext.Phases.ToListAsync(cancellationToken);

            return phases;
        }

        public async Task UpdateGlobalDatabase(CancellationToken cancellationToken = default)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
