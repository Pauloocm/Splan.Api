using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;

namespace Splan.Platform.Application.Phase
{
    public class Phase
    {
        [Key]
        public Guid Key { get; set; } 

        public string Stage { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Phase()
        {
            Key = Guid.NewGuid();
            StartDate = DateTime.Now;
        }

        public void Update(string? stage, string? description, DateTime? startDate, DateTime? endDate)
        { 
            if (!String.IsNullOrEmpty(stage))
            {
                Stage = stage;
            }
            if (!String.IsNullOrEmpty(description))
            {
                Description = description;
            }
            if (startDate is not null)
            {
                StartDate = startDate;
            }
            if (endDate is not null)
            {
                EndDate = endDate;
            }
        }

    }
}
