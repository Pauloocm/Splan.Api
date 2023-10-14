using Splan.Platform.Application.Phase;
using Splan.Platform.Domain.Employee;
using Splan.Platform.Domain.GlobalServices;

namespace Splan.Platform.Infrastructure.Database.Repositories
{
    public class GlobalRepository : IGlobalRepository
    {
        private readonly DataContext DbContext;

        public GlobalRepository(DataContext dbcontext)
        {
            DbContext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        public async Task AddPhaseAsync(Phase phase, CancellationToken cancellationToken = default)
        {
            if (phase is null)
                throw new ArgumentNullException(nameof(phase));

            await DbContext.Phases.AddAsync(phase, cancellationToken);
            DbContext.SaveChanges();
        }

        public async Task DeletePhase(Guid phaseId, CancellationToken cancellationToken = default)
        {
            if (phaseId == Guid.Empty)
                throw new ArgumentNullException(phaseId.ToString());

            var phase = await DbContext.Phases.FindAsync(phaseId, cancellationToken);

            if (phase is null)
                throw new ArgumentNullException(phase.ToString());

            DbContext.Remove(phase);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Phase> GetPhaseAsync(Guid phaseId, CancellationToken cancellationToken = default)
        {
            var phase = await DbContext.Phases.FindAsync(phaseId, cancellationToken);

            return phase;
        }

        public async Task UpdateGlobalDatabase(CancellationToken cancellationToken = default)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
