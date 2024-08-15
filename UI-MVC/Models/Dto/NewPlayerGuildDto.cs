using System.ComponentModel.DataAnnotations;
using MedievalMMO.BL.Domain;

namespace MedievalMMO.UI.Web.Models.Dto;

public class NewPlayerGuildDto
{
    public int PlayerId { get; set; }
    public int GuildId { get; set; }
    public DateTime PlayerJoinedGuildOn { get; set; }
}