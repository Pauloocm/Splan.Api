using Microsoft.AspNetCore.Mvc;
using Splan.Platform.Application.Admin.Commands;
using Splan.Platform.Application.Services;
using Splan.Platform.Domain.GlobalServices;

namespace SplanApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IGlobalRepository GlobalRepository;

        public AuthenticationController(IGlobalRepository globalRepo)
        {
            GlobalRepository = globalRepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AdminLoginCommand command, CancellationToken cancellationToken = default)
        {
            if (command.Email.IsValidEmail() || command.Password.IsValidPassword())
                return BadRequest("Invalid email or password");

            await GlobalRepository.Register(command.Email, command.Password, cancellationToken);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AdminLoginCommand command)
         {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var result = await GlobalRepository.Login(command.Email, command.Password);

            if(string.IsNullOrWhiteSpace(result))
                return BadRequest("Invalid email or password");

            return Ok(result);
        }
    }
}
