using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Splan.Platform.Application.Phase.Commands
{
    public class UpdatePhaseCommand
    {
        [Required]
        public Guid PhaseId { get; set; }

        public string Stage { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
