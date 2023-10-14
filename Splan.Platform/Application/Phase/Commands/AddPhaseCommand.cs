using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Phase.Commands
{
    public class AddPhaseCommand
    {
        [Required]
        public string Stage { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
    }
}
