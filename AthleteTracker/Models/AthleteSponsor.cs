namespace AthleteTracker.Models
{
  public class SponsorAthlete
    {       
        public int AthleteSponsorId { get; set; }
        public int AthleteId { get; set; }
        public int SponsorId { get; set; }
        public virtual Athlete Athlete { get; set; }
        public virtual Sponsor Sponsor { get; set; }
    }
}