using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Services.Stations.Models
{
    public class ServiceModelStation
    {
        [Key]
        public int Id { get; set; }
        public string StationName { get; set; }
    }
}