using System.ComponentModel.DataAnnotations;
using MedievalMMO.BL.Domain;

namespace MedievalMMO.UI.Web.Models;

public class NewPlayerModel : IValidatableObject
{
    [Required(ErrorMessage="Player name cannot be empty")]
    public string PlayerName { get; set; }
    [Required(ErrorMessage="Player birthday cannot be empty")]
    public DateTime PlayerBirthdate { get; set; }
    public Gender PlayerGender { get; set; }
    [Range(1,99, ErrorMessage="Player level outside of range")]
    public int PlayerLevel { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new List<ValidationResult>();

        if (this.PlayerBirthdate > DateTime.Now)
        {
            errors.Add(new ValidationResult("Player cannot be born later then right now", 
                new string[] {"PlayerBirthdate"}));
        }
        return errors;
    }
}