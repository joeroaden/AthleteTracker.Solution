using System.Collections.Generic;

namespace AthleteTracker.Models
{
  public class Sponsor
  {
    public Sponsor()
    {
      this.JoinEntities = new HashSet<AthleteSponsor>();
      
    }

    public int SponsorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<AthleteSponsor> JoinEntities { get; set; }
    
  }
}