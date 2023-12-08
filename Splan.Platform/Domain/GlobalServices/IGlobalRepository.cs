using Splan.Platform.Application.Phase;
using Splan.Platform.Domain.Pdf;

namespace Splan.Platform.Domain.GlobalServices
{
    public interface IGlobalRepository
    {
        Task AddPhaseAsync(Phase phase, CancellationToken cancellationToken = default);
        Task<Phase> GetPhaseAsync(Guid phaseId, Guid projectId, CancellationToken cancellationToken = default);
        Task UpdateGlobalDatabase(CancellationToken cancellationToken = default);
        Task DeletePhase(Guid phaseId, Guid projectId, CancellationToken cancellationToken = default);
        Task<List<Phase>> ListAllPhasesAsync(Guid projectId, CancellationToken cancellationToken = default);

        Task AddFinanceItem(Finances.FinanceItem financeItem, CancellationToken cancellationToken = default);
        Task<Finances.FinanceItem> GetFinanceItem(Guid itemId, Guid projectId, CancellationToken cancellationToken = default);
        Task DeleteFinanceItem(Guid itemId, Guid projectId, CancellationToken cancellationToken = default);
        Task<List<Finances.FinanceItem>> ListAllFinanceItens(Guid projectId, CancellationToken cancellationToken = default);

        Task AddPdf(Pdf.Pdf pdf, CancellationToken cancellationToken = default);
        Task<Pdf.Pdf> GetPdf(Guid itemId, CancellationToken cancellationToken = default);
    }
}
