using System;
using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Models.DBModels
{
    public class DbTicket
    {
        [Key]
        public int Id { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        public int Price { get; set; }
        public DateTime ValidFrom { get; set; }
        public DbCustomer DbCustomer { get; set; }
    }
}