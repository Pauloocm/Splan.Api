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

        [HttpPut("/Update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken = default)
        {
            if (updateEmployeeCommand is null)
                throw new ArgumentNullException(nameof(updateEmployeeCommand));

            await SplanAppService.Update(updateEmployeeCommand, cancellationToken);

            return Ok();
        }

        [HttpGet("/Get")]
        public async Task<IActionResult> GetAllEmpployees(CancellationToken cancellationToken = default)
        {
            var employees = await SplanAppService.Get(cancellationToken);

            return Ok(employees);
        }

        [HttpDelete("/Delete")]
        public async Task<IActionResult> Delete(DeleteEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            await SplanAppService.Delete(command, cancellationToken);

            return Ok();
        }
    }
}
