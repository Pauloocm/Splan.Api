using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Pdf.Commands
{
    public class AddPdfCommand
    {
        [Required]
        public Stream Pdf { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid FinanceItemId { get; set; }
    }
}
