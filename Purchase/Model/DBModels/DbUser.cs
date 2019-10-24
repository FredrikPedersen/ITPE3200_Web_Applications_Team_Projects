using System.ComponentModel.DataAnnotations;

namespace Model.DBModels
{
    public class DbUser
    {
        [Key]
        public string UserName { get; set; } 
        
        public byte[] Password { get; set; } 
        
        public byte[] Salt { get; set; } 
    }
}