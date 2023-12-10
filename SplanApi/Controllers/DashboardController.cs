using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;


namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]/{projectId:guid}")]
    public class DashboardController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public DashboardController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard([FromRoute] Guid projectId, CancellationToken cancellationToken = default)
        {
            if (projectId == Guid.Empty)
                return BadRequest("ProjectId is required");

            var dashboard = await SplanAppService.GetDashboard(projectId, cancellationToken);

            return Ok(dashboard);
        }
    }
}
