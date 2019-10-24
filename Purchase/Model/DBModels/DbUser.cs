using System.ComponentModel.DataAnnotations;

namespace Purchase.Model.DBModels
{
    public class DbUser
    {
        [Key]
        public string UserName { get; set; } 
        
        public byte[] Password { get; set; } 
        
        public byte[] Salt { get; set; } 
    }
}