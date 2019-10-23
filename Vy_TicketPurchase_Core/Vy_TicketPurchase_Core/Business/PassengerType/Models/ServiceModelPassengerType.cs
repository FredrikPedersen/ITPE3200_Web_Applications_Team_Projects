using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Business.PassengerType.Models
{
    public class ServiceModelPassengerType
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }
        
        public double PriceMultiplier { get; set; }
    }
}