using System.Runtime.InteropServices;

namespace Splan.Platform.Application.Phase
{
    public static class PhaseFactory
    {
        public static Phase Create(string stage, string description, Guid projectId)
        {
            if (string.IsNullOrWhiteSpace(stage))
                throw new ArgumentException(nameof(stage));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(nameof(description));

            if (projectId == Guid.Empty)
                throw new ArgumentException(nameof(projectId));

            var phase = new Phase()
            {
                Stage = stage,
                Description = description,
                ProjectId = projectId
            };

            return phase;
        }
    }
}
