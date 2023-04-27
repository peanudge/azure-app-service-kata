
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

[Comment("Labwares managed on the website")]
public class LabwareContext : DbContext
{
    public DbSet<Labware> Labwares { get; set; } = default!;

    public LabwareContext(DbContextOptions<LabwareContext> options)
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
