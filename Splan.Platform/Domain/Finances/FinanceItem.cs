using Splan.Platform.Domain.Pdf;
using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Domain.Finances
{
    public class FinanceItem
    {
        [Key]
        public Guid Key { get; set; }
        public Guid ProjectId { get; set; }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Supplier { get; set; }
        public Pdf.Pdf Pdf { get; set; }

        public FinanceItem()
        {
            Key = Guid.NewGuid();
        }

        public void Update(string name, DateTime date, decimal value, string supplier)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                Name = name;
            }
            if (!String.IsNullOrWhiteSpace(supplier))
            {
                Supplier = supplier;
            }
            if (value > 0)
            {
                Value = value;
            }

            Date = date;
        }
    }
}
