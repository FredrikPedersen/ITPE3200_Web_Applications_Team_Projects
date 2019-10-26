using System.ComponentModel.DataAnnotations;

namespace Model.RepositoryModels
{
    public class RepositoryModelDepartures
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Avgangstid")]
        [Required(ErrorMessage ="Avgangtid må fylles ut!")]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Må være på formatet hh:mm!")]
        public string DepartureTime { get; set; }
    }
}