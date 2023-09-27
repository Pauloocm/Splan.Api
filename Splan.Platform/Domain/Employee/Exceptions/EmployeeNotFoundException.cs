namespace Splan.Platform.Domain.Employee.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(Guid employeeId) : base($"A employee with the specified id was not found {employeeId}")
        {
        }
    }
}
