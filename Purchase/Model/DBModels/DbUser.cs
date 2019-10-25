using System.ComponentModel.DataAnnotations;
using Audit.EntityFramework;

namespace Model.DBModels
{
    public class DbUser
    {
        [Key]
        public string UserName { get; set; }
        [AuditIgnore]
        public byte[] Password { get; set; }
        [AuditIgnore]
        public byte[] Salt { get; set; } 
    }
}