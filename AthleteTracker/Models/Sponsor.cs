using System.Collections.Generic;

namespace AthleteTracker.Models
{
  public class Sponsor
  {
    public Sponsor()
    {
      this.JoinEntities = new HashSet<SponsorAthlete>();
      
    }

    public int SponsorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<SponsorAthlete> JoinEntities { get; set; }
    
  }
}