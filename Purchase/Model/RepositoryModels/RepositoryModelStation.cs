using System.ComponentModel.DataAnnotations;
using Model.DBModels;

namespace Model.RepositoryModels
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