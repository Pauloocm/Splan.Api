namespace Splan.Platform.Application.Admin.Exceptions
{
    public class EmailAlreadyExistException : Exception
    {
        public EmailAlreadyExistException(string email) : base($"A register with the specified email already exist {email}")
        {

        }
    }
}
