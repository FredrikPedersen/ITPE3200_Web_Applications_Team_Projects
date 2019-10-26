using System.ComponentModel.DataAnnotations;

namespace Model.RepositoryModels
{
    public class RepositoryModelDepartures
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Avgangstid")]
        public string DepartureTime { get; set; }
    }
}