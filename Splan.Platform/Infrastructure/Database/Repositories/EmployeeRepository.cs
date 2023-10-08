using Microsoft.EntityFrameworkCore;
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

        public async Task Delete(Guid employeeId, CancellationToken cancellationToken = default)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentNullException(nameof(employeeId));

            var employeeToBeDeleted = await DbContext.Employees.FindAsync(employeeId, cancellationToken);

            if (employeeToBeDeleted is null)
                throw new ArgumentNullException(employeeId.ToString());


            DbContext.Employees.Remove(employeeToBeDeleted);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await DbContext.Employees.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Employee?> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await DbContext.Employees.FindAsync(id, cancellationToken);          

            return result;
        }

        public async Task<Employee?> GetSingleOrDefaultAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var employee = await DbContext.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            return employee;
        }

        public async Task UpdateDatabase(CancellationToken cancellationToken)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
