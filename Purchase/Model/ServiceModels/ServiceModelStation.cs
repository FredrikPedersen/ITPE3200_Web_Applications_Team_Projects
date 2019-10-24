using Purchase.Model.DBModels;
using System.ComponentModel.DataAnnotations;

namespace Purchase.Model.ServiceModels
{
    public class ServiceModelStation
    {
        [Key]
        public int Id { get; set; }
        public int NumberOnLine { get; set; }
        public string StationName { get; set; }
        public virtual DbTrainLine TrainLine { get; set; }
    }
}