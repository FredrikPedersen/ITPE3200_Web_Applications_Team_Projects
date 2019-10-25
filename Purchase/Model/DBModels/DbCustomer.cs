using System.ComponentModel.DataAnnotations;
using Audit.EntityFramework;

namespace Model.DBModels
{
    [AuditInclude]
    public class DbCustomer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
    }
}