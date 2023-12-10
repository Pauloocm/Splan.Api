using Splan.Platform.Application.Phase;
using Splan.Platform.Domain.Pdf;

namespace Splan.Platform.Domain.GlobalServices
{
    public interface IGlobalRepository
    {
        


        Task UpdateGlobalDatabase(CancellationToken cancellationToken = default);
        Task Register(string email, string password, CancellationToken cancellationToken = default);
        Task<string> Login(string email, string password, CancellationToken cancellationToken = default);
    }
}
