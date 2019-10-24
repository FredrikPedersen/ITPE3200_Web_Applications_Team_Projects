using System.ComponentModel.DataAnnotations;

namespace Model.RepositoryModels
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