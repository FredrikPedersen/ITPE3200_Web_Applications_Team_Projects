using System;

namespace Vy_TicketPurchase_Core.Models.DBModels
{
    public class DbTicket
    {
        public int Id { get; set; }
        public DbRoute DbRoute { get; set; }
        public String Time { get; set; }
        public DbCustomer DbCustomer { get; set; }
    }
}