using System.ComponentModel.DataAnnotations;

namespace Purchase.Model.ServiceModels
{
    public class ServiceModelDepartures
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Avgangstid")]
        //[DataType(DataType.Time)]
        public string departureTime { get; set; }
    }
}