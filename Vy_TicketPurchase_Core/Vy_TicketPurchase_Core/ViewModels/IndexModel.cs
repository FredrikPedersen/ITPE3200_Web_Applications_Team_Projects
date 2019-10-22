using System.Collections.Generic;
using Vy_TicketPurchase_Core.Business.Stations.Models;
using Vy_TicketPurchase_Core.Business.Tickets.Models;

namespace Vy_TicketPurchase_Core.ViewModels
{
    public class IndexModel
    {
        public List<ServiceModelStation> Stations { get; set; }
        public ServiceModelTicket Ticket { get; set; }
    }
}