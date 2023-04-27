
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

[Comment("Weathers managed on the website")]
public class WeatherContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Weather> Weathers { get; set; } = default!;

    public WeatherContext()
    {
        string path = Path.Combine(
                    Environment.CurrentDirectory, "Weather.db"
                );
        _connectionString = $"Filename={path}";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite(_connectionString);

        optionsBuilder.LogTo(msg => Debug.WriteLine(msg),
             new[] { DbLoggerCategory.Database.Command.Name },
             LogLevel.Information);
    }
}
