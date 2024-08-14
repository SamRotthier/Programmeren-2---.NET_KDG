using MedievalMMO.BL;
using MedievalMMO.BL.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MedievalMMO.UI.Web.Controllers;

public class MonsterController: Controller
{
    private readonly IManager _mgr;

    public MonsterController(IManager manager)
    {
        _mgr = manager;
    }
    
    public IActionResult Index()
    {
        return View();
    }
}