using MedievalMMO.BL;
using MedievalMMO.BL.Domain;
using MedievalMMO.UI.Web.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MedievalMMO.UI.Web.Controllers.Api;

[ApiController]
[Route("/api/[controller]")]
public class GuildsController : ControllerBase
{
    private readonly IManager _mgr;

    public GuildsController(IManager manager)
    {
        _mgr = manager;
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Guild guild = _mgr.GetGuildWithPlayers(id);

        if (guild == null)
        {
            return NotFound();
        }

        GuildDto guildDto = new GuildDto
        {
            GuildId = guild.GuildId,
            GuildName = guild.GuildName,
            GuildMadeOn = guild.GuildMadeOn.ToString("yyyy-MM-dd"),
            GuildLevel = guild.GuildLevel ?? 1,
            GuildMadeBy = guild.GuildMadeBy,
            PlayersInGuild = guild.PlayersInGuild.Select(pg => new PlayerGuildDto
            {
                PlayerId = pg.PlayerId,
                PlayerJoinedGuildOn = pg.PlayerJoinedGuildOn.ToString("yyyy-MM-dd"),
                Player = new PlayerDto()
                {
                    PlayerId = pg.Player.PlayerId,
                    PlayerName = pg.Player.PlayerName,
                    PlayerGender = pg.Player.PlayerGender??0,
                    PlayerLevel = pg.Player.PlayerLevel ??1
                }
            })
        };
        
        return Ok(guildDto);
    }
}