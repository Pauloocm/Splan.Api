using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Splan.Platform.Application.Finances.Commands
{
    public class UpdateFinanceItemCommand
    {
        public Guid FinanceKey { get; set; }

        [AllowNull]
        [DefaultValue("")]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        [AllowNull]
        [DefaultValue("")]
        public string Supplier { get; set; }
    }
}
