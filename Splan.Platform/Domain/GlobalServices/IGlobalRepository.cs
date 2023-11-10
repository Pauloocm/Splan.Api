using Splan.Platform.Application.Phase;
using Splan.Platform.Domain.Pdf;

namespace Splan.Platform.Domain.GlobalServices
{
    public interface IGlobalRepository
    {
        Task AddPhaseAsync(Phase phase, CancellationToken cancellationToken = default);
        Task<Phase> GetPhaseAsync(Guid phaseId, CancellationToken cancellationToken = default);
        Task UpdateGlobalDatabase(CancellationToken cancellationToken = default);
        Task DeletePhase(Guid phaseId, CancellationToken cancellationToken = default);
        Task<List<Phase>> ListAllPhasesAsync(CancellationToken cancellationToken = default);

        Task AddFinanceItem(Finances.FinanceItem financeItem, CancellationToken cancellationToken = default);
        Task<Finances.FinanceItem> GetFinanceItem(Guid itemId, CancellationToken cancellationToken = default);
        Task DeleteFinanceItem(Guid itemId, CancellationToken cancellationToken = default);
        Task<List<Finances.FinanceItem>> ListAllFinanceItens(CancellationToken cancellationToken = default);

        Task AddPdf(Pdf.Pdf pdf, CancellationToken cancellationToken = default);
        Task<Pdf.Pdf> GetPdf(Guid pdfId, CancellationToken cancellationToken = default);
    }
}
