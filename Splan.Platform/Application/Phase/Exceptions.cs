namespace Splan.Platform.Application.Phase
{
    public class PhaseNotFoundException : Exception
    {
        public PhaseNotFoundException(Guid phaseId) : base($"A phase with the specified id was not found {phaseId}")
        {
        }
    }
}
