using Purchase.Model.DBModels;
using System.ComponentModel.DataAnnotations;

namespace Purchase.Model.RepositoryModels
{
    public class RepositoryModelStation
    {
        [Key]
        public int Id { get; set; }
        public int NumberOnLine { get; set; }
        public string StationName { get; set; }
        public virtual DbTrainLine TrainLine { get; set; }
    }
}