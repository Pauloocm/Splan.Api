using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;
using Splan.Platform.Application.Employee.Commands;

namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public EmployeesController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }

        [HttpPost("/Add")]
        public async Task<IActionResult> Add([FromBody] AddEmployeeCommand addEmployeeCommand, CancellationToken cancellationToken = default)
        {
            if (addEmployeeCommand is null)
                throw new ArgumentNullException(nameof(addEmployeeCommand));

            var employeeKey = await SplanAppService.Add(addEmployeeCommand, cancellationToken);

            return Ok(employeeKey);
        }

        [HttpPut("/Update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken = default)
        {
            if (updateEmployeeCommand is null)
                throw new ArgumentNullException(nameof(updateEmployeeCommand));

            await SplanAppService.Update(updateEmployeeCommand, cancellationToken);

            return Ok();
        }

        [HttpGet("/List")]
        public async Task<IActionResult> ListEmployees(CancellationToken cancellationToken = default)
        {
            var employees = await SplanAppService.List(cancellationToken);

            return Ok(employees);
        }

        [HttpGet("/Get")]
        public async Task<IActionResult> GetEmployee(Guid employeeKey ,CancellationToken cancellationToken = default)
        {
            var employee = await SplanAppService.GetEmployeeById(employeeKey, cancellationToken);

            return Ok(employee);
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
