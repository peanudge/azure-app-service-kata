namespace WebApp.Models;

public class Labware
{
    public long Id { get; set; }
    public string? DisplayName { get; set; }
    public int Position {get;set;}
    public DateTime CreatedAt { get; set; }
}
