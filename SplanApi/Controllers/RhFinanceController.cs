using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;

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

        [HttpGet("/GetRhFinance")]
        public async Task<IActionResult> GetRhFinance(CancellationToken cancellationToken = default)
        {
            var employees = await SplanAppService.Get(cancellationToken);

            return Ok(employees);
        }


    }
}
