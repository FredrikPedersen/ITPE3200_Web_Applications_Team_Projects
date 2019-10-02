using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


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
        
        [DisplayName("Pris")]
        public int Price { get; set; }
        
        [DisplayName("Avreise Dato")]
        public DateTime ValidFromDate { get; set; }
        
        [DisplayName("Avreise Tid")]
        public DateTime ValidFromTime { get; set; }
        
        [DisplayName("Fullt navn")]
        public string CustomerName { get; set; }
        
        [DisplayName("Telefonnummer")]
        public string CustomerNumber { get; set; }
    }
}