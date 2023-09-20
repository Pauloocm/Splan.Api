using Microsoft.EntityFrameworkCore;
using Splan.Platform.Domain.Employee;

namespace Splan.Platform.Infrastructure.Database
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SplanDb");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
