using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Repository.DBModels
{
    public class DbCustomer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
    }
}