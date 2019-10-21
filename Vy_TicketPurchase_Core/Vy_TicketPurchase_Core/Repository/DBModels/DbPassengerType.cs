using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Repository.DBModels
{
    public class DbPassengerType
    {
        [Key] 
        public int Id { get; set; }
        public string TypeName { get; set; }
        
        public double PriceMultiplier { get; set; }
    }
}