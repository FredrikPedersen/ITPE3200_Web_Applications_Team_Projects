using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Business.Tickets.Models
{
    public class ServiceModelCustomer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
    }
}