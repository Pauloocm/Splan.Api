using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;
using Splan.Platform.Application.Employee.Commands;

namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SplanController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public SplanController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }

        [HttpPost("/Add")]
        public async Task<IActionResult> Add([FromBody] AddEmployeeCommand addEmployeeCommand, CancellationToken cancellationToken = default)
        {
            if (addEmployeeCommand is null)
                throw new ArgumentNullException(nameof(addEmployeeCommand));

            var employeeId = await SplanAppService.Add(addEmployeeCommand, cancellationToken);

            return Ok(employeeId);
        }
    }
}
