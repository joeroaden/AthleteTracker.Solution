using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace AthleteTracker.Models
{
  public class AthleteTrackerContext : DbContext
  {
    public DbSet<Sponsor> Sponsors { get; set; }
    public DbSet<Athlete> Athletes { get; set; }
    public DbSet<Sport> Sports { get; set; }
    public DbSet<AthleteSponsor> AthleteSponsor { get; set; }
    public DbSet<AthleteSport> AthleteSport { get; set;}

    public AthleteTrackerContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}