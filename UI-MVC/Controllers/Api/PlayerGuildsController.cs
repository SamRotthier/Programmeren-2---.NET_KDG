using MedievalMMO.BL;
using MedievalMMO.BL.Domain;
using MedievalMMO.UI.Web.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MedievalMMO.UI.Web.Controllers.Api;

[ApiController]
[Route("/api/[controller]")]
public class PlayerGuildsController : ControllerBase
{
    private readonly IManager _mgr;

    public PlayerGuildsController(IManager manager)
    {
        _mgr = manager;
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int idP, int idG)
    {
        PlayerGuild playerGuild = _mgr.GetPlayerGuild(idP, idG);

        if (playerGuild == null)
        {
            return NotFound();
        }

        var playerGuildDto = new PlayerGuildDto
        {
            PlayerId = playerGuild.PlayerId,
            PlayerJoinedGuildOn = playerGuild.PlayerJoinedGuildOn.ToString("yyyy-MM-dd"),
            Player = new PlayerDto()
            {
                PlayerId = playerGuild.Player.PlayerId,
                PlayerName = playerGuild.Player.PlayerName,
                PlayerGender = playerGuild.Player.PlayerGender ?? 0,
                PlayerLevel = playerGuild.Player.PlayerLevel ?? 1
            }
        };
            
        return Ok(playerGuildDto);
    }
    
    [HttpPost]
    public IActionResult Post(NewPlayerGuildDto newPlayerGuild)
    {
        PlayerGuild savedPlayerGuild = _mgr.AddPlayerGuild(newPlayerGuild.PlayerId, newPlayerGuild.GuildId, newPlayerGuild.PlayerJoinedGuildOn);

        return CreatedAtAction("Get", new { Id = newPlayerGuild.PlayerId, Id2 = newPlayerGuild.GuildId}, savedPlayerGuild);
        //return Ok(savedPlayerGuild);
    }
}