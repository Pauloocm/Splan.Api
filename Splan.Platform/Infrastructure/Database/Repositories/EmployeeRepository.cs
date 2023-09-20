using Splan.Platform.Domain.Employee;

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
    }
}
