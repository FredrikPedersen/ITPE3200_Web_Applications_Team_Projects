using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vy_TicketPurchase_Core.Services.Tickets.Models;

namespace Vy_TicketPurchase_Core.Models.ViewModels
{
    public class ListLineModel
    {
        public List<ServiceModelTrainLine> trainlines { get; set; }
    }
}