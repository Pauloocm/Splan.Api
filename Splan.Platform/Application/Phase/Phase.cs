using System.ComponentModel.DataAnnotations;

namespace Splan.Platform.Application.Phase
{
    public class Phase
    {
        [Key]
        public Guid Id { get; set; } 

        public string Stage { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Phase()
        {
            Id = Guid.NewGuid();
        }

        public void Update(string? stage, string? description)
        { 
            if (stage is not null)
            {
                Stage = stage;
            }
            if (description is not null)
            {
                Description = description;
            }
        }

    }
}
