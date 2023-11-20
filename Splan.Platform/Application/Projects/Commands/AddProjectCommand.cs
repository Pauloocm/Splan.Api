using Splan.Platform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Projects.Commands
{
    public class AddProjectCommand
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        [Required]
        public ProjectStatus Status { get; set; }
    }
}
