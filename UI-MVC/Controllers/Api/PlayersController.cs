using MedievalMMO.BL;
using MedievalMMO.BL.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MedievalMMO.UI.Web.Controllers.Api;

[ApiController]
[Route("/api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IManager _mgr;

    public PlayersController(IManager manager)
    {
        _mgr = manager;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        IEnumerable<Player> players = _mgr.GetAllPlayers().ToList();

        if (!players.Any())
        {
            return NoContent();
        }
        
        return Ok(players);
    }
}