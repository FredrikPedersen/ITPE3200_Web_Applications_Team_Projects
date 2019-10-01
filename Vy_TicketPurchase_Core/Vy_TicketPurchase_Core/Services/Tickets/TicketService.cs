using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase_Core.Models.DBModels;
using Vy_TicketPurchase_Core.Services.Stations.Models;
using Vy_TicketPurchase_Core.Services.Tickets.Models;

namespace Vy_TicketPurchase_Core.Services.Tickets
{
    public class TicketService
    {
        private readonly DatabaseContext _databaseContext;

        public TicketService(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }
        
        public List<ServiceModelTicket> GetAllTickets()
        {
            return _databaseContext.Tickets.Select(t => new ServiceModelTicket
            {
                Id = t.Id,
                FromStation = t.DbFromStation.StationName,
                ToStation = t.DbToStation.StationName,
                CustomerName = t.DbCustomer.Name,
                CustomerNumber = t.DbCustomer.Phonenumber,
                ValidFrom = t.ValidFrom
            }).ToList();
        }
        public void saveTicket(ServiceModelTicket ticket) {
          
        }
    }
}