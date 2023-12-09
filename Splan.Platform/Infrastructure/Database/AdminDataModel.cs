using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Infrastructure.Database
{
    public class AdminDataModel
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }

        public AdminDataModel(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            Email = email;
            Password = password;
        }
    }
}
