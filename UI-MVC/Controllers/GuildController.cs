using MedievalMMO.BL;
using MedievalMMO.BL.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MedievalMMO.UI.Web.Controllers;

public class GuildController : Controller
{
    private readonly IManager _mgr;

    public GuildController(IManager manager)
    {
        _mgr = manager;
    }
    
    public IActionResult Details(int guildId)
    {
        Guild guild = _mgr.GetGuild(guildId);
        return View(guild);
    }
}