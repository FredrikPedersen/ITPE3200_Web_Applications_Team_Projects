using System;
using System.ComponentModel.DataAnnotations;
using Vy_TicketPurchase_Core.Models.DBModels;
using Vy_TicketPurchase_Core.Services.Stations.Models;

namespace Vy_TicketPurchase_Core.Services.Tickets.Models
{
    public class ServiceModelTicket
    {
        [Key]
        public int Id { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        public DateTime ValidFrom { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
    }
}