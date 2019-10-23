using System.Collections.Generic;
using Vy_TicketPurchase_Core.Business.Departures.Models;
using Vy_TicketPurchase_Core.Business.PassengerType.Models;
using Vy_TicketPurchase_Core.Business.Stations.Models;
using Vy_TicketPurchase_Core.Business.Tickets.Models;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.ViewModels
{
    public class AdminModel
    {
        public List<ServiceModelStation> Stations { get; set; }
        public ServiceModelStation Station { get; set; }
        
        public List<ServiceModelTicket> Tickets { get; set; }
        public ServiceModelTicket Ticket { get; set; }
        
        public List<ServiceModelPassengerType> Types  { get; set; }
        public  ServiceModelPassengerType Type  { get; set; }
        
        public List<DbTrainLine> Lines  { get; set; }
        public DbTrainLine Line  { get; set; }
        
        public List<ServiceModelDepartures> Departures { get; set; }
        public ServiceModelDepartures Departure  { get; set; }
        
    }
}