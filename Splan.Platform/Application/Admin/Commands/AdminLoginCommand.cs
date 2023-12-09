using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Admin.Commands
{
    public class AdminLoginCommand
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
