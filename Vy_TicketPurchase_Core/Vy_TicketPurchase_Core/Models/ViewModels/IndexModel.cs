using System.Collections.Generic;
using Vy_TicketPurchase_Core.Services.Stations.Models;
using Vy_TicketPurchase_Core.Services.Tickets.Models;

namespace Vy_TicketPurchase_Core.Models.ViewModels
{
    public class IndexModel
    {
        public List<ServiceModelStation> Stations { get; set; }
        
        public ServiceModelTicket Ticket { get; set; }

    }
}