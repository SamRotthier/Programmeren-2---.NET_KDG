using MedievalMMO.BL;
using MedievalMMO.BL.Domain;
using MedievalMMO.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedievalMMO.UI.Web.Controllers;

public class PlayerController : Controller
{
    private readonly IManager _mgr;

    public PlayerController(IManager manager)
    {
        _mgr = manager;
    }

    public IActionResult Index()
    {
        IEnumerable<Player> players = _mgr.GetAllPlayers();
        return View(players);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(NewPlayerModel newPlayer)
    {
        if (!ModelState.IsValid)
        {
            return View(newPlayer);
        }

        _mgr.AddPlayer(newPlayer.PlayerName, newPlayer.PlayerBirthdate, newPlayer.PlayerGender, newPlayer.PlayerLevel);
        return RedirectToAction("Index");
    }
    
    public IActionResult Details(int playerId)
    {
        Player player = _mgr.GetPlayerWithGuilds(playerId);
        return View(player);
    }
    
    
}