using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;
using Splan.Platform.Application.Phase.Commands;

namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]/{projectId:guid}")]
    public class PhasesController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public PhasesController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddPhaseCommand addPhaseCommand, CancellationToken cancellationToken = default)
        {
            if (addPhaseCommand is null)
                throw new ArgumentNullException(nameof(addPhaseCommand));

            var phaseId = await SplanAppService.AddPhase(addPhaseCommand, cancellationToken);

            return Ok(phaseId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] Guid projectId, [FromBody] UpdatePhaseCommand updatePhaseCommand, CancellationToken cancellationToken = default)
        {
            if (updatePhaseCommand is null)
                throw new ArgumentNullException(nameof(updatePhaseCommand));

            var phaseResult = await SplanAppService.UpdatePhase(updatePhaseCommand, projectId, cancellationToken);

            return Ok(phaseResult);
        }

        [HttpGet]
        public async Task<IActionResult> ListPhases([FromRoute] Guid projectId, CancellationToken cancellationToken = default)
        {
            var phases = await SplanAppService.ListAllPhases(projectId, cancellationToken);

            return Ok(phases);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid projectId, [FromBody] DeletePhaseCommand deletePhaseCommand, CancellationToken cancellationToken = default)
        {
            if (deletePhaseCommand is null)
                throw new ArgumentNullException(nameof(deletePhaseCommand));

            await SplanAppService.DeletePhase(deletePhaseCommand, projectId, cancellationToken);

            return Ok();
        }
    }
}
