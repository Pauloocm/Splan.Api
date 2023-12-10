using Microsoft.EntityFrameworkCore;
using Splan.Platform.Domain;
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

        public async Task UpdateGlobalDatabase(CancellationToken cancellationToken = default)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Register(string email, string password, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(email), "Invalid login");

            var hashedPassword = Services.GenerateMD5Hash(password);

            var admin = new AdminDataModel(email, hashedPassword);

            await DbContext.Admin.AddAsync(admin, cancellationToken);
            await DbContext.SaveChangesAsync();
        }

        public async Task<string> Login(string email, string password, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(email), "Invalid login");

            var hashedPassword = Services.GenerateMD5Hash(password);

            var findedAdmin = await DbContext.Admin.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            if (findedAdmin != null)
            {
                var result = string.Equals(findedAdmin.Password, hashedPassword, StringComparison.OrdinalIgnoreCase);

                if (result)
                    return findedAdmin.Email;
            }

            return string.Empty;
        }
    }
}
