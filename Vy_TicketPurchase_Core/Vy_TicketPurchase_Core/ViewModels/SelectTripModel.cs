using System.Collections.Generic;
using Vy_TicketPurchase_Core.Business.Tickets.Models;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.ViewModels
{
    public class SelectTripModel
    {
        public List<DbDepartures> departures { get; set; }
        public ServiceModelTicket ticket { get; set; }
    }
}