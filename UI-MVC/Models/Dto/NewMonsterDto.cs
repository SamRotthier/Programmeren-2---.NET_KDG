using MedievalMMO.BL.Domain;

namespace MedievalMMO.UI.Web.Models.Dto;

public class NewMonsterDto
{
    public string MonsterName { get; set; }
    public Gender MonsterGender { get; set; }
    public int MonsterLevel { get; set; }
    public double MonsterHealth { get; set; }
    public bool MonsterCanEvolve { get; set; }
}