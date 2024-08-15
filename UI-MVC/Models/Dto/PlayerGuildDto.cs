using System.ComponentModel.DataAnnotations;
using MedievalMMO.BL.Domain;

namespace MedievalMMO.UI.Web.Models.Dto;

public class PlayerGuildDto
{
    public int PlayerId { get; set; }
    public PlayerDto Player {get; set; }
    public string PlayerJoinedGuildOn { get; set; }
}