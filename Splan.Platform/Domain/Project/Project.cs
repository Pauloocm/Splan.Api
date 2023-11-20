using Splan.Platform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Domain.Project
{
    public class Project
    {
        [Key]
        public Guid Key { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ProjectStatus Status { get; set; }

        public Project()
        {
            Key = Guid.NewGuid();
        }

        public void Update(string name, string company, DateTime startDate, DateTime expirationDate, ProjectStatus status)
        {
            if (!String.IsNullOrEmpty(name))
            {
                Name = name;
            }
            if (!String.IsNullOrEmpty(company))
            {
                Company = company;
            }

            StartDate = startDate;
            ExpirationDate = expirationDate;
            Status = status;
        }
    }
}
