using Splan.Platform.Application.Finances;
using Splan.Platform.Application.Phase;

namespace Splan.Platform.Domain.GlobalServices
{
    public interface IGlobalRepository
    {
        Task AddPhaseAsync(Phase phase, CancellationToken cancellationToken = default);
        Task<Phase> GetPhaseAsync(Guid phaseId, CancellationToken cancellationToken = default);
        Task UpdateGlobalDatabase(CancellationToken cancellationToken = default);
        Task DeletePhase(Guid id, CancellationToken cancellationToken = default);
        Task<List<Phase>> ListAllPhasesAsync(CancellationToken cancellationToken = default);

        Task AddFinacesAsync(Finances finance, CancellationToken cancellationToken = default);
    }
}
