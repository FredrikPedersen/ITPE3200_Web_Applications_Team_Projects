using System.ComponentModel.DataAnnotations;

namespace Model.DBModels
{
    [TrackChanges]
    public class DbStation
    {
        [Key] 
        public int Id { get; set; }
        public int NumberOnLine { get; set; }
        public string StationName { get; set; }
        public virtual DbTrainLine TrainLine { get; set; }
    }
}