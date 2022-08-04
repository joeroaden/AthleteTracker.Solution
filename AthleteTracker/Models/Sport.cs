using System.Collections.Generic;

namespace AthleteTracker.Models
{
  public class Sport
    {
        public Sport()
        {
            this.JoinEntities = new HashSet<AthleteSport>();
        }

        public int SportId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AthleteSport> JoinEntities { get; set; }
    }
}