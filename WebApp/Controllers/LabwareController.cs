
using Microsoft.AspNetCore.Mvc;

using WebApp.Models;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class LabwareController : ControllerBase
{
    private readonly LabwareContext _context;

    public LabwareController(LabwareContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Labware> GetAllLabware()
    {
        return _context.Labwares.ToList();
    }

    [HttpPost]
    public IActionResult PostLabware(LabwareDTO labware)
    {
        _context.Labwares.Add(labware.ToEntity());
        var changed = _context.SaveChanges();
        return changed > 0 ? Ok() : BadRequest("Failed to add labware");
    }
}
