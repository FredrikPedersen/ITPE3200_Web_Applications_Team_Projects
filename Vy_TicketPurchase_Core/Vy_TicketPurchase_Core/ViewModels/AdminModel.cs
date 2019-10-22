using System.Collections.Generic;
using Vy_TicketPurchase_Core.Business.Stations.Models;
using Vy_TicketPurchase_Core.Business.Tickets.Models;

namespace Vy_TicketPurchase_Core.ViewModels
{
    public class AdminModel
    {
        public List<ServiceModelStation> Stations { get; set; }

        public List<ServiceModelTicket> Tickets { get; set; }

        public ServiceModelStation Station { get; set; }
    }
}