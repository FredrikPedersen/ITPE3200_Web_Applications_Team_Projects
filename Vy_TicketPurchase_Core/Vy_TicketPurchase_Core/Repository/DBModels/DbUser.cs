using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Repository.DBModels
{
    public class DbUser
    {
        [Key]
        public string UserName { get; set; } 
        
        public byte[] Password { get; set; } 
        
        public byte[] Salt { get; set; } 
    }
}