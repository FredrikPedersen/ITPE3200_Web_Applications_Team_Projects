using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Models.DBModels
{
    public class DbStation
    {
        [Key]
        public int Id { get; set; }
        public string StationName { get; set; }
    }
}