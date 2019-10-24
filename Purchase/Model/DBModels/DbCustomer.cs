using System.ComponentModel.DataAnnotations;

namespace Purchase.Model.DBModels
{
    public class DbCustomer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
    }
}