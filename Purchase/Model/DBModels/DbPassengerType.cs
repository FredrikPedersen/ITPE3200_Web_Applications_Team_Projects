using System.ComponentModel.DataAnnotations;
using Audit.EntityFramework;

namespace Model.DBModels
{
    [AuditInclude]
    public class DbPassengerType
    {
        [Key] 
        public int Id { get; set; }
        public string Type { get; set; }
        public double PriceMultiplier { get; set; }
    }
}