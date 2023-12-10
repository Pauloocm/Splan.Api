using System.Text.RegularExpressions;

namespace Splan.Platform.Application.Services
{
    public static class Extensions
    {
        public static bool IsValidEmail(this string email)
        {
            string pattern = "^(?i)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]+@{2,}$";

            Regex regex = new(pattern);

            return regex.IsMatch(email);
        }

        public static bool IsValidPassword(this string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";

            Regex regex = new(pattern);

            return regex.IsMatch(password);
        }
    }
}
