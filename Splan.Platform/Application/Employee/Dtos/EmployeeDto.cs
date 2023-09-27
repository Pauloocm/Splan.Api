namespace Splan.Platform.Application.Employee.Dtos
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public EmployeeDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public EmployeeDto()
        {
            
        }
    }
}
