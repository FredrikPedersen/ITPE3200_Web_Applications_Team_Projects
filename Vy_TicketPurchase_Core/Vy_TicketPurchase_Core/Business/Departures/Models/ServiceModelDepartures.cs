using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Business.Departures.Models
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