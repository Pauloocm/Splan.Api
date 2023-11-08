using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;
using Splan.Platform.Application.Employee.Commands;

namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RhFinacesController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public RhFinacesController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }

        [HttpPost("/AddRhFinanceFromEmployee")]
        public async Task<IActionResult> Add([FromBody] AddRhFinanceFromEmployee command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var employeeKey = await SplanAppService.AddRhFinance(command, cancellationToken);

            return Ok(employeeKey);
        }

        [HttpGet("/ListRhFinances")]
        public async Task<IActionResult> GetRhFinance(CancellationToken cancellationToken = default)
        {
            var rhFinances = await SplanAppService.ListRhFinances(cancellationToken);

            return Ok(rhFinances);
        }

        //TODO fazer método delete

    }
}
