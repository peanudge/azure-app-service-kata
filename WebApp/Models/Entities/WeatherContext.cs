
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

[Comment("Weathers managed on the website")]
public class WeatherContext : DbContext
{
    public DbSet<Weather> Weathers { get; set; } = default!;

    public WeatherContext(DbContextOptions<WeatherContext> options)
               : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(msg => Debug.WriteLine(msg),
             new[] { DbLoggerCategory.Database.Command.Name },
             LogLevel.Information);
    }
}
