namespace AthleteTracker.Models
{
  public class AthleteSport
    {       
        public int AthleteSportId { get; set; }
        public int AthleteId { get; set; }
        public int SportId { get; set; }
        public virtual Athlete Athlete { get; set; }
        public virtual Sport Sport { get; set; }
    }
}