using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Splan.Platform.Application.Projects.Commands
{
    public class UpdateProjectCommand
    {
        public Guid ProjectId {  get; set; }

        [AllowNull]
        [DefaultValue("")]
        public string Name { get; set; }

        [AllowNull]
        [DefaultValue("")]
        public string Company { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool Status { get; set; }
    }
}
