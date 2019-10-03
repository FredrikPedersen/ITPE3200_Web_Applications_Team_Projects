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

        [DisplayName("Avreise")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Avreisedato må fylles ut")]
        //[RegularExpression(@"(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[012])\.(19|20)\d\d", ErrorMessage = "Feil format på dato")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Navn må fylles ut")]
        [DisplayName("Fullt navn")]
        public string CustomerName { get; set; }

        [RegularExpression(@"[0-9]{8}", ErrorMessage = "Telefonnummer må inneholde 8 siffer")]
        [Required(ErrorMessage = "Telefonnummer må oppgis")]
        [DisplayName("Telefonnummer")]
        public string CustomerNumber { get; set; }
    }
}