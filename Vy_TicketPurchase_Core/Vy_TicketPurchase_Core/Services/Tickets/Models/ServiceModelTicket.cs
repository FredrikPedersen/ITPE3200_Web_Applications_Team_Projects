using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vy_TicketPurchase_Core.Models.DBModels;
using Vy_TicketPurchase_Core.Services.Stations.Models;

namespace Vy_TicketPurchase_Core.Services.Tickets.Models
{
    public class ServiceModelTicket
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Fra")]
        public string FromStation { get; set; }
        [DisplayName("Til")]
        public string ToStation { get; set; }
        [DisplayName("Avreise")]
        public DateTime ValidFrom { get; set; }
        [DisplayName("Fullt navn")]
        public string CustomerName { get; set; }
        [DisplayName("Telefonnummer")]
        public string CustomerNumber { get; set; }
    }
}