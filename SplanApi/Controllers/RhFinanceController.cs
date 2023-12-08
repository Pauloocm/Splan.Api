using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;
using Splan.Platform.Application.Employee.Commands;
using System.Net;

namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]/{projectId:guid}")]
    public class RhFinancesController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public RhFinancesController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add([FromRoute] Guid projectId, [FromBody] AddRhFinanceFromEmployee command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var employeeKey = await SplanAppService.AddRhFinance(command, projectId, cancellationToken);

            return Ok(employeeKey);
        }

        [HttpGet]
        public async Task<IActionResult> GetRhFinance([FromRoute] Guid projectId, CancellationToken cancellationToken = default)
        {
            var rhFinances = await SplanAppService.ListRhFinances(projectId, cancellationToken);

            return Ok(rhFinances);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRhFinance([FromRoute] Guid projectId, UpdateRhFinanceCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var rhFinance = await SplanAppService.UpdateRhFinance(command, projectId, cancellationToken);

            return Ok(rhFinance);
        }

    }
}
