using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Phase
{
    public class Phase
    {
        [Key]
        public Guid Key { get; set; }
        public Guid ProjectId { get; set; }

        public string Stage { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Phase()
        {
            Key = Guid.NewGuid();
        }

        public void Update(string stage, string description, DateTime startDate, DateTime endDate)
        {
            if (!String.IsNullOrEmpty(stage))
            {
                Stage = stage;
            }
            if (!String.IsNullOrEmpty(description))
            {
                Description = description;
            }

            StartDate = startDate;

            EndDate = endDate;
        }

    }
}
