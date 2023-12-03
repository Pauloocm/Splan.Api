using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;
using Splan.Platform.Application.Projects.Commands;

namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public ProjectsController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProjectCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var projectId = await SplanAppService.Add(command, cancellationToken);

            return Ok(projectId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProjectCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            await SplanAppService.Update(command, cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ListProjects(CancellationToken cancellationToken = default)
        {
            var projects = await SplanAppService.List(cancellationToken);

            return Ok(projects);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProjectCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            await SplanAppService.Delete(command, cancellationToken);

            return Ok();
        }

    }
}
