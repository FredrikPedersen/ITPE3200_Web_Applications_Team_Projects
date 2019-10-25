using System.ComponentModel.DataAnnotations;
using Audit.EntityFramework;

namespace Model.DBModels
{
    [AuditInclude]
    public class DbStation
    {
        [Key] 
        public int Id { get; set; }
        public int NumberOnLine { get; set; }
        public string StationName { get; set; }
        public virtual DbTrainLine TrainLine { get; set; }
    }
}