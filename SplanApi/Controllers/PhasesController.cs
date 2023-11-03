using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;
using Splan.Platform.Application.Phase.Commands;

namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhasesController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public PhasesController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }

        [HttpPost("/AddPhase")]
        public async Task<IActionResult> Add([FromBody] AddPhaseCommand addPhaseCommand, CancellationToken cancellationToken = default)
        {
            if (addPhaseCommand is null)
                throw new ArgumentNullException(nameof(addPhaseCommand));

            var phaseId = await SplanAppService.AddPhase(addPhaseCommand, cancellationToken);

            return Ok(phaseId);
        }

        [HttpPut("/UpdatePhase")]
        public async Task<IActionResult> Update([FromBody] UpdatePhaseCommand updatePhaseCommand, CancellationToken cancellationToken = default)
        {
            if (updatePhaseCommand is null)
                throw new ArgumentNullException(nameof(updatePhaseCommand));

            var phaseResult = await SplanAppService.UpdatePhase(updatePhaseCommand, cancellationToken);

            return Ok(phaseResult);
        }

        [HttpGet("/ListPhases")]
        public async Task<IActionResult> ListPhases(CancellationToken cancellationToken = default)
        {
            var phases = await SplanAppService.ListAllPhases(cancellationToken);

            return Ok(phases);
        }

        [HttpDelete("/DeletePhase")]
        public async Task<IActionResult> Delete([FromBody] DeletePhaseCommand deletePhaseCommand, CancellationToken cancellationToken = default)
        {
            if (deletePhaseCommand is null)
                throw new ArgumentNullException(nameof(deletePhaseCommand));

            await SplanAppService.DeletePhase(deletePhaseCommand, cancellationToken);

            return Ok();
        }
    }
}
