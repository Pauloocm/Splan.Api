
namespace Splan.Platform.Domain.Finances
{
    public static class FinanceItemFactory
    {
        public static FinanceItem Create(string name, DateTime date, decimal value, string supplier, Guid projectId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            if (string.IsNullOrWhiteSpace(supplier))
                throw new ArgumentException(nameof(supplier));

            var item = new FinanceItem()
            {
                Name = name,
                Date = date,
                Value = value,
                Supplier = supplier,
                ProjectId = projectId
            };

            return item;
        }
    }
}
