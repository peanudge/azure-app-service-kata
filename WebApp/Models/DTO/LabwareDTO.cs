using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class LabwareDTO
{
    [Required]
    public string DisplayName { get; set; } = default!;

    public Labware ToEntity()
    {
        return new Labware
        {
            DisplayName = DisplayName,
            Position = new Random().Next(),
            CreatedAt = DateTime.Now
        };
    }
}
