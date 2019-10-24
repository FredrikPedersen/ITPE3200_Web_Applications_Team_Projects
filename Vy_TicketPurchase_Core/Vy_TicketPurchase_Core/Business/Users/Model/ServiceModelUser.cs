using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Business.Users.Model
{
    public class ServiceModelUser
    {
        [Required(ErrorMessage = "Navn må oppgis")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Passord må oppgis")]
        public string Password { get; set;}
    }
}