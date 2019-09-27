using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Models.DBModels
{
    public class DbTicket
    {
        [Key]
        public int Id { get; set; }
        public DbStation DbFromStation { get; set; }
        public DbStation DbToStation { get; set; }
        public string Time { get; set; }
        public DbCustomer DbCustomer { get; set; }
    }
}