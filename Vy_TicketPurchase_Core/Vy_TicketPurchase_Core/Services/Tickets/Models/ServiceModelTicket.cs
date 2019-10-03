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
        
        [Required(ErrorMessage = "Frastasjon må velges")]
        [DisplayName("Fra")]
        public string FromStation { get; set; }
        [Required(ErrorMessage = "Tilstajon må velges")]
        [DisplayName("Til")]
        public string ToStation { get; set; }
        [Required(ErrorMessage = "Dato må velges")]
        [DisplayName("Avreise")]
        public DateTime ValidFrom { get; set; }
        [Required(ErrorMessage ="Navn må fylles ut")]
        [DisplayName("Fullt navn")]
        public string CustomerName { get; set; }
        [RegularExpression(@"[0-9]{8}", ErrorMessage ="Telefonnummer må inneholde 8 siffer")]
        [Required(ErrorMessage = "Telefonnummer må oppgis")]
        [DisplayName("Telefonnummer")]
        public string CustomerNumber { get; set; }
    }
}