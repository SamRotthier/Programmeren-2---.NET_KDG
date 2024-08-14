using MedievalMMO.BL;
using MedievalMMO.BL.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MedievalMMO.UI.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class MonstersController : Controller
{
    private readonly IManager _mgr;

    public MonstersController(IManager manager)
    {
        _mgr = manager;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<Monster> monsters = _mgr.GetAllMonsters().ToList();

        if (!monsters.Any())
        {
            return NoContent();
        }
        
        return Ok(monsters);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Monster monster = _mgr.GetMonster(id);

        if (monster == null)
        {
            return NotFound();
        }
        return Ok(monster);
    }
    
    [HttpPost]
    public IActionResult Post(NewMonsterDto newMonster)
    {
        Monster createdMonster = _mgr.AddMonster(newMonster.MonsterName, newMonster.MonsterGender, newMonster.MonsterLevel, newMonster.MonsterHealth,newMonster.MonsterCanEvolve);

        return CreatedAtAction("Get", new { Id = createdMonster.MonsterId }, createdMonster);
    }
}