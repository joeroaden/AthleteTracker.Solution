using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AthleteTracker.Models
{
  public class AthleteTrackerContextFactory : IDesignTimeDbContextFactory<AthleteTrackerContext>
  {

    AthleteTrackerContext IDesignTimeDbContextFactory<AthleteTrackerContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<AthleteTrackerContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new AthleteTrackerContext(builder.Options);
    }
  }
}