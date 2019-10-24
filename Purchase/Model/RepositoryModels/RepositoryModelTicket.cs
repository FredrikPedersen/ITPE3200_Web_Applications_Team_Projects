using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Purchase.Model.RepositoryModels
{
    public class RepositoryModelTicket
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Frastasjon må velges")]
        [Display(Name="Fra", Prompt = "Hvor vil du reise fra?")]  
        public string FromStation { get; set; }

        [Required(ErrorMessage = "Tilstasjon må velges")]
        [Display(Name="Til", Prompt = "Hvor vil du reise til?")]        
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
        public double Price { get; set; }
        
        [Required(ErrorMessage ="Navn må fylles ut")]
        [Display(Name="Fornavn", Prompt = "Fornavn")]  
        public string CustomerGivenName { get; set; }
        
        [Required(ErrorMessage ="Navn må fylles ut")]
        [Display(Name="Etternavn", Prompt = "Etternavn")]  
        public string CustomerLastName { get; set; }

        [RegularExpression(@"[0-9]{8}", ErrorMessage = "Telefonnummer må inneholde 8 siffer")]
        [Required(ErrorMessage = "Telefonnummer må oppgis")]
        [Display(Name="Telefonnummer", Prompt = "Telefonnummer (8 siffer)")]  
        public string CustomerNumber { get; set; }
        
        [Required(ErrorMessage = "Billettype må oppgis!")]
        [Display(Name="Billettype", Prompt = "Velg billettype")]
        public string PassengerType { get; set; }
    }
}