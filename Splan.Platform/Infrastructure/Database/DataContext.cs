using Microsoft.EntityFrameworkCore;
using Splan.Platform.Application.Phase;
using Splan.Platform.Domain.Employee;
using Splan.Platform.Domain.Finances;
using Splan.Platform.Domain.Pdf;

namespace Splan.Platform.Infrastructure.Database
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SplanDb");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<FinanceItem> Itens { get; set; }
        public DbSet<Pdf> Pdfs { get; set; }
    }
}
