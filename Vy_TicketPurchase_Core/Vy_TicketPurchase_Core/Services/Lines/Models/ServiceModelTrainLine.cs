using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vy_TicketPurchase_Core.Models.DBModels;

namespace Vy_TicketPurchase_Core.Services.Tickets.Models
{
    public class ServiceModelTrainLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DbStation> Stations { get; set; }
    }
}