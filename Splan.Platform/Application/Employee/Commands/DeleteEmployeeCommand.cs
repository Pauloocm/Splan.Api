﻿namespace Splan.Platform.Application.Employee.Commands
{
    public class DeleteEmployeeCommand
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeEmail { get; set; }
    }
}
