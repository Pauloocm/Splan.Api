using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;
using Splan.Platform.Application.Finances.Commands;

namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancesController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public FinancesController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }

        [HttpPost("/AddFinanceItem")]
        public async Task<IActionResult> Add([FromBody] AddFinanceItemCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var employeeKey = await SplanAppService.AddFinanceItem(command, cancellationToken);

            return Ok(employeeKey);
        }

        [HttpGet("/ListFinanceItens")]
        public async Task<IActionResult> GetRhFinance(CancellationToken cancellationToken = default)
        {
            var itensDto = await SplanAppService.ListFinanceItens(cancellationToken);

            return Ok(itensDto);
        }


    }
}
