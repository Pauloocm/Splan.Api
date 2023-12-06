using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Domain.Project
{
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Status { get; set; }

        public Project()
        {
            ProjectId = Guid.NewGuid();
        }

        public void Update(string name, string company, DateTime startDate, DateTime expirationDate, bool status)
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
