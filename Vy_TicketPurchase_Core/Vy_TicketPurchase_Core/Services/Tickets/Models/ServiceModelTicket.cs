using Vy_TicketPurchase_Core.Services.Routes.Models;

namespace Vy_TicketPurchase_Core.Services.Tickets.Models
{
    public class ServiceModelTicket
    {
        public int Id { get; set; }
        public ServiceModelRoute Route { get; set; }
        public string Time { get; set; }
        public ServiceModelCustomer Customer { get; set; }
    }
}