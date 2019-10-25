using System.ComponentModel.DataAnnotations;
using Audit.EntityFramework;

namespace Model.DBModels
{
    [AuditInclude]
    public class DbUser
    {
        [Key]
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; } 
    }
}