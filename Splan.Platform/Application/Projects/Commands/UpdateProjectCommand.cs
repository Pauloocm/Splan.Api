using Splan.Platform.Domain.Enums;

namespace Splan.Platform.Application.Projects.Commands
{
    public class UpdateProjectCommand
    {
        public Guid projectId {  get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public ProjectStatus Status { get; set; }
    }
}
