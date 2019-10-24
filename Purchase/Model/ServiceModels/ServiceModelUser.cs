using System.ComponentModel.DataAnnotations;

namespace Purchase.Model.ServiceModels
{
    public class ServiceModelUser
    {
        [Required(ErrorMessage = "Navn må oppgis")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Passord må oppgis")]
        public string Password { get; set;}
    }
}