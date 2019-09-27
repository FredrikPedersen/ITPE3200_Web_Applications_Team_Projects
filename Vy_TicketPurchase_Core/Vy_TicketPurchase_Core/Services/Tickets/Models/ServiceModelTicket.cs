using System.ComponentModel.DataAnnotations;
using Vy_TicketPurchase_Core.Services.Stations.Models;

namespace Vy_TicketPurchase_Core.Services.Tickets.Models
{
    public class ServiceModelTicket
    {
        [Key]
        public int Id { get; set; }
        public ServiceModelStation ServiceFromStation { get; set; }
        public ServiceModelStation ServiceToStation { get; set; }
        public string Time { get; set; }
        public ServiceModelCustomer ServiceCustomer { get; set; }
    }
}