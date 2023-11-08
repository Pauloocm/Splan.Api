using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Finances.Commands
{
    public class AddFinanceItemCommand
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public string Supplier { get; set; }
    }
}
