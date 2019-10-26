using System.ComponentModel.DataAnnotations;

namespace Model.DBModels
{
    public class DbDepartures
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Avgangstid")]
        public string DepartureTime { get; set; }
    }
}