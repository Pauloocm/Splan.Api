using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application;
using Splan.Platform.Application.Employee.Commands;


namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]/{projectId:guid}")]
    public class EmployeesController : ControllerBase
    {
        private readonly ISplanAppService SplanAppService;

        public EmployeesController(ISplanAppService splanAppService)
        {
            SplanAppService = splanAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid projectId, [FromBody] AddEmployeeCommand addEmployeeCommand, CancellationToken cancellationToken = default)
        {
            if (projectId == Guid.Empty)
                return BadRequest("ProjectId is required");

            if (addEmployeeCommand is null)
                throw new ArgumentNullException(nameof(addEmployeeCommand));

            var employeeKey = await SplanAppService.AddEmployee(addEmployeeCommand, projectId, cancellationToken);

            return Ok(employeeKey);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] Guid projectId, [FromBody] UpdateEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken = default)
        {
            if (projectId == Guid.Empty)
                return BadRequest("ProjectId is required");

            if (updateEmployeeCommand is null)
                throw new ArgumentNullException(nameof(updateEmployeeCommand));

            await SplanAppService.UpdateEmployee(updateEmployeeCommand, projectId, cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ListEmployees([FromRoute] Guid projectId, CancellationToken cancellationToken = default)
        {
            if (projectId == Guid.Empty)
                return BadRequest("ProjectId is required");

            var employees = await SplanAppService.ListEmployees(projectId, cancellationToken);

            return Ok(employees);
        }

        [HttpGet("/Get/{projectId:guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid projectId, [FromBody] GetEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            if (projectId == Guid.Empty)
                return BadRequest("ProjectId is required");

            var employee = await SplanAppService.GetEmployeeById(command.Id, projectId, cancellationToken);

            return Ok(employee);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid projectId, DeleteEmployeeCommand command, CancellationToken cancellationToken = default)
        {
            if (projectId == Guid.Empty)
                return BadRequest("ProjectId is required");

            if (command is null)
                throw new ArgumentNullException(nameof(command));

            await SplanAppService.DeleteEmployee(command, projectId, cancellationToken);

            return Ok();
        }

    }
}
