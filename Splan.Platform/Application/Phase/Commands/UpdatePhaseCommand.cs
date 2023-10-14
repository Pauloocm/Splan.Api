using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Phase.Commands
{
    public class UpdatePhaseCommand
    {
        [Required]
        public Guid PhaseId { get; set; }
        [Required]
        public string Stage { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
