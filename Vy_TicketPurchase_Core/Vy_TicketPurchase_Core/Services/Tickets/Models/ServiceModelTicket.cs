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
        public DbStation FromStation { get; set; }
        public DbStation ToStation { get; set; }
        public DateTime ValidFrom { get; set; }
        public DbCustomer Customer { get; set; }
    }
}