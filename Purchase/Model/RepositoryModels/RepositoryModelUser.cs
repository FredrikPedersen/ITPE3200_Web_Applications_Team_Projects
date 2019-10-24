using System.ComponentModel.DataAnnotations;

namespace Purchase.Model.RepositoryModels
{
    public class RepositoryModelUser
    {
        [Required(ErrorMessage = "Navn må oppgis")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Passord må oppgis")]
        public string Password { get; set;}
    }
}