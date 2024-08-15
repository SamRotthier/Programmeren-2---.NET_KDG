

using System.ComponentModel.DataAnnotations;
using MedievalMMO.BL.Domain;


namespace MedievalMMO.UI.Web.Models.Dto;

public class PlayerDto
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }
    public Gender PlayerGender { get; set; }
    public int PlayerLevel { get; set; }

}