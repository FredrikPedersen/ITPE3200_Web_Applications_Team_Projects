using System.ComponentModel.DataAnnotations;

namespace Purchase.Model.RepositoryModels
{
    public class RepositoryModelDepartures
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Avgangstid")]
        //[DataType(DataType.Time)]
        public string departureTime { get; set; }
    }
}