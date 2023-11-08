namespace Splan.Platform.Application.Phase.Exceptions
{
    public class PhaseNotFoundException : Exception
    {
        public PhaseNotFoundException(Guid phaseId) : base($"A phase with the specified id was not found {phaseId}")
        {
        }
    }
}
