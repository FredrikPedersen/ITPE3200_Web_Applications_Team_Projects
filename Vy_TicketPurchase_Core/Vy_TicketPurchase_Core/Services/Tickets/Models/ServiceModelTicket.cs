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

        [Required(ErrorMessage = "Frastasjon må velges")]
        [DisplayName("Fra")]
        public string FromStation { get; set; }

        [Required(ErrorMessage = "Tilstasjon må velges")]
        [DisplayName("Til")]
        public string ToStation { get; set; }
        
        [Required(ErrorMessage = "Dato må velges")]
        [DisplayName("Avreise dato")]
        [DataType(DataType.Date)]
        public string ValidFromDate { get; set; }
        
        [Required(ErrorMessage = "Tid må velges")]
        [DisplayName("Avreise tid")]
        [DataType(DataType.Time)]
        public string ValidFromTime { get; set; }
        
        [DisplayName("Pris")]
        public int Price { get; set; }
        
        [Required(ErrorMessage ="Navn må fylles ut")]
        [DisplayName("Fullt navn")]
        public string CustomerName { get; set; }

        [RegularExpression(@"[0-9]{8}", ErrorMessage = "Telefonnummer må inneholde 8 siffer")]
        [Required(ErrorMessage = "Telefonnummer må oppgis")]
        [DisplayName("Telefonnummer")]
        public string CustomerNumber { get; set; }
    }
}