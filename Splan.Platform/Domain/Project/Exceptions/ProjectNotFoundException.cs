namespace Splan.Platform.Domain.Project.Exceptions
{
    public class ProjectNotFoundException : Exception
    {
        public ProjectNotFoundException(Guid projectId) : base($"A project with the specified id was not found {projectId}")
        {
        }
    }
}
